using Innoloft.Core.Interfaces;
using Innoloft.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Innoloft.Core
{
    public static class DependencyInjection
    {
        public static void AddCore(this IServiceCollection service)
        {
            service.ConfigureInjection();
            service.AddHttpClient();
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void ConfigureInjection(this IServiceCollection service)
        {
            service.AddScoped<IUserRequestService, UserRequestService>();
        }
    }
}
