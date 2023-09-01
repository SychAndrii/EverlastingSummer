using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Testing.StoryDesignerElements
{
    /// <summary>
    /// Interaction logic for Arrow.xaml
    /// </summary>
    public partial class Arrow : UserControl
    {
        private static readonly DependencyProperty XEndingProperty;
        private static readonly DependencyProperty YEndingProperty;

        static Arrow()
        {
            XEndingProperty = DependencyProperty.Register("XEnding", typeof(double), typeof(Arrow), new PropertyMetadata(0.0));
            YEndingProperty = DependencyProperty.Register("YEnding", typeof(double), typeof(Arrow), new PropertyMetadata(0.0));
        }

        public double XEnding
        {
            get
            {
                return (double)GetValue(XEndingProperty);
            }
            set
            {
                SetValue(XEndingProperty, value);
            }
        }

        public double YEnding
        {
            get
            {
                return (double)GetValue(YEndingProperty);
            }
            set
            {
                SetValue(YEndingProperty, value);
            }
        }

        public Arrow()
        {
            InitializeComponent();
        }
    }
}
