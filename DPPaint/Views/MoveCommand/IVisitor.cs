using System.Collections.Generic;

namespace DPPaint.Views.MoveCommand
{
    public interface IVisitor
    {
        public void Visit(object shape);
        List<object> GetSelectedShapes();
    }
}
