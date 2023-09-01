using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Testing.Base
{
    public abstract class DrawStoryDesignerElementAdorners
    {
        protected readonly Brush brush = new SolidColorBrush(Colors.Green) { Opacity = 0.2 };
        protected readonly Pen pen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
        public double CircleRadius { get; } = 3.0;
        public List<Point> CirclePositions { get; } = new List<Point>();
        public abstract void Draw(DrawingContext drawingContext, FrameworkElement adornedElement);
    }
}
