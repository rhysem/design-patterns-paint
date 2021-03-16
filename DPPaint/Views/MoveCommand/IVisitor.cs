using System.Collections.Generic;
using System.Drawing;

using DPPaint.Models;

namespace DPPaint.Views.MoveCommand
{
    public interface IVisitor
    {
        public void Visit(DrawAction shape, Graphics g);
        List<DrawAction> GetSelectedShapes();
        void UpdateSelectedShape(DrawAction originalShape, DrawAction newShape);
    }
}
