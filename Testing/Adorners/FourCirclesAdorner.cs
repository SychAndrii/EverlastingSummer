using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;

namespace Testing.Adorners
{
    public class FourCirclesAdorner : Adorner
    {
        // Be sure to call the base class constructor.
        public FourCirclesAdorner(UIElement adornedElement)
          : base(adornedElement)
        {
        }

        // A common way to implement an adorner's rendering behavior is to override the OnRender
        // method, which is called by the layout system as part of a rendering pass.
        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);

            // Some arbitrary drawing implements.
            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
            renderBrush.Opacity = 0.2;
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
            double renderRadius = 3.0;

            // Draw a circle at each corner.
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, new Point(0, adornedElementRect.BottomRight.Y / 2), renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, new Point(adornedElementRect.TopRight.X / 2, 0), renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, new Point(adornedElementRect.TopRight.X / 2, adornedElementRect.BottomRight.Y), renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, new Point(adornedElementRect.TopRight.X, adornedElementRect.BottomRight.Y / 2), renderRadius, renderRadius);
        }
    }
}
