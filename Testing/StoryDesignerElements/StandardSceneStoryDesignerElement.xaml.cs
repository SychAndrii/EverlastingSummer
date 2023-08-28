using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Testing.Adorners;
using Testing.Base;
using Testing.StoryDesignerElements.Strategies;

namespace Testing.StoryDesignerElements
{
    /// <summary>
    /// Interaction logic for StandardSceneStoryDesignerElement.xaml
    /// </summary>
    public partial class StandardSceneStoryDesignerElement : StoryDesignerElementBase
    {
        public StandardSceneStoryDesignerElement() : base(new DrawRectAdorners())
        {
            InitializeComponent();
        }
    }
}
