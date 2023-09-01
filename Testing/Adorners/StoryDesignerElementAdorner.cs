using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Testing.Base;

namespace Testing.Adorners
{
    public class StoryDesignerElementAdorner : Adorner
    {
        private readonly DrawStoryDesignerElementAdorners strategy;
        private bool isDragging = false;
        private AdornerLayer adornerLayer;
        private StoryDesignerArrowAdorner currentlyDraggedArrow;
        private UIElement storyDesignElement;

        public StoryDesignerElementAdorner(UIElement adornedElement, DrawStoryDesignerElementAdorners strategy)
          : base(adornedElement)
        {
            storyDesignElement = adornedElement;
            this.strategy = strategy;
            adornerLayer = AdornerLayer.GetAdornerLayer(adornedElement);
            AllowDrop = true;
            MouseDown += StoryDesignerElementAdorner_MouseDown;
            MouseMove += StoryDesignerElementAdorner_MouseMove;
        }

        public Point? GetCirclePositionNear(Point point)
        {
            foreach (var circlePosition in strategy.CirclePositions)
            {
                var distance = Math.Sqrt(Math.Pow(point.X - circlePosition.X, 2) + Math.Pow(point.Y - circlePosition.Y, 2));

                if (distance <= strategy.CircleRadius)
                {
                    return circlePosition;
                }
            }
            return null;
        }

        private void StoryDesignerElementAdorner_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentlyDraggedArrow = new StoryDesignerArrowAdorner(this, GetCirclePositionNear(e.GetPosition(this)).Value);
            adornerLayer.Add(currentlyDraggedArrow);

        }

        private void StoryDesignerElementAdorner_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var dependencyObjSender = sender as DependencyObject;

                var dataObject = new DataObject();
                dataObject.SetData(typeof(string), storyDesignElement);
                dataObject.SetData(typeof(StoryDesignerArrowAdorner), currentlyDraggedArrow);

                DragDrop.DoDragDrop(dependencyObjSender, dataObject, DragDropEffects.Move);
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            strategy.Draw(drawingContext, (FrameworkElement)this.AdornedElement);
        }
    }
}
