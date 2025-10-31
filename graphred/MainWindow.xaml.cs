using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace graphedit
{
    public partial class MainWindow : Window
    {
        private bool IsDrawing = false;
        private Point startPoint;
        private Brush CurrentBrush = Brushes.Black;
        private double BrushSize = 2;

        public MainWindow()
        {

            InitializeComponent();
        }

        private void DrawCanvasMouseDown(object sender, MouseEventArgs e)
        {
            IsDrawing = true;
            startPoint = e.GetPosition(DrawCanvas);
        }

        private void DrawCanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (!IsDrawing) return;

            Point CurrentPoint = e.GetPosition(DrawCanvas);

            Line line = new Line();
            line.X1 = startPoint.X;
            line.Y1 = startPoint.Y;

            line.X2 = CurrentPoint.X;
            line.Y2 = CurrentPoint.Y;

            line.Stroke = CurrentBrush;
            line.StrokeThickness = BrushSize;

            DrawCanvas.Children.Add(line);

            startPoint = CurrentPoint;
        }

        private void DrawCanvasMouseUp(object sender, MouseEventArgs e)
        {
            IsDrawing = false;
        }
            
    }
}