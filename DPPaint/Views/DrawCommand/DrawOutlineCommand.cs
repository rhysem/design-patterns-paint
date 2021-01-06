using System.Drawing;
using System.Windows.Forms;

using DPPaint.Models;

namespace DPPaint.Views.DrawCommand
{
    public class DrawOutlineCommand : IDrawCommand
    {
        public void ExecuteDraw(PaintEventArgs e, ShapeType shapeType, object shape)
        {
            var pen = new Pen(Color.Blue); // primary color
            e.Graphics.DrawRectangle(pen, (Rectangle)shape);
        }
    }
}
