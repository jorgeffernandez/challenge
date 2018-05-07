namespace Challenge.Services.Infraestructure.AutofacModules
{
    using Autofac;
    using Challenge.Services.Traces;
    using Challenge.ServicesAbstract.Traces;

    public class ServiceModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SessionTraceService>().As<ISessionTraceService>();
        }
    }
}
