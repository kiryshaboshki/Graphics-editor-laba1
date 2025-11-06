using System.Collections.Generic;
using System.Windows.Controls;

namespace graphedit.Models.Commands
{
    public class UndoRedoManager
    {
        private Stack<ICommand> _undoStack = new Stack<ICommand>();
        private Stack<ICommand> _redoStack = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command, Canvas canvas)
        {
            command.Execute(canvas);
            _undoStack.Push(command);
            _redoStack.Clear();
        }

        public void Undo(Canvas canvas)
        {
            if (_undoStack.Count > 0)
            {
                var command = _undoStack.Pop();
                command.Undo(canvas);
                _redoStack.Push(command);
            }
        }

        public void Redo(Canvas canvas)
        {
            if (_redoStack.Count > 0)
            {
                var command = _redoStack.Pop();
                command.Execute(canvas);
                _undoStack.Push(command);
            }
        }

        public bool CanUndo => _undoStack.Count > 0;
        public bool CanRedo => _redoStack.Count > 0;

        public void Clear()
        {
            _undoStack.Clear();
            _redoStack.Clear();
        }
    }
}