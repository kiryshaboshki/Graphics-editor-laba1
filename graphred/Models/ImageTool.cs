using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace graphedit.Models
{
    public class ImageTool : DrawingTool
    {
        public override void OnMouseDown(Point point, Canvas canvas, Brush brush, double brushSize)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                Image image = new Image();
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));

                image.Source = bitmap;
                image.Width = 200;
                image.Height = 200;

                Canvas.SetLeft(image, point.X);
                Canvas.SetTop(image, point.Y);

                canvas.Children.Add(image);
            }
        }
        public override void OnMouseMove(Point point, Canvas canvas, Brush brush, double brushSize)
        {

        }

        public override void OnMouseUp(Point point, Canvas canvas, Brush brush, double brushSize)
        {

        }
    }
}
