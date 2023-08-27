using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void canvas_DragOver(object sender, DragEventArgs e)
        {
            var dataObject = e.Data;
            if(dataObject.GetDataPresent(typeof(StoryDesignerElementBase)))
            {
                var data = e.Data.GetData(typeof(StoryDesignerElementBase)) as StoryDesignerElementBase;
                var position = e.GetPosition(StoryDesignerCanvas);

                if(StoryDesignerCanvas.Children.Contains(data))
                {
                    StoryDesignerCanvas.Children.Remove(data);
                }

                StoryDesignerCanvas.Children.Add(data);
                Canvas.SetTop(data, position.Y);
                Canvas.SetLeft(data, position.X);
            }
        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {

        }
    }
}
