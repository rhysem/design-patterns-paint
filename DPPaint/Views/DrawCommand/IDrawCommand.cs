using System.Windows.Forms;

using DPPaint.Models;

namespace DPPaint.Views.DrawCommand
{
    public interface IDrawCommand
    {
        void ExecuteDraw(PaintEventArgs e, ShapeType shapeType, object shape);
    }
}
