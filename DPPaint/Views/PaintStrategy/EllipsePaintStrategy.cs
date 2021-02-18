using System;
using System.Drawing;

using DPPaint.Models;
using DPPaint.Models.ApplicationState;
using DPPaint.Views.DrawCommand;

namespace DPPaint.Views.PaintStrategy
{
    public class EllipsePaintStrategy : IPaintStrategy
    {
        private Rectangle _ellipse;

        public void SetPoints(Point pointA, Point pointB)
        {
            _ellipse = CalculateEllipseBounds(pointA, pointB);
            AddDrawAction();
        }

        public void DrawShape(Graphics g, Point pointA, Point pointB)
        {
            _ellipse = CalculateEllipseBounds(pointA, pointB);
            var action = AddDrawAction();
            action.DrawCommand.ExecuteDraw(g, action);
        }
        private DrawAction AddDrawAction()
        {
            var action = new DrawAction()
            {
                ShapeType = ShapeType.ELLIPSE,
                Shape = _ellipse,
                DrawCommand = GetDrawCommandType(),
                PrimaryColor = Color.FromName(Enum.GetName(typeof(ShapeColor), ApplicationState.GetApplicationState().GetActivePrimaryColor())),
                SecondaryColor = Color.FromName(Enum.GetName(typeof(ShapeColor), ApplicationState.GetApplicationState().GetActiveSecondaryColor())),
                Order = CommandHistory.GetActions().Count
            };

            CommandHistory.AddAction(action);

            return action;
        }

        private Rectangle CalculateEllipseBounds(Point pointA, Point pointB)
        {
            return Rectangle.FromLTRB(Math.Min(pointA.X, pointB.X), Math.Min(pointA.Y, pointB.Y),
                                      Math.Max(pointA.X, pointB.X), Math.Max(pointA.Y, pointB.Y));
        }

        private IDrawCommand GetDrawCommandType()
        {
            switch (ApplicationState.GetApplicationState().GetActiveShapeShadingType())
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
