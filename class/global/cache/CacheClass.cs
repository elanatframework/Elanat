using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System.Collections;
using System.Reflection;

namespace Elanat
{
    public class CacheClass
    {
        public IMemoryCache Cache;

        public CacheClass()
        {
            Cache = new HttpContextAccessor().HttpContext.RequestServices.GetService<IMemoryCache>();
        }

        /// <param name="CacheType">disk, memory</param>
        public void Insert(string CacheType, string Key, string Value, int Duration)
        {
            if (CacheType == "disk")
                InsertToDisk(Key, Value, Duration);
            else
                InsertToMemory(Key, Value, Duration);
        }

        /// <param name="CacheType">disk, memory</param>
        public bool Exist(string CacheType, string Key)
        {
            if (CacheType == "disk")
                return (ExistInDisk(Key));
            else
                return (ExistInMemory(Key));
        }

        /// <param name="CacheType">disk, memory</param>
        public string GetValue(string CacheType, string Key)
        {
            if (CacheType == "disk")
                return GetDiskValue(Key);
            else
                return GetMemoryValue(Key);
        }

        public void InsertToMemory(string Key, string Value, int Duration)
        {
            if (Duration <= 0)
                return;


            var CacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.MaxValue,
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(Duration)
            };


            Cache.Set("$_cache memory;" + Key, Value, CacheExpiryOptions);
        }

        public bool ExistInMemory(string Key)
        {
            return (Cache.Get("$_cache memory;" + Key) != null);
        }

        public string GetMemoryValue(string Key)
        {
            return Cache.Get("$_cache memory;" + Key).ToString();
        }

        public void InsertToDisk(string Key, string Value, int Duration)
        {
            if (Duration <= 0)
                return;

            var CacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.MaxValue,
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(Duration)
            };

            CacheExpiryOptions.RegisterPostEvictionCallback((key, value, reason, substate) =>{DeletePhysicalData(key.ToString());});


            Cache.Set("$_cache disk;" + Key, "disk", CacheExpiryOptions);
            
            var Lines = Value;
            File.WriteAllText(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/cache/disk/" + "_cache_disk_" + Key.ToFileNameEncode() + ".tmp"), Lines);
        }

        public bool ExistInDisk(string Key)
        {
            return (Cache.Get("$_cache disk;" + Key) != null);
        }

        public void Delete(string CacheType, string Key)
        {
            if (CacheType == "disk")
                Cache.Remove("$_cache disk;" + Key);
            else
                Cache.Remove("$_cache memory;" + Key);
        }

        public void DeleteFromDisk(string Key)
        {
            Cache.Remove("$_cache disk;" + Key);
        }

        public void DeleteAllFromDisk()
        {
            foreach (string key in CaceKeyList())
            {
                if (key.TextStartMathByValueCheck("$_cache disk;"))
                    Cache.Remove(key);
            }
        }

        public void DeleteAll()
        {
            foreach (string key in CaceKeyList())
            {
                Cache.Remove(key);
            }
        }

        public void DeleteFromMemory(string Key)
        {
            Cache.Remove("$_cache memory;" + Key);
        }

        public void DeleteAllFromMemory()
        {
            foreach (string key in CaceKeyList())
            {
                if (key.TextStartMathByValueCheck("$_cache memory;"))
                    Cache.Remove(key);
            }
        }

        public string GetDiskValue(string Key)
        {
            var Lines = File.OpenText(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/cache/disk/" + "_cache_disk_" + Key.ToFileNameEncode() + ".tmp"));
            string FleText = Lines.ReadToEnd();
            Lines.Close();

            return FleText;
        }

        public static void DeletePhysicalData(string key)
        {
            try
            {
                File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/cache/disk/" + key.ToFileNameEncode() + ".tmp"));
            }
            catch (Exception){}
        }

        public List<string> CaceKeyList()
        {
            var field = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            var collection = field.GetValue(Cache) as ICollection;
            List<string> items = new List<string>();
            if (collection != null)
                foreach (var item in collection)
                {
                    var methodInfo = item.GetType().GetProperty("Key");
                    var val = methodInfo.GetValue(item);
                    items.Add(val.ToString());
                }

            return items;
        }
    }
}