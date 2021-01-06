using System.Drawing;
using System.Windows.Forms;

using DPPaint.Models;

namespace DPPaint.Views.DrawCommand
{
    public class DrawOutlineAndFilledInCommand : IDrawCommand
    {
        public void ExecuteDraw(PaintEventArgs e, ShapeType shapeType, object shape) 
        {
            var brush = new SolidBrush(Color.Blue); // primary color
            var pen = new Pen(Color.Black); // secondary color
            e.Graphics.FillRectangle(brush, (Rectangle)shape);
            e.Graphics.DrawRectangle(pen, (Rectangle)shape);
        }
    }
}
