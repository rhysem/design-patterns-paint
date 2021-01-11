using Autofac;

using DPPaint.Models.ApplicationState;

namespace DPPaint.IoCModules
{
    class ApplicationStateModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationState>()
                .As<IApplicationState>()
                .SingleInstance();
        }
    }
}
