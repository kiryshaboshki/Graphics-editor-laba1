using System.Collections.Generic;
using System.Windows.Controls;

namespace graphedit.Models.Commands
{
    public class CompositeCommand : ICommand
    {
        private List<ICommand> _commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void Execute(Canvas canvas)
        {
            foreach (var command in _commands)
            {
                command.Execute(canvas);
            }
        }

        public void Undo(Canvas canvas)
        {
            for (int i = _commands.Count - 1; i >= 0; i--)
            {
                _commands[i].Undo(canvas);
            }
        }

        public int CommandCount => _commands.Count;
    }
}