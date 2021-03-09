using System;
using System.Drawing;

using DPPaint.Models;
using DPPaint.Models.ApplicationState;
using DPPaint.Views.DrawCommand;

namespace DPPaint.Views.PaintStrategy
{
    public class RectanglePaintStrategy : IPaintStrategy
    {
        private Rectangle _rectangle;

        public void DrawShape(Graphics g, Point pointA, Point pointB)
        {
            _rectangle = CalculateRectangle(pointA, pointB);
            var action = AddDrawAction();
            action.DrawCommand.ExecuteDraw(g, action);
        }

        private DrawAction AddDrawAction()
        {
            var action = new DrawAction()
            {
                ShapeType = ShapeType.RECTANGLE,
                Shape = _rectangle,
                DrawCommand = GetDrawCommandType(),
                PrimaryColor = Color.FromName(Enum.GetName(typeof(ShapeColor), ApplicationState.GetApplicationState().GetActivePrimaryColor())),
                SecondaryColor = Color.FromName(Enum.GetName(typeof(ShapeColor), ApplicationState.GetApplicationState().GetActiveSecondaryColor())),
                Order = CommandHistory.GetShapes().Count
            };

            CommandHistory.AddShape(action);

            return action;
        }

        private Rectangle CalculateRectangle(Point pointA, Point pointB)
        {
            return Rectangle.FromLTRB(Math.Min(pointA.X, pointB.X), Math.Min(pointA.Y, pointB.Y),
                                      Math.Max(pointA.X, pointB.X), Math.Max(pointA.Y, pointB.Y));
        }

        private IDrawCommand GetDrawCommandType()
        {
            switch(ApplicationState.GetApplicationState().GetActiveShapeShadingType())
            {
                case ShapeShadingType.FILLED_IN:
                    return new DrawFilledInCommand();
                case ShapeShadingType.OUTLINE:
                    return new DrawOutlineCommand();
                case ShapeShadingType.OUTLINE_AND_FILLED_IN:
                    return new DrawOutlineAndFilledInCommand();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
