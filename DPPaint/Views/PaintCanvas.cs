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
        protected Point _pointA;
        protected Point _pointB;

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
            //_paintStrategy.SetPointA(new Point(e.X, e.Y));
            _pointA = new Point(e.X, e.Y);
        }

        protected void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (_paintStrategy == null)
            {
                throw new Exception("Oops!"); // TODO
            }
            _pointB = new Point(e.X, e.Y);
            _paintStrategy.SetPoints(_pointA, _pointB);
            //_paintStrategy.SetPointB(new Point(e.X, e.Y));
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

            var actions = CommandHistory.GetActions();
            while (actions.Count > 0)
            {
                var a = actions.Dequeue();
                // set paint strategy based on type of 'a'
                SetPaintStrategy(a.ShapeType);
                // draw shape
                _paintStrategy.DrawShape(a, e);
            }

        }

        public void Undo()
        {
            CommandHistory.Undo();
            Refresh();
        }

        public void Redo()
        {
            CommandHistory.Redo();
            Refresh();
        }
    }
}
