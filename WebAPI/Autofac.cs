using Autofac;
using WebAPI.Services;

namespace WebAPI
{
    public sealed class AutofacModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {





            // Transient         
            builder.RegisterType<Customer>().As<ICustomer>()
                .InstancePerDependency();





            //// Scoped
            //builder.RegisterType<Methods>().As<IMethods>()
            //        .InstancePerLifetimeScope();



            //// Singleton

            //builder.RegisterType<Methods>().As<IMethods>()
            //    .SingleInstance();

        }
    }
}
