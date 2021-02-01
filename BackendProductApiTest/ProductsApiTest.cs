using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BackendProductApiTest
{
    
    public class ProductsApiTest
    {
        [Fact]
        public async void Test_Get_All()
        {
            var client = new TestClientProvider().Client;
            var response = await client.GetAsync("/api/Products");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                 
        }
    }
}
