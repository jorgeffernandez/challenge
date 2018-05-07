using Challenge.Application;
using Challenge.Domain;
using Challenge.Infraestructure.Core;
using Challenge.Infraestructure.DataContext;
using Challenge.Infraestructure.Repositories;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Challenge.CrossCutting.IoC
{
    public class IoCApiUnityContainer : IDependencyScope
    {
        protected IUnityContainer container;

        public IoCApiUnityContainer(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            if (container.IsRegistered(serviceType))
            {
                return container.Resolve(serviceType);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (container.IsRegistered(serviceType))
            {
                return container.ResolveAll(serviceType);
            }
            else
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }


    public class IoCContainer : IoCApiUnityContainer, IDependencyResolver
    {
        public IoCContainer(IUnityContainer container)
            : base(container)
        {
            ConfigureRootContainer();
            Register();
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new IoCApiUnityContainer(child);
        }

        private void ConfigureRootContainer()
        {
            container.RegisterType<IDbUnitOfWork, ChallengeEntities>("Phones", new PerResolveLifetimeManager());
        }

        private void Register()
        {
            this.RegisterRepository();
            this.RegisterApplication();
        }

        private void RegisterRepository()
        {
            container.RegisterType<IPhonesRepository, PhonesRepository>(new TransientLifetimeManager());
        }

        private void RegisterApplication()
        {
            container.RegisterType<IApplicationAuthorization, ApplicationAuthorization>(new TransientLifetimeManager());
            container.RegisterType<IApplicationPhone, ApplicationPhone>(new TransientLifetimeManager());
        }
    }
}
