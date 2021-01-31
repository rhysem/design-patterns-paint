using System.Collections.Generic;

namespace DPPaint.Views.MoveCommand
{
    public class MoveVisitor : IVisitor
    {
        private List<object> _selectedShapes { get; set; }

        public MoveVisitor()
        { }

        public void Visit(object shape)
        {
            _selectedShapes.Add(shape);
        }

        public List<object> GetSelectedShapes()
        {
            return _selectedShapes;
        }
    }
}
