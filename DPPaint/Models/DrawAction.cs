using System.Drawing;

using DPPaint.Views.DrawCommand;
using DPPaint.Views.MoveCommand;

namespace DPPaint.Models
{
    public class DrawAction : Action, IVisitableElement
    {
        public ShapeType ShapeType { get; set; }
        public object Shape { get; set; }
        public Color PrimaryColor { get; set; }
        public Color SecondaryColor { get; set; }
        public IDrawCommand DrawCommand { get; set; }
        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.Visit(Shape);
        }
    }
}
