using System.Drawing;

using DPPaint.Models;
using DPPaint.Views.PaintStrategy;

namespace DPPaint.Views.DrawCommand
{
    public class DrawFilledInCommand : IDrawCommand
    {
        public void ExecuteDraw(Graphics g, DrawAction action)
        {
            var brush = new SolidBrush(action.PrimaryColor);
            switch (action.ShapeType)
            {
                case ShapeType.RECTANGLE:
                    g.FillRectangle(brush, (Rectangle)action.Shape);
                    break;
                case ShapeType.TRIANGLE:
                    g.FillPolygon(brush, TrianglePaintStrategy.CalculateTriangle((Rectangle)action.Shape));
                    break;
                case ShapeType.ELLIPSE:
                    g.FillEllipse(brush, (Rectangle)action.Shape);
                    break;
            }
        }
    }
}
