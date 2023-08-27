using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows;
using Testing.StoryDesignerElements.Factories;
using System.Windows.Controls;
using Testing.Base;

namespace Testing.Behaviors
{
    public class ElementDragBehavior : Behavior<UIElement>
    {
        private readonly StoryDesignerElementBase storyDesignerElement;

        public ElementDragBehavior(StoryDesignerElementFactory factory)
        {
            storyDesignerElement = factory.Create();
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseMove += OnMouseMove;
            AssociatedObject.MouseUp += OnMouseUp;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender is DependencyObject dependencyObjSender)
            {
                DragDrop.DoDragDrop(dependencyObjSender, 
                    new DataObject(typeof(StoryDesignerElementBase), storyDesignerElement),
                    DragDropEffects.Move);
            }
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= OnMouseMove;
            AssociatedObject.MouseUp -= OnMouseUp;
            base.OnDetaching();
        }
    }
}
