using System;
using System.Drawing;

using DPPaint.Models;
using DPPaint.Models.ApplicationState;
using DPPaint.Views.DrawCommand;

namespace DPPaint.Views.PaintStrategy
{
    public class TrianglePaintStrategy : IPaintStrategy
    {
        //private Point[] _triangle;
        private Rectangle _triangle;

        public void SetPoints(Point pointA, Point pointB)
        {
            _triangle = CalculateTriangleBounds(pointA, pointB);
            //_triangle = CalculateTriangle(pointA, pointB);
            AddDrawAction();
        }
       
        public void DrawShape(Graphics g, Point pointA, Point pointB)
        {
            _triangle = CalculateTriangleBounds(pointA, pointB);
            var action = AddDrawAction();
            action.DrawCommand.ExecuteDraw(g, action);
        }

        private Rectangle CalculateTriangleBounds(Point pointA, Point pointB)
        {
            return Rectangle.FromLTRB(Math.Min(pointA.X, pointB.X), Math.Min(pointA.Y, pointB.Y),
                                        Math.Max(pointA.X, pointB.X), Math.Max(pointA.Y, pointB.Y));
        }

        private DrawAction AddDrawAction()
        {
            var action = new DrawAction()
            {
                ShapeType = ShapeType.TRIANGLE,
                Shape = _triangle,
                DrawCommand = GetDrawCommandType(),
                PrimaryColor = Color.FromName(Enum.GetName(typeof(ShapeColor), ApplicationState.GetApplicationState().GetActivePrimaryColor())),
                SecondaryColor = Color.FromName(Enum.GetName(typeof(ShapeColor), ApplicationState.GetApplicationState().GetActiveSecondaryColor())),
                Order = CommandHistory.GetActions().Count
            };

            CommandHistory.AddAction(action);

            return action;
        }

        //private Point[] CalculateTriangle(Point pointA, Point pointB)
        //{
        //    return new Point[] {
        //        new Point() { X = Math.Min(pointA.X, pointB.X) + (Math.Abs(pointA.X - pointB.X) / 2), Y = Math.Min(pointA.Y, pointB.Y)},
        //        new Point() { X = Math.Min(pointA.X, pointB.X), Y = Math.Max(pointA.Y, pointB.Y)},
        //        new Point() { X = Math.Max(pointA.X, pointB.X), Y = Math.Max(pointA.Y, pointB.Y)}
        //    };
        //}


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
