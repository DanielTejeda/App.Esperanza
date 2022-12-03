using App.Esperanza.WebApi.App_Start;
//using App.Esperanza.WebApi.Handlers;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Routing;

[assembly: OwinStartup(typeof(App.Esperanza.WebApi.Startup))]

namespace App.Esperanza.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            //config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            RouteConfig.Register(config);
            //DIConfig.ConfigureInjector(config);
            //TokenConfig.ConfigureOAuth(app, config);
            //WebApiConfig.Configure(config);
            app.UseWebApi(config);
            


        }
    }
}
