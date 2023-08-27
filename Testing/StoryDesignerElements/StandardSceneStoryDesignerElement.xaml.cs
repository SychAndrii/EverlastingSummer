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

namespace Testing.StoryDesignerElements
{
    /// <summary>
    /// Interaction logic for StandardSceneStoryDesignerElement.xaml
    /// </summary>
    public partial class StandardSceneStoryDesignerElement : StoryDesignerElementBase
    {
        public ObservableCollection<StoryDesignerElementBase> CurrentStoryDesignElements { get; set; }
        public StandardSceneStoryDesignerElement()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void StoryDesignerElementBase_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            var adornerLayer = AdornerLayer.GetAdornerLayer(this);
            if (adornerLayer != null)
            {
                adornerLayer.Add(new FourCirclesAdorner(this));
            }
        }
    }
}
