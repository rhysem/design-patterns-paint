using System.Drawing;

namespace DPPaint.Views.MoveCommand
{
    public interface IVisitableElement
    {
        public void AcceptVisitor(IVisitor visitor, Graphics g);
    }
}
