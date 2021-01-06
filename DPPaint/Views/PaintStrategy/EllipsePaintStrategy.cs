using System;
using System.Drawing;
using System.Windows.Forms;

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

        public void AddDrawAction()
        {
            var action = new DrawAction()
            {
                ShapeType = ShapeType.ELLIPSE,
                Shape = _ellipse,
                DrawCommand = GetDrawCommandType(),
                PrimaryColor = Color.FromName(Enum.GetName(typeof(ShapeColor), ApplicationState.GetApplicationState().GetActivePrimaryColor())),
                SecondaryColor = Color.FromName(Enum.GetName(typeof(ShapeColor), ApplicationState.GetApplicationState().GetActiveSecondaryColor())),
            };  

            CommandHistory.AddAction(action);
        }

        public void DrawShape(DrawAction a, PaintEventArgs e)
        {
            a.DrawCommand.ExecuteDraw(e, a);
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
