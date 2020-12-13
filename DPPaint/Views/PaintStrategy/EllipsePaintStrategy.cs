using System;
using System.Drawing;
using System.Windows.Forms;

using DPPaint.Models;

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
                Brush = new SolidBrush(Color.Blue)
            };
        }

        public void DrawShape(DrawAction a, PaintEventArgs e)
        {
            e.Graphics.FillEllipse((Brush)a.Brush, (Rectangle)a.Shape);
        }

        private Rectangle CalculateEllipseBounds(Point pointA, Point pointB)
        {
            return Rectangle.FromLTRB(Math.Min(pointA.X, pointB.X), Math.Min(pointA.Y, pointB.Y),
                                      Math.Max(pointA.X, pointB.X), Math.Max(pointA.Y, pointB.Y));
        }
    }
}
