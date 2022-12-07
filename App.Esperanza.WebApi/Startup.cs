//using App.Esperanza.WebApi.AppStart
using App.Esperanza.WebApi.App_Start;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(App.Esperanza.WebApi.Startup))]

namespace App.Esperanza.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            RouteConfig.Register(config);
            DIConfig.ConfigureInjector(config);

            app.UseWebApi(config);
        }
    }
}
