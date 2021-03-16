using System.Collections.Generic;
using System.Drawing;

using DPPaint.Models;
using DPPaint.Views.DrawCommand;

namespace DPPaint.Views.MoveCommand
{
    public class MoveVisitor : IVisitor
    {
        private List<DrawAction> _selectedShapes { get; set; }

        public MoveVisitor()
        {
            _selectedShapes = new List<DrawAction>();
        }

        public void Visit(DrawAction shape, Graphics g)
        {
            _selectedShapes.Add(shape);

            var currentShape = ((Rectangle)shape.Shape);

            var outlineCommand = new DrawDashedOutlineCommand();
            var outline = new DrawAction()
            {
                DrawCommand = outlineCommand,
                Order = -1,
                PrimaryColor = Color.Black,
                SecondaryColor = Color.White,
                Shape = new Rectangle(currentShape.X - 5, currentShape.Y - 5, currentShape.Width + 10, currentShape.Height + 10),
                ShapeType = shape.ShapeType
            };

            outline.DrawCommand.ExecuteDraw(g, outline);
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
