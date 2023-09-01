using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Testing.Adorners;
using Testing.Base;

namespace Testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly ObservableCollection<StoryDesignerElementBase> CurrentStoryDesignerElements;
        public readonly ObservableCollection<StoryDesignerElementBase> CurrentlySelectedStoryDesignerElements;
        public MainWindow()
        {
            InitializeComponent();
            CurrentStoryDesignerElements = new ObservableCollection<StoryDesignerElementBase>();
            CurrentlySelectedStoryDesignerElements = new ObservableCollection<StoryDesignerElementBase>();
        }

        private void canvas_DragOver(object sender, DragEventArgs e)
        {
            var dataObject = e.Data;
            var cursorPosition = e.GetPosition(StoryDesignerCanvas);

            var storyDesignElement = dataObject.GetData(typeof(StoryDesignerElementBase)) as StoryDesignerElementBase;

            if (storyDesignElement != null)
            {
                var elementStartingPointX = DragStartPositionProperties.GetDragStartX(storyDesignElement);
                var elementStartingPointY = DragStartPositionProperties.GetDragStartY(storyDesignElement);

                var position = e.GetPosition(StoryDesignerCanvas);

                if (StoryDesignerCanvas.Children.Contains(storyDesignElement))
                {
                    StoryDesignerCanvas.Children.Remove(storyDesignElement);
                }

                StoryDesignerCanvas.Children.Add(storyDesignElement);
                Canvas.SetTop(storyDesignElement, position.Y - elementStartingPointY);
                Canvas.SetLeft(storyDesignElement, position.X - elementStartingPointX);
            }
            else
            {
                var arrow = dataObject.GetData(typeof(StoryDesignerArrowAdorner)) as StoryDesignerArrowAdorner;
                var storyDesignElement2 = dataObject.GetData(typeof(string)) as StoryDesignerElementBase;

                var elementX = Canvas.GetLeft(storyDesignElement2);
                var elementY = Canvas.GetTop(storyDesignElement2);

                var shift = new Point(cursorPosition.X - elementX, cursorPosition.Y - elementY);
                arrow.EndPoint = shift;
                arrow.InvalidateVisual();
            }
        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {
            var dataObject = e.Data;
            if (dataObject.GetDataPresent(typeof(StoryDesignerElementBase)))
            {
                var storyDesignElement = dataObject.GetData(typeof(StoryDesignerElementBase)) as StoryDesignerElementBase;
                CurrentStoryDesignerElements.Add(storyDesignElement);
            }
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is DependencyObject d)
            {
                StoryDesignerElementBase? storyDesignElement = FindStoryDesignElementParent(d);

                if (storyDesignElement != null && !CurrentlySelectedStoryDesignerElements.Contains(storyDesignElement))
                {
                    UnselectAllSelectedElements();
                    CurrentlySelectedStoryDesignerElements.Add(storyDesignElement);
                }
                else
                {
                    UnselectAllSelectedElements();
                }
            }
        }

        private void UnselectAllSelectedElements()
        {
            foreach (var element in CurrentlySelectedStoryDesignerElements)
            {
                var adorneredLayer = AdornerLayer.GetAdornerLayer(element);
                var adorners = adorneredLayer.GetAdorners(element);
                if (adorners != null)
                {
                    foreach (var adorner in adorners)
                    {
                        adorneredLayer.Remove(adorner);
                    }
                }
            }
            CurrentlySelectedStoryDesignerElements.Clear();
        }

        private StoryDesignerElementBase? FindStoryDesignElementParent(DependencyObject child)
        {
            while (child != null)
            {
                if (child is StoryDesignerElementBase storyDesignElement)
                    return storyDesignElement;
                child = VisualTreeHelper.GetParent(child);
            }
            return null;
        }
    }
}
