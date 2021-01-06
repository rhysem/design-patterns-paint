using DPPaint.Views.DrawCommand;

namespace DPPaint.Models
{
    public class DrawAction
    {
        public ShapeType ShapeType { get; set; }
        //public object Brush { get; set; }
        public object Shape { get; set; }
        public IDrawCommand DrawCommand { get; set; }

    }
}
