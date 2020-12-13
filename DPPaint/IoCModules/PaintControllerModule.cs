using Autofac;

using DPPaint.Controllers;

namespace DPPaint.IoCModules
{
    class PaintControllerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PaintController>()
                .As<IPaintController>();
        }
    }
}
