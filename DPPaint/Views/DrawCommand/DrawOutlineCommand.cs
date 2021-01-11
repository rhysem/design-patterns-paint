using System.Drawing;
using System.Windows.Forms;

using DPPaint.Models;

namespace DPPaint.Views.DrawCommand
{
    public class DrawOutlineCommand : IDrawCommand
    {
        public void ExecuteDraw(PaintEventArgs e, DrawAction action)
        {
            var pen = new Pen(action.PrimaryColor);

            switch (action.ShapeType)
            {
                case ShapeType.RECTANGLE:
                    e.Graphics.DrawRectangle(pen, (Rectangle)action.Shape);
                    break;
                case ShapeType.TRIANGLE:
                    e.Graphics.DrawPolygon(pen, (Point[])action.Shape);
                    break;
                case ShapeType.ELLIPSE:
                    e.Graphics.DrawEllipse(pen, (Rectangle)action.Shape);
                    break;
            }
        }
    }
}
