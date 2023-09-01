using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Testing.Adorners
{
    internal class StoryDesignerArrowAdorner : Adorner
    {
        public double ArrowHeadWidth { get; set; } = 0;
        public double ArrowHeadHeight { get; set; } = 0;
        public double ArrowThickness { get; set; } = 2.0;
        public Color ArrowColor { get; set; } = Colors.Black;
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public StoryDesignerArrowAdorner(UIElement adornedElement, Point startPoint) : base(adornedElement)
        {
            StartPoint = startPoint;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            // Define the arrow's line
            Pen arrowPen = new Pen(new SolidColorBrush(ArrowColor), ArrowThickness);
            drawingContext.DrawLine(arrowPen, StartPoint, EndPoint);

            // Draw the arrow head (simple triangle)
            Point arrowHeadP1 = EndPoint;
            Point arrowHeadP2 = new Point(EndPoint.X - ArrowHeadHeight, EndPoint.Y - ArrowHeadWidth / 2);
            Point arrowHeadP3 = new Point(EndPoint.X - ArrowHeadHeight, EndPoint.Y + ArrowHeadWidth / 2);

            if ((EndPoint - StartPoint).X < 0) // if arrow is pointing to the left
            {
                arrowHeadP2 = new Point(EndPoint.X + ArrowHeadHeight, EndPoint.Y - ArrowHeadWidth / 2);
                arrowHeadP3 = new Point(EndPoint.X + ArrowHeadHeight, EndPoint.Y + ArrowHeadWidth / 2);
            }

            PathFigure pathFigure = new PathFigure
            {
                StartPoint = arrowHeadP1,
                IsClosed = true
            };

            pathFigure.Segments.Add(new LineSegment(arrowHeadP2, true));
            pathFigure.Segments.Add(new LineSegment(arrowHeadP3, true));

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);

            drawingContext.DrawGeometry(new SolidColorBrush(ArrowColor), null, pathGeometry);
        }
    }
}
