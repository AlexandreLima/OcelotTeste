using System;
using Ocelot.Cache;

namespace ocelotteste.Tools.Cache
{
    public class RedisCache : IOcelotCache<CachedResponse>
    {
        public void Add(string key, CachedResponse value, TimeSpan ttl, string region)
        {
            throw new NotImplementedException();
        }

        public void AddAndDelete(string key, CachedResponse value, TimeSpan ttl, string region)
        {
            throw new NotImplementedException();
        }

        public void ClearRegion(string region)
        {
            throw new NotImplementedException();
        }

        public CachedResponse Get(string key, string region)
        {
            throw new NotImplementedException();
        }
    }
}
