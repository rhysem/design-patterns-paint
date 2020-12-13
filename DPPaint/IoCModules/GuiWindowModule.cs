
using Autofac;

using DPPaint.Views;

namespace DPPaint.IoCModules
{
    class GuiWindowModule : Module 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GuiWindow>()
                .As<IGuiWindow>();
        }
    }
}
