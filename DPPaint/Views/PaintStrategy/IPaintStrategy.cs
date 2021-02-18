using System.Drawing;

namespace DPPaint.Views.PaintStrategy
{
    public interface IPaintStrategy
    {
        void DrawShape(Graphics g, Point pointA, Point pointB);
    }
}
