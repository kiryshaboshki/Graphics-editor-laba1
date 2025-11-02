using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace graphedit.Models
{
    public class EraserTool : DrawingTool
    {
        public override void OnMouseDown(Point point, Canvas canvas, Brush brush, double brushSize)
        {
            LastPoint = point;
        }

        public override void OnMouseMove(Point point, Canvas canvas, Brush brush, double brushSize)
        {
            if (LastPoint == default) return;

            Line line = new Line
            {
                X1 = LastPoint.X,
                Y1 = LastPoint.Y,
                X2 = point.X,
                Y2 = point.Y,
                Stroke = Brushes.White,
                StrokeThickness = brushSize
            };

            canvas.Children.Add(line);
            LastPoint = point;
        }

        public override void OnMouseUp(Point point, Canvas canvas, Brush brush, double brushSize)
        {
            LastPoint = default;
        }
    }
}