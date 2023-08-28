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
    internal class DrawRectAdorners : DrawStoryDesignerElementAdorners
    {
        public override void Draw(DrawingContext drawingContext, FrameworkElement adornedElement)
        {
            Rect adornedElementRect = new Rect(adornedElement.DesiredSize);

            // Draw a circle at each corner.
            drawingContext.DrawEllipse(brush, pen, adornedElementRect.TopLeft, circleRadius, circleRadius);
            drawingContext.DrawEllipse(brush, pen, adornedElementRect.TopRight, circleRadius, circleRadius);
            drawingContext.DrawEllipse(brush, pen, adornedElementRect.BottomLeft, circleRadius, circleRadius);
            drawingContext.DrawEllipse(brush, pen, adornedElementRect.BottomRight, circleRadius, circleRadius);
            drawingContext.DrawEllipse(brush, pen, new Point(0, adornedElementRect.BottomRight.Y / 2), circleRadius, circleRadius);
            drawingContext.DrawEllipse(brush, pen, new Point(adornedElementRect.TopRight.X / 2, 0), circleRadius, circleRadius);
            drawingContext.DrawEllipse(brush, pen, new Point(adornedElementRect.TopRight.X / 2, adornedElementRect.BottomRight.Y), circleRadius, circleRadius);
            drawingContext.DrawEllipse(brush, pen, new Point(adornedElementRect.TopRight.X, adornedElementRect.BottomRight.Y / 2), circleRadius, circleRadius);
        }
    }
}
