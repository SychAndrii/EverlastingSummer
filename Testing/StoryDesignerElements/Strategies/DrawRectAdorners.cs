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
            CirclePositions.Clear();

            CirclePositions.Add(adornedElementRect.TopLeft);
            CirclePositions.Add(adornedElementRect.TopRight);
            CirclePositions.Add(adornedElementRect.BottomLeft);
            CirclePositions.Add(adornedElementRect.BottomRight);

            Point x_0_y_half = new Point(0, adornedElementRect.BottomRight.Y / 2);
            Point x_half_y_0 = new Point(adornedElementRect.TopRight.X / 2, 0);
            Point x_half_y_full = new Point(adornedElementRect.TopRight.X / 2, adornedElementRect.BottomRight.Y);
            Point x_full_y_half = new Point(adornedElementRect.TopRight.X, adornedElementRect.BottomRight.Y / 2);

            CirclePositions.Add(x_0_y_half);
            CirclePositions.Add(x_half_y_0);
            CirclePositions.Add(x_half_y_full);
            CirclePositions.Add(x_full_y_half);


            drawingContext.DrawEllipse(brush, pen, adornedElementRect.TopLeft, CircleRadius, CircleRadius);
            drawingContext.DrawEllipse(brush, pen, adornedElementRect.TopRight, CircleRadius, CircleRadius);
            drawingContext.DrawEllipse(brush, pen, adornedElementRect.BottomLeft, CircleRadius, CircleRadius);
            drawingContext.DrawEllipse(brush, pen, adornedElementRect.BottomRight, CircleRadius, CircleRadius);
            drawingContext.DrawEllipse(brush, pen, x_0_y_half, CircleRadius, CircleRadius);
            drawingContext.DrawEllipse(brush, pen, x_half_y_0, CircleRadius, CircleRadius);
            drawingContext.DrawEllipse(brush, pen, x_half_y_full, CircleRadius, CircleRadius);
            drawingContext.DrawEllipse(brush, pen, x_full_y_half, CircleRadius, CircleRadius);
        }
    }
}
