using System.Windows.Controls;

namespace graphedit.Models.Commands
{
    public interface ICommand
    {
        void Execute(Canvas canvas);
        void Undo(Canvas canvas);
    }
}