using System.Drawing;
using System.Windows.Forms;

using DPPaint.Models;

namespace DPPaint.Views.PaintStrategy
{
    public interface IPaintStrategy
    {
        void SetPoints(Point pointA, Point pointB);
        void DrawShape(DrawAction a, PaintEventArgs e);
    }
}
