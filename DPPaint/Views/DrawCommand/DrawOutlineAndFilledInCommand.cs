using System.Drawing;

using DPPaint.Models;

namespace DPPaint.Views.DrawCommand
{
    public class DrawOutlineAndFilledInCommand : IDrawCommand
    {
        public void ExecuteDraw(Graphics g, DrawAction action) 
        {
            var brush = new SolidBrush(action.PrimaryColor);
            var pen = new Pen(action.SecondaryColor);

            switch(action.ShapeType)
            {
                case ShapeType.RECTANGLE:
                    g.FillRectangle(brush, (Rectangle)action.Shape);
                    g.DrawRectangle(pen, (Rectangle)action.Shape);
                    break;
                case ShapeType.TRIANGLE:
                    g.FillPolygon(brush, (Point[])action.Shape);
                    g.DrawPolygon(pen, (Point[])action.Shape);
                    break;
                case ShapeType.ELLIPSE:
                    g.FillEllipse(brush, (Rectangle)action.Shape);
                    g.DrawEllipse(pen, (Rectangle)action.Shape);
                    break;
            }
        }
    }
}
