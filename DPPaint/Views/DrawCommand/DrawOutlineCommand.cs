using System.Drawing;

using DPPaint.Models;

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
                    g.DrawPolygon(pen, (Point[])action.Shape);
                    break;
                case ShapeType.ELLIPSE:
                    g.DrawEllipse(pen, (Rectangle)action.Shape);
                    break;
            }
        }
    }
}
