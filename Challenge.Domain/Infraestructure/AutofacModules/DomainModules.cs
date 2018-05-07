namespace Challenge.Domain.Infraestructure.AutofacModules
{
    using Autofac;
    using Challenge.Domain.Traces;
    using Challenge.DomainAbstract.Traces;

    public class DomainModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SessionTraceDomain>().As<ISessionTraceDomain>();
        }
    }
}
