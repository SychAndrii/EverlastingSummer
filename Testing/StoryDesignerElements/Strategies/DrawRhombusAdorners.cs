using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Testing.Base;

namespace Testing.StoryDesignerElements.Strategies
{
    internal class DrawRhombusAdorners : DrawStoryDesignerElementAdorners
    {
        public override void Draw(DrawingContext drawingContext, FrameworkElement adornedElement)
        {
            double width = adornedElement.ActualWidth;
            double height = adornedElement.ActualHeight;

            // Calculate the centers of each side of the bounding rectangle
            Point topCenter = new Point(0, 0);
            Point bottomCenter = new Point(0, height);
            Point leftCenter = new Point(width, height);
            Point rightCenter = new Point(width, 0);

            // Draw the circles
            drawingContext.DrawEllipse(brush, pen, topCenter, circleRadius, circleRadius);
            drawingContext.DrawEllipse(brush, pen, bottomCenter, circleRadius, circleRadius);
            drawingContext.DrawEllipse(brush, pen, leftCenter, circleRadius, circleRadius);
            drawingContext.DrawEllipse(brush, pen, rightCenter, circleRadius, circleRadius);
        }
    }
}
