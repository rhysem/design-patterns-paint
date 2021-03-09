using System.Collections.Generic;

using DPPaint.Models;

namespace DPPaint.Views.MoveCommand
{
    public class MoveVisitor : IVisitor
    {
        private List<DrawAction> _selectedShapes { get; set; }

        public MoveVisitor()
        {
            _selectedShapes = new List<DrawAction>();
        }

        public void Visit(DrawAction shape)
        {
            _selectedShapes.Add(shape);
        }

        public List<DrawAction> GetSelectedShapes()
        {
            return _selectedShapes;
        }

        public void UpdateSelectedShape(DrawAction originalShape, DrawAction newShape)
        {
            var indexToUpdate = _selectedShapes.FindIndex(s => s.Equals(originalShape));
            _selectedShapes.RemoveAt(indexToUpdate);
            _selectedShapes.Insert(indexToUpdate, newShape);
        }
    }
}
