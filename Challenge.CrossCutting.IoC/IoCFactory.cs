namespace Challenge.CrossCutting.IoC
{
    public class IoCFactory
    {
        #region Singleton

        private static readonly IoCFactory instance = new IoCFactory();

        /// <summary>
        /// 
        /// </summary>
        public static IoCFactory Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        #region Members

        IoCUnityContainer _CurrentContainer = new IoCUnityContainer();

        public IoCUnityContainer CurrentContainer
        {
            get
            {
                return _CurrentContainer;
            }
        }

        #endregion
    }
}
