using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;

namespace elanat
{
    public class CacheClass
    {
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

            HttpContext.Current.Cache.Insert("$_cache memory;" + Key, Value, null, DateTime.Now.AddSeconds(Duration), Cache.NoSlidingExpiration);
        }

        public bool ExistInMemory(string Key)
        {
            return (HttpContext.Current.Cache["$_cache memory;" + Key] != null);
        }

        public string GetMemoryValue(string Key)
        {
            return HttpContext.Current.Cache["$_cache memory;" + Key].ToString();
        }

        public void InsertToDisk(string Key, string Value, int Duration)
        {
            if (Duration <= 0)
                return;

            System.Web.Caching.CacheItemRemovedCallback callback = new System.Web.Caching.CacheItemRemovedCallback(DeletePhysicalData);
            HttpContext.Current.Cache.Insert("$_cache disk;" + Key, "disk", null, DateTime.Now.AddSeconds(Duration), Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, callback);
            
            var Lines = Value;
            System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/cache/disk/" + "$_cache disk;" + Key.ToFileNameEncode() + ".tmp"), Lines);
        }

        public bool ExistInDisk(string Key)
        {
            return (HttpContext.Current.Cache["$_cache disk;" + Key] != null);
        }

        public void Delete(string CacheType, string Key)
        {
            if (CacheType == "disk")
                HttpContext.Current.Cache.Remove("$_cache disk;" + Key);
            else
                HttpContext.Current.Cache.Remove("$_cache memory;" + Key);
        }

        public void DeleteFromDisk(string Key)
        {
            HttpContext.Current.Cache.Remove("$_cache disk;" + Key);
        }

        public void DeleteAllFromDisk()
        {
            IDictionaryEnumerator CacheList = HttpRuntime.Cache.GetEnumerator();

            string BreakValue = "";

            while (CacheList.MoveNext())
            {
                if (BreakValue == CacheList.Key.ToString())
                    break;

                BreakValue = CacheList.Key.ToString();

                if (CacheList.Key.ToString().TextStartMathByValueCheck("$_cache disk;"))
                    HttpContext.Current.Cache.Remove(CacheList.Key.ToString());
            }            
        }

        public void DeleteFromMemory(string Key)
        {
            HttpContext.Current.Cache.Remove("$_cache memory;" + Key);
        }

        public void DeleteAllFromMemory()
        {
            IDictionaryEnumerator CacheList = HttpRuntime.Cache.GetEnumerator();

            string BreakValue = "";

            while (CacheList.MoveNext())
            {
                if (BreakValue == CacheList.Key.ToString())
                    break;

                BreakValue = CacheList.Key.ToString();

                if (CacheList.Key.ToString().TextStartMathByValueCheck("$_cache memory;"))
                    HttpContext.Current.Cache.Remove(CacheList.Key.ToString());
            }
        }

        public string GetDiskValue(string Key)
        {
            var Lines = System.IO.File.OpenText(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/cache/disk/" + "$_cache disk;" + Key.ToFileNameEncode() + ".tmp"));
            string FleText = Lines.ReadToEnd();
            Lines.Close();

            return FleText;
        }

        public static void DeletePhysicalData(string key, object cacheItem, System.Web.Caching.CacheItemRemovedReason reason)
        {
            try
            {
                System.IO.File.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/cache/disk/" + key + ".tmp"));
            }
            catch (Exception){}
        }
    }
}