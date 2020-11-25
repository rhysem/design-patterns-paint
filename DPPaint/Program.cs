using System;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //PaintCanvasBase paintCanvas = new PaintCanvas();
            PaintCanvas paintCanvas = new PaintCanvas();
            IGuiWindow guiWindow = new GuiWindow(paintCanvas);
            IUiModule uiModule = new Gui(guiWindow);
            ApplicationState appState = new ApplicationState(uiModule);
            IPaintController controller = new PaintController(uiModule, appState);
            controller.Setup();

            Application.Run((Form)guiWindow);

            //// For example purposes only; remove all lines below from your final project.

            //try
            //{
            //    Thread.sleep(500);
            //}
            //catch (InterruptedException e)
            //{
            //    e.printStackTrace();
            //}

            //// Filled in rectangle
            //Graphics2D graphics2d = paintCanvas.getGraphics2D();
            //graphics2d.setColor(Color.GREEN);
            //graphics2d.fillRect(12, 13, 200, 400);

            //// Outlined rectangle
            //graphics2d.setStroke(new BasicStroke(5));
            //graphics2d.setColor(Color.BLUE);
            //graphics2d.drawRect(12, 13, 200, 400);

            //// Selected Shape
            //Stroke stroke = new BasicStroke(3, BasicStroke.CAP_BUTT, BasicStroke.JOIN_BEVEL, 1, new float[] { 9 }, 0);
            //graphics2d.setStroke(stroke);
            //graphics2d.setColor(Color.BLACK);
            //graphics2d.drawRect(7, 8, 210, 410);
        }
    }
}
