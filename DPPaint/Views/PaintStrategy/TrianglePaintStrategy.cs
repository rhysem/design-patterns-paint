using System;
using System.Drawing;
using System.Windows.Forms;

using DPPaint.Models;
using DPPaint.Views.DrawCommand;

namespace DPPaint.Views.PaintStrategy
{
    public class TrianglePaintStrategy : IPaintStrategy
    {
        private Point[] _triangle;

        public void SetPoints(Point pointA, Point pointB)
        {
            _triangle = CalculateTriangle(pointA, pointB);
            AddDrawAction();
        }

        public void AddDrawAction()
        {
            IDrawCommand drawCommand;

            // TODO

            drawCommand = new DrawFilledInCommand();

            var action = new DrawAction()
            {
                ShapeType = ShapeType.TRIANGLE,
                Shape = _triangle,
                DrawCommand = drawCommand
                //Brush = new SolidBrush(Color.Blue)
            };

            CommandHistory.AddAction(action);
        }

        private Point[] CalculateTriangle(Point pointA, Point pointB)
        {
            return new Point[] {
                new Point() { X = Math.Min(pointA.X, pointB.X) + (Math.Abs(pointA.X - pointB.X) / 2), Y = Math.Min(pointA.Y, pointB.Y)},
                new Point() { X = Math.Min(pointA.X, pointB.X), Y = Math.Max(pointA.Y, pointB.Y)},
                new Point() { X = Math.Max(pointA.X, pointB.X), Y = Math.Max(pointA.Y, pointB.Y)}
            };
        }

        public void DrawShape(DrawAction a, PaintEventArgs e)
        {
            a.DrawCommand.ExecuteDraw(e, a.ShapeType, a.Shape);
            //e.Graphics.FillPolygon((Brush)a.Brush, (Point[])a.Shape);
        }
    }
}
