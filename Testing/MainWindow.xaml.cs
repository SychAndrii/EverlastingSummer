using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace Testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void canvas_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetData("Element") is UIElement elem && sender is Canvas canvas)
            {
                Point dropPosition = e.GetPosition(canvas);

                Canvas.SetLeft(elem, dropPosition.X);
                Canvas.SetTop(elem, dropPosition.Y);
                if(canvas.Children.Contains(elem))
                    canvas.Children.Remove(elem);
                canvas.Children.Add(elem);
            }
        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(UIElement)) is UIElement elem && sender is Canvas canvas)
            {
                Point dropPosition = e.GetPosition(canvas);

                Canvas.SetLeft(elem, dropPosition.X);
                Canvas.SetTop(elem, dropPosition.Y);
                if (!canvas.Children.Contains(elem))
                    canvas.Children.Add(elem);
            }
        }
    }
}
