using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace graphedit.Models //
{
    public class UIManager(Button[] tools,
                     Button[] colors)
    {
        private readonly Button[] toolButtons = tools;
        private readonly Button[] colorButtons = colors;
        private Button? lastActiveColor;

        public void HighlightToolButton(Button activeButton)
        {
            foreach (var button in toolButtons)
            {
                button.Background = Brushes.LightGray;
                button.BorderBrush = Brushes.DarkGray;
                button.BorderThickness = new Thickness(1);
            }

            activeButton.Background = Brushes.LightBlue;
            activeButton.BorderBrush = Brushes.DarkBlue;
            activeButton.BorderThickness = new Thickness(2);

        }

        public void HighlightColorButton(Button activeColorButton)
        {
            foreach (var button in colorButtons)
            {
                if (button.Background == Brushes.White)
                    button.BorderBrush = Brushes.LightGray;
                else
                    button.BorderBrush = Brushes.Transparent;
            }

            activeColorButton.BorderBrush = Brushes.White;
            activeColorButton.BorderThickness = new Thickness(2);

            lastActiveColor = activeColorButton;
        }

        public Brush GetActiveColor()
        {
            return lastActiveColor?.Background ?? Brushes.Black;
        }
    }
}
