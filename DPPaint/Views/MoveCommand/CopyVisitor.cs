using System;
using System.Collections.Generic;
using System.Drawing;

using DPPaint.Models;

namespace DPPaint.Views.MoveCommand
{
    public class CopyVisitor : IVisitor
    {
        private List<DrawAction> _copiedShapes { get; set; }

        public CopyVisitor()
        {
            _copiedShapes = new List<DrawAction>();
        }

        public List<DrawAction> GetSelectedShapes()
        {
            return _copiedShapes;
        }

        public void UpdateSelectedShape(DrawAction originalShape, DrawAction newShape)
        {
            throw new NotImplementedException();
        }

        public void Visit(DrawAction shape, Graphics g)
        {
            _copiedShapes.Add(shape);
        }
    }
}
