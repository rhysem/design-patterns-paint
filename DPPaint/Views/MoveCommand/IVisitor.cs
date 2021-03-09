using System.Collections.Generic;

using DPPaint.Models;

namespace DPPaint.Views.MoveCommand
{
    public interface IVisitor
    {
        public void Visit(DrawAction shape);
        List<DrawAction> GetSelectedShapes();
        void UpdateSelectedShape(DrawAction originalShape, DrawAction newShape);
    }
}
