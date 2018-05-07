namespace Challenge.Infraestructure.AutofacModules
{
    using Autofac;
    using Challenge.Infraestructure.Repositories;
    using Challenge.InfraestructureAbstract;

    public class InfraestructureModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>();
            builder.RegisterType<SessionTraceRepository>().As<ISessionTraceRepository>();

        }
    }
}