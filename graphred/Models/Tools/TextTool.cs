using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace graphedit.Models.Tools
{
    public class TextTool : DrawingTool 
    {
        public override void OnMouseDown(Point point, Canvas canvas, Brush brush, double brushSize)
        {
            TextBox textBox = new TextBox
            {
                Width = 200,
                Height = 30,
                FontSize = brushSize * 3,
                Foreground = brush,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(1)
            };

            Canvas.SetLeft(textBox, point.X);
            Canvas.SetTop(textBox, point.Y);

            canvas.Children.Add(textBox);
            textBox.Focus();
        }

        public override void OnMouseMove(Point point, Canvas canvas, Brush brush, double brushSize)
        {

        }

        public override void OnMouseUp(Point point, Canvas canvas, Brush brush, double brushSize)
        {

        }
    }
    
}