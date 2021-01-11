using System.Drawing;
using System.Windows.Forms;

using DPPaint.Models;

namespace DPPaint.Views.DrawCommand
{
    public class DrawFilledInCommand : IDrawCommand
    {
        public void ExecuteDraw(PaintEventArgs e, DrawAction action)
        {
            var brush = new SolidBrush(action.PrimaryColor);
            switch(action.ShapeType)
            {
                case ShapeType.RECTANGLE:
                    e.Graphics.FillRectangle(brush, (Rectangle)action.Shape);
                    break;
                case ShapeType.TRIANGLE:
                    e.Graphics.FillPolygon(brush, (Point[])action.Shape);
                    break;
                case ShapeType.ELLIPSE:
                    e.Graphics.FillEllipse(brush, (Rectangle)action.Shape);
                    break;
            }

        }
    }
}
