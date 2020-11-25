using System;
using System.Drawing;
using System.Windows.Forms;

using DPPaint.Models;
using DPPaint.Views.PaintStrategy;

namespace DPPaint
{
    public class PaintCanvas : PaintCanvasBase
    {
        private IPaintStrategy _paintStrategy;

        public PaintCanvas()
        {
            MouseDown += new MouseEventHandler(canvas_MouseDown);
            MouseUp += new MouseEventHandler(canvas_MouseUp);
        }

        public void SetPaintStrategy(ShapeType shapeType)
        {
            switch(shapeType)
            {
                case ShapeType.RECTANGLE:
                    _paintStrategy = new RectanglePaintStrategy();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        protected void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (_paintStrategy == null)
            {
                throw new Exception("Oops!"); // TODO
            }
            _paintStrategy.SetPointA(new Point(e.X, e.Y));
        }

        protected void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (_paintStrategy == null)
            {
                throw new Exception("Oops!"); // TODO
            }
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

            if (_paintStrategy == null)
            {
                throw new Exception("Oops!"); // TODO
            }
            _paintStrategy.DrawShape(e);

            //var pen = new Pen(Color.Blue);
            //e.Graphics.DrawRectangle(pen, new Rectangle(new Point(200, 150), new Size(75, 75)));
        }
    }
}
