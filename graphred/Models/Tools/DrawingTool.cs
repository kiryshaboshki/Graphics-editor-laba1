using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using graphedit.Models.Commands;

namespace graphedit.Models
{
    public abstract class DrawingTool
    {
        public abstract void OnMouseDown(Point point, Canvas canvas, Brush brush, double brushSize, UndoRedoManager undoManager);
        public abstract void OnMouseMove(Point point, Canvas canvas, Brush brush, double brushSize, UndoRedoManager undoManager);
        public abstract void OnMouseUp(Point point, Canvas canvas, Brush brush, double brushSize, UndoRedoManager undoManager);

        protected Point LastPoint { get; set; }
        protected CompositeCommand CurrentCompositeCommand { get; set; }
    }
}