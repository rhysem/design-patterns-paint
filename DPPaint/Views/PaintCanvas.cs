using System;
using System.Drawing;
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
        private Bitmap _canvas;
        protected Point _pointA;
        protected Point _pointB;

        public PaintCanvas()
        {
            MouseDown += new MouseEventHandler(canvas_MouseDown);
            MouseUp += new MouseEventHandler(canvas_MouseUp);
            _paintStrategy = new RectanglePaintStrategy(); // default
            //_canvas = new Bitmap(this.Width, this.Height); 
        }

        public void SetDimensions(int height, int width, int top)
        {
            Height = height;
            Width = width;
            Top = top;
            _canvas = new Bitmap(width, height);
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
                    }
                    //using (Bitmap temp = new Bitmap(_canvas))
                    //{
                    //    using (Graphics g = Graphics.FromImage(temp))
                    //    {
                    //        g.FillRectangle(new SolidBrush(Color.Red), Rectangle.FromLTRB(100, 100, 100, 100));
                    //        _paintStrategy.DrawShape(g, _pointA, _pointB);
                    //    }
                    //}

                    Invalidate();
                    //Refresh();
                    break;
                case MouseMode.SELECT:
                    _moveVisitor = new MoveVisitor(); // when should selected shapes be cleared?

                    // calc bounding box
                    // foreach shape where [x, y] inside bounding box shape.Visit()
                    // calc which DrawActions should be Visited
                    // Visit() will populate IVisitor's _selectedShapes()

                    foreach (DrawAction shape in CommandHistory.GetActions().Where(a => a.GetType() == typeof(DrawAction) && IsShapeSelected(((DrawAction)a).Shape)))
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
            //var actions = CommandHistory.GetActions();
            //for (int i = 0; i < actions.Count; i++)
            //{
            //    var a = actions.ElementAt(i);

            //    if (a.GetType() == typeof(DrawAction))
            //    {
            //        // set paint strategy based on type of 'a'
            //        SetPaintStrategy(((DrawAction)a).ShapeType);
            //        // draw shape
            //        _paintStrategy.DrawShape(((DrawAction)a), e);
            //    }
            //    else if (a.GetType() == typeof(MoveAction))
            //    {
            //        // TODO
            //    }
            //}

            //while (actions.Count > 0)
            //{
            //    var a = actions.Dequeue();

            //    if (a.GetType() == typeof(DrawAction))
            //    {
            //        // set paint strategy based on type of 'a'
            //        SetPaintStrategy(((DrawAction)a).ShapeType);
            //        // draw shape
            //        _paintStrategy.DrawShape(((DrawAction)a), e);
            //    }
            //    else if (a.GetType() == typeof(MoveAction)) { 
            //    }
            //}

        }

        public void Undo()
        {
            CommandHistory.Undo();
            Refresh();
        }

        public void Redo()
        {
            CommandHistory.Redo();
            Refresh();
        }

        private bool IsShapeSelected(object shape)
        {
            return true; // TODO
        }
    }
}
