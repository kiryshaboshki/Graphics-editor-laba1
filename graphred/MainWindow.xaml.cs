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
using graphedit.Models;

namespace graphedit
{
    public partial class MainWindow : Window // проверка коммитов
    {
        private bool IsDrawing = false;
        private DrawingTool currentTool;
        private DrawingSettings settings;

        public MainWindow()
        {

            InitializeComponent();
            settings = new DrawingSettings();
            currentTool = new BrushTool();

            BrushSizeComboBox.SelectedIndex = 0;
        }

        private void DrawCanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            IsDrawing = true;
            Point point = e.GetPosition(DrawCanvas);
            currentTool.OnMouseDown(point, DrawCanvas, settings.CurrentBrush, settings.BrushSize);

        }

        private void DrawCanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (!IsDrawing) return;

            Point point = e.GetPosition(DrawCanvas);
            currentTool.OnMouseMove(point, DrawCanvas, settings.CurrentBrush, settings.BrushSize);
        }

        private void DrawCanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            IsDrawing = false;
            Point point = e.GetPosition(DrawCanvas);
            currentTool.OnMouseUp(point, DrawCanvas, settings.CurrentBrush, settings.BrushSize);
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (settings == null) return;
            Button colorButton = (Button)sender;
            settings.CurrentBrush = colorButton.Background;
        }

        private void BrushButton_Click(object sender, RoutedEventArgs e)
        {
            if (settings == null) return;
            currentTool = new BrushTool();
            settings.CurrentBrush = Brushes.Black;
        }

        private void EraserButton_Click(object sender, RoutedEventArgs e)
        {
            currentTool = new EraserTool();
        }

        private void BrushSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (settings == null || BrushSizeComboBox.SelectedIndex == -1)
                return;
            settings.SetBrushSizeByIndex(BrushSizeComboBox.SelectedIndex);
        }

        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            currentTool = new TextTool();
        }


    }
}