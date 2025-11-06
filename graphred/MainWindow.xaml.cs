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
using graphedit.Models.Tools;
using graphedit.Models;
using graphedit.Models.Commands;

namespace graphedit
{
    public partial class MainWindow : Window // проверка коммитов
    {
        private bool isDrawing = false;
        private DrawingTool currentTool;
        private readonly DrawingSettings settings;
        private UIManager? uiManager;
        private readonly UndoRedoManager undoManager;

        public MainWindow()
        {

            InitializeComponent();
            settings = new DrawingSettings();
            currentTool = new BrushTool();
            undoManager = new UndoRedoManager();

            BrushSizeComboBox.SelectedIndex = 0;

            InitializeUIManager();
        }

        private void InitializeUIManager()
        {
            Button[] toolButtons = [BrushButton, EraserButton, TextButton, ImageButton];

            Button[] colorButtons = [
                BlackColorBtn, RedColorBtn, GreenColorBtn, BlueColorBtn,
                PurpleColorBtn, OrangeColorBtn, YellowColorBtn, PinkColorBtn,
                BrownColorBtn, GrayColorBtn
            ];
            uiManager = new UIManager(toolButtons, colorButtons);

            uiManager?.HighlightToolButton(BrushButton);
            uiManager?.HighlightColorButton(BlackColorBtn);

        }

        private void DrawCanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            isDrawing = true;
            Point point = e.GetPosition(DrawCanvas);
            currentTool.OnMouseDown(point, DrawCanvas, settings.CurrentBrush, settings.BrushSize, undoManager);

        }

        private void DrawCanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            Point point = e.GetPosition(DrawCanvas);
            currentTool.OnMouseMove(point, DrawCanvas, settings.CurrentBrush, settings.BrushSize, undoManager);
        }

        private void DrawCanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;
            Point point = e.GetPosition(DrawCanvas);
            currentTool.OnMouseUp(point, DrawCanvas, settings.CurrentBrush, settings.BrushSize, undoManager);
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (settings == null || uiManager == null) return;
            Button colorButton = (Button)sender;
            settings.CurrentBrush = colorButton.Background;
            uiManager.HighlightColorButton(colorButton);
        }

        private void BrushButton_Click(object sender, RoutedEventArgs e)
        {
            if (settings == null || uiManager == null) return;
            currentTool = new BrushTool();
            settings.CurrentBrush = uiManager.GetActiveColor();
            uiManager.HighlightToolButton(BrushButton);
        }

        private void EraserButton_Click(object sender, RoutedEventArgs e)
        {
            if (uiManager == null) return;
            currentTool = new EraserTool();
            uiManager.HighlightToolButton(EraserButton);
        }

        private void BrushSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (settings == null || BrushSizeComboBox.SelectedIndex == -1)
                return;
            settings.SetBrushSizeByIndex(BrushSizeComboBox.SelectedIndex);
        }

        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            if (uiManager == null) return;
            currentTool = new TextTool();
            uiManager.HighlightToolButton(TextButton);
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            currentTool = new ImageTool();
            uiManager?.HighlightToolButton(ImageButton);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DrawCanvas.Children.Clear();
        }
        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            undoManager.Undo(DrawCanvas);
        }

        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            undoManager.Redo(DrawCanvas);
        }
    }
}