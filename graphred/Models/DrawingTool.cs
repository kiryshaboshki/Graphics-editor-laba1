using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace graphedit.Models
{
    public abstract class DrawingTool
    {
        public abstract void OnMouseDown(Point point, Canvas canvas, Brush brush, double brushSize);
        public abstract void OnMouseMove(Point point, Canvas canvas, Brush brush, double brushSize);
        public abstract void OnMouseUp(Point point, Canvas canvas, Brush brush, double brushSize);

        protected Point LastPoint {  get; set; }
    }
}