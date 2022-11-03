using App.Esperanza.UnitOfWork;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.Web;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace App.Esperanza.UI.MVC.App_Start
{
    public class DIConfig
    {
        public static void ConfigureInjector()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<IUnitOfWork>( () => new
               VentasUnitOfWork(ConfigurationManager.ConnectionStrings["VentasConnection"].ToString()));

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            //Descomentar esta configuracion para usar log4net
            /*
            container.RegisterConditional(typeof(ILog),
                                            c => typeof(Log4NetAdapter<>).MakeGenericType(c.Consumer.ImplementationType),
                                            Lifestyle.Singleton, c => true);
            */

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}