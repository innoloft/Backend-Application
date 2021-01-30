using BackendApplication.Clients;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        private readonly UserClient userClient;
        public UnitTest1()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var opts = Options.Create<MemoryDistributedCacheOptions>(new MemoryDistributedCacheOptions());
            IDistributedCache distCache = new MemoryDistributedCache(opts);
            var memoryCacheOptions = new MemoryCacheOptions();
            userClient = new UserClient(config, new MemoryCache(memoryCacheOptions), distCache);


        }
        [Fact]
        public async Task Test()
        {
            var user = await userClient.GetUserInfoAsync(1);
            Assert.Equal("Leanne Graham", user.Name);

            user = await userClient.GetUserInfoAsync(2);
            Assert.NotEqual("Leanne Graham", user.Name);
        }

        [Fact]
        public async Task Test2()
        {
            var user = await userClient.GetUserInfoAsync(11);
            Assert.NotEqual("Leanne Graham", user.Name);
        }
    }
}
