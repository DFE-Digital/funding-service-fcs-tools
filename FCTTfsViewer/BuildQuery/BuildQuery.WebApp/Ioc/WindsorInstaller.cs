using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildQuery.WebApp.Ioc
{
    using System.Web.Http.Controllers;
    using BuildQuery.WebApp.API;
    using BuildQuery.WebApp.Models;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IMainModelManager, MainModelManager>().LifestyleSingleton());

                container.Register(Classes.FromThisAssembly()
                            .BasedOn<IHttpController>()
                            .LifestyleTransient());

        }
    }
}