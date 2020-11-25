using System.Drawing;
using System.Windows.Forms;

using DPPaint.Views.PaintStrategy;

namespace DPPaint
{
    public class PaintCanvas : PaintCanvasBase
    {
        //protected Point topLeftPoint { get; set; }
        //protected Point bottomRightPoint { get; set; }
        private readonly IPaintStrategy _paintStrategy;

        public PaintCanvas()
        {
            _paintStrategy = new RectanglePaintStrategy();
            MouseDown += new MouseEventHandler(canvas_MouseDown);
            MouseUp += new MouseEventHandler(canvas_MouseUp);
        }

        protected void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            _paintStrategy.SetPointA(new Point(e.X, e.Y));
        }

        protected void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            _paintStrategy.SetPointB(new Point(e.X, e.Y));
            Refresh();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
        //public override Graphics GetGraphics()
        //{
        //    return GetGraphics();
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            _paintStrategy.DrawShape(e);

            //var pen = new Pen(Color.Blue);
            //e.Graphics.DrawRectangle(pen, new Rectangle(new Point(200, 150), new Size(75, 75)));
        }
    }
}
