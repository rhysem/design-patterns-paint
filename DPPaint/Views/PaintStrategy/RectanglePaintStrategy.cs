using System;
using System.Drawing;
using System.Windows.Forms;

namespace DPPaint.Views.PaintStrategy
{
    public class RectanglePaintStrategy : IPaintStrategy
    {
        private Point _pointA;
        private Point _pointB;

        public void SetPointA(Point point)
        {
            _pointA = point;
        }

        public void SetPointB(Point point)
        {
            _pointB = point;
        }

        public void DrawShape(PaintEventArgs e)
        {
            var brush = new SolidBrush(Color.Blue);
            e.Graphics.FillRectangle(brush, CalculateRectangle());
        }

        private Rectangle CalculateRectangle()
        {
            return Rectangle.FromLTRB(Math.Min(_pointA.X, _pointB.X), Math.Min(_pointA.Y, _pointB.Y),
                                      Math.Max(_pointA.X, _pointB.X), Math.Max(_pointA.Y, _pointB.Y));
        }
    }
}
