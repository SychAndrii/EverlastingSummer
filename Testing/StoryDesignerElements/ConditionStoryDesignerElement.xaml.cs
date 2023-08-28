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
using Testing.Base;
using Testing.StoryDesignerElements.Strategies;

namespace Testing.StoryDesignerElements
{
    /// <summary>
    /// Interaction logic for ConditionStoryDesignerElement.xaml
    /// </summary>
    public partial class ConditionStoryDesignerElement : StoryDesignerElementBase
    {
        public ConditionStoryDesignerElement() : base(new DrawRhombusAdorners())
        {
            InitializeComponent();
        }
    }
}
