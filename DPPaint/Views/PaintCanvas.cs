using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using DPPaint.Models;
using DPPaint.Models.ApplicationState;
using DPPaint.Views.MoveCommand;
using DPPaint.Views.PaintStrategy;

namespace DPPaint
{
    public class PaintCanvas : Control
    {
        private static IPaintStrategy _paintStrategy;
        private IVisitor _moveVisitor;
        private ApplicationState _applicationState;
        private Image _canvas;
        protected Point _pointA;
        protected Point _pointB;

        public PaintCanvas()
        {
            MouseDown += new MouseEventHandler(canvas_MouseDown);
            MouseUp += new MouseEventHandler(canvas_MouseUp);
            _paintStrategy = new RectanglePaintStrategy(); // default
        }

        public void Initialize(int height, int width, int top)
        {
            Height = height;
            Width = width;
            Top = top;
            _canvas = new Bitmap(width, height);
            using (var ms = new MemoryStream()) // TODO extract
            {
                _canvas.Save(ms, ImageFormat.Png);
                CommandHistory.Add(new CanvasMomento(CommandHistory.GetActions().Count, _canvas, ms.ToArray()));

            }
        }

        public static void SetPaintStrategy(ShapeType shapeType)
        {
            switch(shapeType)
            {
                case ShapeType.RECTANGLE:
                    _paintStrategy = new RectanglePaintStrategy();
                    break;
                case ShapeType.ELLIPSE:
                    _paintStrategy = new EllipsePaintStrategy();
                    break;
                case ShapeType.TRIANGLE:
                    _paintStrategy = new TrianglePaintStrategy();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        protected void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            _pointA = new Point(e.X, e.Y);
        }

        protected void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (_paintStrategy == null)
            {
                throw new Exception("Oops!"); // TODO
            }

            _pointB = new Point(e.X, e.Y);
            //SetPaintStrategy(appState.GetActiveShapeType());
            if(_applicationState == null)
            {
                _applicationState = ApplicationState.GetApplicationState();
            }

            switch(_applicationState.GetActiveMouseMode())
            {
                case MouseMode.DRAW:
                    using (Graphics g = Graphics.FromImage(_canvas))
                    {
                        _paintStrategy.DrawShape(g, _pointA, _pointB);

                        using (var ms = new MemoryStream())
                        {
                            _canvas.Save(ms, ImageFormat.Png);
                            CommandHistory.Add(new CanvasMomento(CommandHistory.GetActions().Count, _canvas, ms.ToArray()));

                        }
                    }

                    Invalidate();

                    break;
                case MouseMode.SELECT:
                    _moveVisitor = new MoveVisitor(); // when should selected shapes be cleared?

                    foreach (var shape in CommandHistory.GetShapes().Where(a => IsShapeSelected((a).Shape, _pointA, _pointB)))
                    {
                        shape.AcceptVisitor(_moveVisitor);
                    }

                    break;

                case MouseMode.MOVE:
                    if (_moveVisitor == null || _moveVisitor.GetSelectedShapes().Count == 0)
                    {
                        // do nothing
                        // should this throw error? what does MSPaint do?
                    }

                    else
                    {
                        // move selected shapes
                        var deltaX = _pointB.X - _pointA.X;
                        var deltaY = _pointB.Y - _pointA.Y;

                        _canvas = new Bitmap(_canvas.Width, _canvas.Height);
                        using (Graphics g = Graphics.FromImage(_canvas))
                        {
                            var shapes = CommandHistory.GetShapes();
                            CommandHistory.RemoveAllShapes();

                            foreach (var shape in shapes) // TODO - verify returns IN ORDER
                            {
                                SetPaintStrategy(shape.ShapeType);

                                var rect = (Rectangle)shape.Shape;
                                var pointA = new Point(rect.X, rect.Y); // TODO - move to strategy
                                var pointB = new Point(rect.X + rect.Width, rect.Y + rect.Height);

                                var selectedShapes = _moveVisitor.GetSelectedShapes();

                                if (selectedShapes.Contains(shape))
                                {
                                    var movedPointA = new Point(pointA.X + deltaX, pointA.Y + deltaY);
                                    var movedPointB = new Point(pointB.X + deltaX, pointB.Y + deltaY);

                                    _paintStrategy.DrawShape(g, movedPointA, movedPointB);
                                    _moveVisitor.UpdateSelectedShape(shape, CommandHistory.GetShapes().Last());
                                }
                                else
                                {
                                    _paintStrategy.DrawShape(g, pointA, pointB);
                                }
                            }

                            using (var ms = new MemoryStream())
                            {
                                _canvas.Save(ms, ImageFormat.Png);
                                CommandHistory.Add(new CanvasMomento(CommandHistory.GetActions().Count, _canvas, ms.ToArray()));
                            }

                            Refresh();
                        }
                    }

                    break;
                default:
                    throw new ArgumentException("Invalid mouse mode!");
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawImage(_canvas, 0, 0);
        }

        public void Undo()
        {
            var bytes = CommandHistory.Undo().GetSnapshotBytes();
            using (var ms = new MemoryStream(bytes))
            {
                _canvas = (Bitmap)Image.FromStream(ms);
            }
            Refresh();
        }

        public void Redo()
        {
            var bytes = CommandHistory.Redo().GetSnapshotBytes();
            using (var ms = new MemoryStream(bytes))
            {
                _canvas = (Bitmap)Image.FromStream(ms);
            }
            Refresh();
        }

        private bool IsShapeSelected(object shape, Point pointA, Point pointB)
        {
            var bounds = Rectangle.FromLTRB(Math.Min(pointA.X, pointB.X), Math.Min(pointA.Y, pointB.Y),
                                   Math.Max(pointA.X, pointB.X), Math.Max(pointA.Y, pointB.Y));

            return bounds.IntersectsWith((Rectangle)shape);
        }
    }
}
