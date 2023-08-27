using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using Testing.Base;
using Testing.StoryDesignerElements.Factories;

namespace Testing.Behaviors
{
    internal class StoryDesignerElementDragBehavior : Behavior<UIElement>
    {
        public StoryDesignerElementDragBehavior()
        {

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
                    new DataObject(typeof(StoryDesignerElementBase), dependencyObjSender),
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
