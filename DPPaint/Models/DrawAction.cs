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
        public int Order { get; set; }
        public void AcceptVisitor(IVisitor visitor, Graphics g)
        {
            visitor.Visit(this);

            var currentShape = ((Rectangle)this.Shape);

            var outlineCommand = new DrawDashedOutlineCommand();
            var outline = new DrawAction()
            {
                DrawCommand = outlineCommand,
                Order = -1,
                PrimaryColor = Color.Black,
                SecondaryColor = Color.White,
                Shape = new Rectangle(currentShape.X - 5, currentShape.Y - 5, currentShape.Width + 10, currentShape.Height + 10),
                ShapeType = this.ShapeType
            };
            outline.DrawCommand.ExecuteDraw(g, outline);
        }
    }
}
