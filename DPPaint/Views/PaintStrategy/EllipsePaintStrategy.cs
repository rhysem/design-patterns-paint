using System;
using System.Drawing;
using System.Windows.Forms;

using DPPaint.Models;
using DPPaint.Views.DrawCommand;

namespace DPPaint.Views.PaintStrategy
{
    public class EllipsePaintStrategy : IPaintStrategy
    {
        private Rectangle _ellipse;

        public void SetPoints(Point pointA, Point pointB)
        {
            _ellipse = CalculateEllipseBounds(pointA, pointB);
            AddDrawAction();
        }

        public void AddDrawAction()
        {
            var action = new DrawAction()
            {
                ShapeType = ShapeType.ELLIPSE,
                Shape = _ellipse,
                DrawCommand = new DrawFilledInCommand()
                //Brush = new SolidBrush(Color.Blue)
            };  

            CommandHistory.AddAction(action);
        }

        public void DrawShape(DrawAction a, PaintEventArgs e)
        {
            a.DrawCommand.ExecuteDraw(e, a.ShapeType, a.Shape);
            //e.Graphics.FillEllipse((Brush)a.Brush, (Rectangle)a.Shape);
        }

        private Rectangle CalculateEllipseBounds(Point pointA, Point pointB)
        {
            return Rectangle.FromLTRB(Math.Min(pointA.X, pointB.X), Math.Min(pointA.Y, pointB.Y),
                                      Math.Max(pointA.X, pointB.X), Math.Max(pointA.Y, pointB.Y));
        }
    }
}
