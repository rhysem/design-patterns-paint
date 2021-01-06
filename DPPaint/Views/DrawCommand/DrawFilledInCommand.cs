using System.Drawing;
using System.Windows.Forms;

using DPPaint.Models;

namespace DPPaint.Views.DrawCommand
{
    public class DrawFilledInCommand : IDrawCommand
    {
        public void ExecuteDraw(PaintEventArgs e, ShapeType shapeType, object shape)
        {
            // TODO - handle ALL shapes
            var brush = new SolidBrush(Color.Blue); // primary color - TODO - handle ALL colors
            e.Graphics.FillRectangle(brush, (Rectangle)shape); //TODO handle ALL shapes
        }
    }
}
