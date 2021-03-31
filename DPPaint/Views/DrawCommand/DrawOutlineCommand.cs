using System.Drawing;

using DPPaint.Models;
using DPPaint.Views.PaintStrategy;

namespace DPPaint.Views.DrawCommand
{
    public class DrawOutlineCommand : IDrawCommand
    {
        public void ExecuteDraw(Graphics g, DrawAction action)
        {
            var pen = new Pen(action.PrimaryColor);

            switch (action.ShapeType)
            {
                case ShapeType.RECTANGLE:
                    g.DrawRectangle(pen, (Rectangle)action.Shape);
                    break;
                case ShapeType.TRIANGLE:
                    g.DrawPolygon(pen, TrianglePaintStrategy.CalculateTriangle((Rectangle)action.Shape));
                    break;
                case ShapeType.ELLIPSE:
                    g.DrawEllipse(pen, (Rectangle)action.Shape);
                    break;
            }
        }
    }
}
