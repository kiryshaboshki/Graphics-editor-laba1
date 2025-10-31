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

        private void DrawCanvasMouseDown(object sender, MouseButtonEventArgs e)
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

        private void DrawCanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            IsDrawing = false;
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            Button colorButton = (Button)sender;
            CurrentBrush = colorButton.Background;
        }

        private void BrushButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentBrush = Brushes.Black;
        }

        private void EraserButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentBrush = Brushes.White;
        }

        private void BrushSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BrushSizeComboBox.SelectedIndex == 0)
                BrushSize = 2;
            else if (BrushSizeComboBox.SelectedIndex == 1)
                BrushSize = 5;
            else if (BrushSizeComboBox.SelectedIndex == 2)
                BrushSize = 10;
        }


    }
}