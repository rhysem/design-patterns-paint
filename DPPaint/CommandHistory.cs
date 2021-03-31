using System.Collections.Generic;
using System.Linq;

using DPPaint.Models;

namespace DPPaint
{
    public class CommandHistory
    {
        private static CommandHistory _commandHistory;
        private static readonly object historyLock = new object();

        private static Stack<CanvasMomento> _undoStack = new Stack<CanvasMomento>();
        private static Stack<CanvasMomento> _redoStack = new Stack<CanvasMomento>();

        private static Stack<DrawAction> _undoShapeStack = new Stack<DrawAction>();
        private static Stack<DrawAction> _redoShapeStack = new Stack<DrawAction>();

        private CommandHistory()
        { }

        public static CommandHistory GetCommandHistoryInstance()
        {
            lock(historyLock)
            {
                if (_commandHistory == null)
                {
                    _commandHistory = new CommandHistory();
                }

                return _commandHistory;
            }
        }

        public static void AddShape(DrawAction action)
        {
            _undoShapeStack.Push(action);
        }

        public static void Add(CanvasMomento momento)
        {
            _undoStack.Push(momento);
        }

        public static Stack<CanvasMomento> GetActions()
        {
            return _undoStack;
        }

        public static Queue<DrawAction> GetShapes()
        {
            var stack = new Stack<DrawAction>(_undoShapeStack);
            var queue = new Queue<DrawAction>();
            while (stack.Count > 0)
            {
                var o = stack.Pop();
                queue.Enqueue(o);
            }

            return queue;
        }

        public static void RemoveAllShapes()
        {
            _undoShapeStack.Clear();
        }

        public static void RemoveShape(DrawAction shape)
        {
            if (!_undoShapeStack.Contains(shape))
            {
                return;
            }

            _undoShapeStack = new Stack<DrawAction>(_undoShapeStack.Where(s => !s.Equals(shape)));
        }

        public static CanvasMomento Undo()
        {
            var result = _undoStack.Count > 0;
            if (result)
            {
                var p = _undoStack.Pop();
                _redoStack.Push(p);

                var s = _undoShapeStack.Pop();
                _redoShapeStack.Push(s);
                // p.undo
            }
            return _undoStack.Peek();
        }

        public static CanvasMomento Redo()
        {
            var result = _redoStack.Count > 0;
            var p = new CanvasMomento(-1, null, null);
            if (result)
            {
                p = _redoStack.Pop();
                _undoStack.Push(p);

                var s = _redoShapeStack.Pop();
                _undoShapeStack.Push(s);

                // p.undo
            }

            return p;
        }
    }
}
