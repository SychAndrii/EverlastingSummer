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
using Testing.Base;
using Testing.StoryDesignerElements.Factories;

namespace Testing.Elements
{
    /// <summary>
    /// Interaction logic for StandardScene.xaml
    /// </summary>
    public partial class StandardSceneElement : ElementBase
    {
        public StandardSceneElement() : base(new StandardSceneStoryDesignerElementFactory())
        {
            InitializeComponent();
        }
    }
}
