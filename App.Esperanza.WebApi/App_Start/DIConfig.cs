using App.Esperanza.UnitOfWork;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Configuration;
using System.Reflection;
using System.Web.Http.Dependencies;

namespace App.Esperanza.WebApi.App_Start
{
    public class DIConfig
    {
        public static void ConfigureInjector(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IUnitOfWork>(() => new
               VentasUnitOfWork(ConfigurationManager.ConnectionStrings["VentasConnection"].ToString()));

            container.RegisterWebApiControllers(config);

            //Descomentar esta configuracion para usar log4net
            /*
            container.RegisterConditional(typeof(ILog),
                                            c => typeof(Log4NetAdapter<>).MakeGenericType(c.Consumer.ImplementationType),
                                            Lifestyle.Singleton, c => true);
            */

            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}