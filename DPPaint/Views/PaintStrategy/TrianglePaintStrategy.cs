using System;
using System.Drawing;
using System.Windows.Forms;

using DPPaint.Models;
using DPPaint.Models.ApplicationState;
using DPPaint.Views.DrawCommand;

namespace DPPaint.Views.PaintStrategy
{
    public class TrianglePaintStrategy : IPaintStrategy
    {
        private Point[] _triangle;

        public void SetPoints(Point pointA, Point pointB)
        {
            _triangle = CalculateTriangle(pointA, pointB);
            AddDrawAction();
        }

        public void AddDrawAction()
        {
            var action = new DrawAction()
            {
                ShapeType = ShapeType.TRIANGLE,
                Shape = _triangle,
                DrawCommand = GetDrawCommandType(),
                PrimaryColor = Color.FromName(Enum.GetName(typeof(ShapeColor), ApplicationState.GetApplicationState().GetActivePrimaryColor())),
                SecondaryColor = Color.FromName(Enum.GetName(typeof(ShapeColor), ApplicationState.GetApplicationState().GetActiveSecondaryColor())),
            };

            CommandHistory.AddAction(action);
        }

        private Point[] CalculateTriangle(Point pointA, Point pointB)
        {
            return new Point[] {
                new Point() { X = Math.Min(pointA.X, pointB.X) + (Math.Abs(pointA.X - pointB.X) / 2), Y = Math.Min(pointA.Y, pointB.Y)},
                new Point() { X = Math.Min(pointA.X, pointB.X), Y = Math.Max(pointA.Y, pointB.Y)},
                new Point() { X = Math.Max(pointA.X, pointB.X), Y = Math.Max(pointA.Y, pointB.Y)}
            };
        }

        public void DrawShape(DrawAction a, PaintEventArgs e)
        {
            a.DrawCommand.ExecuteDraw(e, a);
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
