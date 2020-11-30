using System.Collections.Generic;

using DPPaint.Models;

namespace DPPaint
{
    public class CommandHistory
    {
        private static CommandHistory _commandHistory;
        private static readonly object historyLock = new object();
        private static Stack<DrawAction> _undoStack = new Stack<DrawAction>();
        private static Stack<DrawAction> _redoStack = new Stack<DrawAction>();

        private CommandHistory()
        {
        }

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

        public static void AddAction(DrawAction action)
        {
            _undoStack.Push(action);
        }

        public static Queue<DrawAction> GetActions()
        {
            var stack = new Stack<DrawAction>(_undoStack);
            var queue = new Queue<DrawAction>();
            while(stack.Count > 0)
            {
                var o = stack.Pop();
                queue.Enqueue(o);
            }

            return queue;
        }

        public static bool Undo()
        {
            var result = _undoStack.Count > 0;
            if (result)
            {
                var p = _undoStack.Pop();
                _redoStack.Push(p);
                // p.undo
            }
            return result;
        }

        public static bool Redo()
        {
            var result = _redoStack.Count > 0;
            if (result)
            {
                var p = _redoStack.Pop();
                _undoStack.Push(p);
                // p.undo
            }
            return result;
        }
    }
}
