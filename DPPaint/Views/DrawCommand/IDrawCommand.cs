
using System.Drawing;

using DPPaint.Models;

namespace DPPaint.Views.DrawCommand
{
    public interface IDrawCommand
    {
        void ExecuteDraw(Graphics g, DrawAction action);
    }
}
