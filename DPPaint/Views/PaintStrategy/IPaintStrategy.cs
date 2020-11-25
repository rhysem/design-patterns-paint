using System.Drawing;
using System.Windows.Forms;

namespace DPPaint.Views.PaintStrategy
{
    public interface IPaintStrategy
    {
        void SetPointA(Point point);
        void SetPointB(Point point);
        void DrawShape(PaintEventArgs e);
    }
}
