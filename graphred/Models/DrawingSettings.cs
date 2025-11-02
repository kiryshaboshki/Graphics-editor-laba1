using System.Windows.Media;

namespace graphedit.Models
{
    public class DrawingSettings
    {
        public Brush CurrentBrush { get; set; } = Brushes.Black;
        public double BrushSize { get; set; } = 2;

        public void SetBrushSizeByIndex(int index)
        {
            BrushSize = index switch
            {
                0 => 2,
                1 => 5,
                2 => 10,
                _ => BrushSize
            };
        }
    }
}