using System;
using System.Drawing;
using System.Windows.Forms;

using DPPaint.Models;

namespace DPPaint.Views.PaintStrategy
{
    public class RectanglePaintStrategy : IPaintStrategy
    {
        //private Point _pointA;
        //private Point _pointB;
        private Rectangle _rectangle;

        public void SetPointA(Point point)
        {
            //_pointA = point;
        }

        public void SetPointB(Point point)
        {
            //_pointB = point;
        }

        public void SetPoints(Point pointA, Point pointB)
        {
            _rectangle = CalculateRectangle(pointA, pointB);
            AddDrawAction();
        }

        public void AddDrawAction()
        {
            var action = new DrawAction()
            {
                ShapeType = ShapeType.RECTANGLE,
                Shape = _rectangle,
                Brush = new SolidBrush(Color.Blue)
            };
            CommandHistory.AddAction(action);
        }

        public void DrawShape(DrawAction a, PaintEventArgs e)
        {
            e.Graphics.FillRectangle((System.Drawing.Brush)a.Brush, (Rectangle)a.Shape);
        }

        private Rectangle CalculateRectangle(Point pointA, Point pointB)
        {
            return Rectangle.FromLTRB(Math.Min(pointA.X, pointB.X), Math.Min(pointA.Y, pointB.Y),
                                      Math.Max(pointA.X, pointB.X), Math.Max(pointA.Y, pointB.Y));
        }
    }
}
