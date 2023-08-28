using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using Testing.Adorners;
using Testing.Behaviors;
using Testing.StoryDesignerElements.Factories;
using Testing.StoryDesignerElements.Strategies;

namespace Testing.Base
{
    public class StoryDesignerElementBase : UserControl
    {
        private readonly DrawStoryDesignerElementAdorners drawAdornersStrategy;
        public StoryDesignerElementBase(DrawStoryDesignerElementAdorners drawAdornersStrategy)
        {
            Interaction.GetBehaviors(this).Add(new StoryDesignerElementDragBehavior());
            this.drawAdornersStrategy = drawAdornersStrategy;
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            var adornerLayer = AdornerLayer.GetAdornerLayer(this);
            if (adornerLayer != null)
            {
                adornerLayer.Add(
                    new StoryDesignerElementAdorner(this, drawAdornersStrategy));
            }
        }
    }
}
