using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using graphedit.Models.Commands;

namespace graphedit.Models.Tools
{
    public class BrushTool : DrawingTool
    {
        public override void OnMouseDown(Point point, Canvas canvas, Brush brush, double brushSize, UndoRedoManager undoManager)
        {
            LastPoint = point;
            CurrentCompositeCommand = new CompositeCommand();
        }

        public override void OnMouseMove(Point point, Canvas canvas, Brush brush, double brushSize, UndoRedoManager undoManager)
        {
            if (LastPoint == default) return;

            Line line = new Line
            {
                X1 = LastPoint.X,
                Y1 = LastPoint.Y,
                X2 = point.X,
                Y2 = point.Y,
                Stroke = brush,
                StrokeThickness = brushSize,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                StrokeLineJoin = PenLineJoin.Round
            };

            canvas.Children.Add(line);
            CurrentCompositeCommand.AddCommand(new AddElementCommand(line, canvas));
            LastPoint = point;

        }

        public override void OnMouseUp(Point point, Canvas canvas, Brush brush, double brushSize, UndoRedoManager undoManager)
        {
            if (CurrentCompositeCommand != null && CurrentCompositeCommand.CommandCount > 0)
            {
                undoManager.ExecuteCommand(CurrentCompositeCommand, canvas);
            }
            LastPoint = default;
            CurrentCompositeCommand = null;
        }
    }
}

