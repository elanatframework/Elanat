using Microsoft.Extensions.Caching.Memory;

namespace Elanat
{
    public class Cache
    {
        IMemoryCache MemoryCache;
        public Cache(IMemoryCache MemoryCache)
        {
            this.MemoryCache = MemoryCache;
        }
    }
}