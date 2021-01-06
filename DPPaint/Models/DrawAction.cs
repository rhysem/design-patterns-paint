using System.Drawing;

using DPPaint.Views.DrawCommand;

namespace DPPaint.Models
{
    public class DrawAction
    {
        public ShapeType ShapeType { get; set; }
        public object Shape { get; set; }
        public Color PrimaryColor { get; set; }
        public Color SecondaryColor { get; set; }
        public IDrawCommand DrawCommand { get; set; }
    }
}
