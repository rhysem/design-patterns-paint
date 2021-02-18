using System.Collections.Generic;

using DPPaint.Models;

namespace DPPaint
{
    public class CommandHistory
    {
        private static CommandHistory _commandHistory;
        private static readonly object historyLock = new object();
        private static Stack<Action> _undoStack = new Stack<Action>();
        private static Stack<Action> _redoStack = new Stack<Action>();

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

        public static void AddAction(Action action)
        {
            _undoStack.Push(action);
        }

        public static Stack<Action> GetActions()
        {
            return _undoStack;
        }

        //public static Queue<Action> GetActions()
        //{
        //    var stack = new Stack<Action>(_undoStack);
        //    var queue = new Queue<Action>();
        //    while(stack.Count > 0)
        //    {
        //        var o = stack.Pop();
        //        queue.Enqueue(o);
        //    }

        //    return queue;
        //}

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
