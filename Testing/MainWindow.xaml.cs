using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Testing.Base;
using Testing.Elements;
using Testing.StoryDesignerElements;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                    CurrentlySelectedStoryDesignerElements.Add(storyDesignElement);
                }
                else
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
            }
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

        private void RemoveAdorners(UIElement element)
        {
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(element);
            if (adornerLayer != null)
            {
                Adorner[] adorners = adornerLayer.GetAdorners(element);
                if (adorners != null)
                {
                    foreach (Adorner adorner in adorners)
                    {
                        adornerLayer.Remove(adorner);
                    }
                }
            }
        }
    }
}
