using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            //CommandHistory.Add(new CanvasMomento(CommandHistory.GetActions().Count, _canvas, ));
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


                    //Refresh();
                    break;
                case MouseMode.SELECT:
                    _moveVisitor = new MoveVisitor(); // when should selected shapes be cleared?

                    // calc bounding box
                    // foreach shape where [x, y] inside bounding box shape.Visit()
                    // calc which DrawActions should be Visited
                    // Visit() will populate IVisitor's _selectedShapes()

                    //foreach (DrawAction shape in CommandHistory.GetActions().Where(a => a.GetType() == typeof(DrawAction) && IsShapeSelected(((DrawAction)a).Shape)))
                    //{
                    //    shape.AcceptVisitor(_moveVisitor);
                    //}
             
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

                        // IVisitor -> _selectedShapes.Pos += delta(X, Y)
                        // move should NOT deselect shapes
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

        private bool IsShapeSelected(object shape)
        {
            return true; // TODO
        }
    }
}
