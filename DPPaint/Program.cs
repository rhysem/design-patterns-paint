using System;
using System.Reflection;
using System.Windows.Forms;

using Autofac;

using DPPaint.Controllers;
using DPPaint.Models.ApplicationState;
using DPPaint.Views;

namespace DPPaint
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            var assemblies = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyModules(assemblies);
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                PaintCanvas paintCanvas = new PaintCanvas();
                IGuiWindow guiWindow = scope.Resolve<IGuiWindow>(new NamedParameter("canvas", paintCanvas));
                IUiModule uiModule = scope.Resolve<IUiModule>(new NamedParameter("gui", guiWindow));
                IApplicationState appState = scope.Resolve<IApplicationState>(new NamedParameter("uiModule", uiModule)); 
                IPaintController controller = scope.Resolve<IPaintController>(new NamedParameter("uiModule", uiModule),
                                                                              new NamedParameter("applicationState", appState),
                                                                              new NamedParameter("paintCanvas", paintCanvas));
                controller.Setup();

                Application.Run((Form)guiWindow);
            }
        }
    }
}
