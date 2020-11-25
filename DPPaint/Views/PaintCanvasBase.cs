using System.Windows.Forms;

namespace DPPaint
{
    public abstract class PaintCanvasBase : Control
    {
        //protected Point pointA { get; set; }
        //protected Point pointB { get; set; }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PaintCanvasBase
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "PaintCanvasBase";
            this.ResumeLayout(false);

        }

        //public abstract Graphics GetGraphics();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            //if (!pointA.IsEmpty && !pointB.IsEmpty)
            //{
            //    var pen = new Pen(Color.Blue);
            //    e.Graphics.DrawRectangle(pen, Rectangle.FromLTRB(pointA.X, pointA.Y, pointB.X, pointB.Y));
            //}
        }
    }
}
