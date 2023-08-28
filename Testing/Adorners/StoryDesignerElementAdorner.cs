using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;
using Testing.Base;

namespace Testing.Adorners
{
    public class StoryDesignerElementAdorner : Adorner
    {
        private readonly DrawStoryDesignerElementAdorners strategy;

        // Be sure to call the base class constructor.
        public StoryDesignerElementAdorner(UIElement adornedElement, DrawStoryDesignerElementAdorners strategy)
          : base(adornedElement)
        {
            this.strategy = strategy;
        }

        // A common way to implement an adorner's rendering behavior is to override the OnRender
        // method, which is called by the layout system as part of a rendering pass.
        protected override void OnRender(DrawingContext drawingContext)
        {
            strategy.Draw(drawingContext, (FrameworkElement)this.AdornedElement);
        }
    }
}
