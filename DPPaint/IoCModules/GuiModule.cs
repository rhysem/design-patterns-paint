using Autofac;

using DPPaint.Views;

namespace DPPaint.IoCModules
{
    class GuiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Gui>()
                .As<IUiModule>();
        }
    }
}
