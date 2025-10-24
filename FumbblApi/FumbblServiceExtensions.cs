using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api
{
    public static class FumbblServiceExtensions
    {
        public static IServiceCollection AddFumbbl(this IServiceCollection services)
        {
            services.AddScoped<FumbblApi>();
            services.AddScoped<FumbblAuthHandler>();
            services.AddHttpClient<FumbblApi>()
                .AddHttpMessageHandler<FumbblAuthHandler>();

            return services;
        }
    }
}
