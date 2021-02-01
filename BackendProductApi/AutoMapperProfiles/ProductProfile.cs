using AutoMapper;
using BackendProductApi.Models;
using BackendProductApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BackendProductApi.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            var client = new HttpClient();
            
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/users/");

                CreateMap<Product, ProductVM>().AfterMap((src,dest)=>{
              
                    //HTTP GET
                    var responseTask = client.GetAsync(src.OwnerId.ToString());
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<User>();
                        readTask.Wait();
                        var student = readTask.Result;
                        dest.AppUserFullName = student.Name;
                        dest.AppUserPhoneNumber = student.Phone; 
                    }
            });
          
        }
    }
}
