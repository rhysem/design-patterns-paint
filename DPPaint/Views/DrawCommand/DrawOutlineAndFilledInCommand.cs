using System.Drawing;
using System.Windows.Forms;

using DPPaint.Models;

namespace DPPaint.Views.DrawCommand
{
    public class DrawOutlineAndFilledInCommand : IDrawCommand
    {
        public void ExecuteDraw(PaintEventArgs e, DrawAction action) 
        {
            var brush = new SolidBrush(action.PrimaryColor);
            var pen = new Pen(action.SecondaryColor);

            switch(action.ShapeType)
            {
                case ShapeType.RECTANGLE:
                    e.Graphics.FillRectangle(brush, (Rectangle)action.Shape);
                    e.Graphics.DrawRectangle(pen, (Rectangle)action.Shape);
                    break;
                case ShapeType.TRIANGLE:
                    e.Graphics.FillPolygon(brush, (Point[])action.Shape);
                    e.Graphics.DrawPolygon(pen, (Point[])action.Shape);
                    break;
                case ShapeType.ELLIPSE:
                    e.Graphics.FillEllipse(brush, (Rectangle)action.Shape);
                    e.Graphics.DrawEllipse(pen, (Rectangle)action.Shape);
                    break;
            }
        }
    }
}
