using Challenge.Infraestructure.Core;
using Challenge.Infraestructure.DataContext;
using Microsoft.Practices.Unity;


namespace Challenge.CrossCutting.IoC
{
    public class IoCUnityContainer
    {
        IUnityContainer _rootContainer;

        public IUnityContainer RootContainer
        {
            get
            {
                return this._rootContainer;
            }
            set
            {
                this._rootContainer = value;
            }
        }

        #region Constructor

        public IoCUnityContainer()
        {
            _rootContainer = new UnityContainer();
            ConfigureRootContainer();
            Register();
        }

        #endregion

        private void ConfigureRootContainer()
        {
            _rootContainer.RegisterType<IDbUnitOfWork, ChallengeEntities>("Phones", new PerResolveLifetimeManager());
        }

        private void Register()
        {
            this.RegisterRepository();
            this.RegisterApplication();
        }

        #region Métodos privados

        private void RegisterRepository()
        {
        }

        private void RegisterApplication()
        {
        }

        #endregion
    }
}
