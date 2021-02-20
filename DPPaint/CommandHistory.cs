using System.Collections.Generic;

using DPPaint.Models;

namespace DPPaint
{
    public class CommandHistory
    {
        private static CommandHistory _commandHistory;
        private static readonly object historyLock = new object();

        private static Stack<CanvasMomento> _undoStack = new Stack<CanvasMomento>();
        private static Stack<CanvasMomento> _redoStack = new Stack<CanvasMomento>();

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

        public static void Add(CanvasMomento momento)
        {
            _undoStack.Push(momento);
        }

        public static Stack<CanvasMomento> GetActions()
        {
            return _undoStack;
        }

        public static CanvasMomento Undo()
        {
            var result = _undoStack.Count > 0;
            if (result)
            {
                var p = _undoStack.Pop();
                _redoStack.Push(p);
                // p.undo
            }
            return _undoStack.Peek();
        }

        public static CanvasMomento Redo()
        {
            var result = _redoStack.Count > 0;
            if (result)
            {
                var p = _redoStack.Pop();
                _undoStack.Push(p);
                // p.undo
            }
            return _redoStack.Peek();
        }
    }
}
