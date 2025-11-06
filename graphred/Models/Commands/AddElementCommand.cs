using System.Windows;
using System.Windows.Controls;

namespace graphedit.Models.Commands
{
    public class AddElementCommand : ICommand
    {
        private UIElement _element;
        private Canvas _canvas;

        public AddElementCommand(UIElement element, Canvas canvas)
        {
            _element = element;
            _canvas = canvas;
        }

        public void Execute(Canvas canvas)
        {
            if (!canvas.Children.Contains(_element))
            {
                canvas.Children.Add(_element);
            }
        }

        public void Undo(Canvas canvas)
        {
            if (canvas.Children.Contains(_element))
            {
                canvas.Children.Remove(_element);
            }
        }
    }
}