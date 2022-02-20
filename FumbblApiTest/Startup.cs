using Fumbbl.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FumbblApiTest
{
    public class Startup
    {
        public void ConfigureHost(IHostBuilder hostBuilder) =>
            hostBuilder.ConfigureAppConfiguration(x =>
            {
                x.AddUserSecrets(Assembly.GetExecutingAssembly());
            });


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFumbbl();
        }
    }
}
