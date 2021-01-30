using BackendApplication.Models.Dto;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackendApplication.Clients
{
    public class UserClient :  IUserClient
    {
        private readonly string url;
        private readonly IMemoryCache cache;
        private readonly IDistributedCache redis;
        private readonly int memCacheDuration;
        private readonly int redisCacheDuration;
        const string memoryKey = "MemoryKey";
        const string redisKey = "RedisKey";

        public UserClient(IConfiguration config, IMemoryCache cache, IDistributedCache redis)
        {
            this.url = config.GetValue<string>("ConnectionStrings:UserApi");
            this.cache = cache;
            this.redis = redis;
            this.memCacheDuration = int.Parse(config.GetValue<string>("Cache.Duration"));
            this.redisCacheDuration = int.Parse(config.GetValue<string>("Redis.Duration"));
        }

        public async Task<UserDto> GetUserInfoAsync(int id)
        {
            UserDto user;
            if (!cache.TryGetValue(memoryKey+id, out user))
            {
                var key = redisKey + id;
                var t = await redis.GetStringAsync(key);
                if (!string.IsNullOrEmpty(t))
                {
                    user = JsonConvert.DeserializeObject<UserDto>(t);
                    cache.Set(memoryKey + id, user, TimeSpan.FromSeconds(this.memCacheDuration));
                    return user;
                }
                
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url + $"{id}");
                var json = await httpResponse.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<UserDto>(json);


                await redis.SetStringAsync(key, json,
                    options: new DistributedCacheEntryOptions()
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(redisCacheDuration)
                    });

                cache.Set(memoryKey + id, user, TimeSpan.FromSeconds(this.memCacheDuration));
            }

            return user;
        }
    }
}
