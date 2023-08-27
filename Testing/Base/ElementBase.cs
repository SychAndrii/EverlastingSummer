using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Testing.Behaviors;
using Testing.StoryDesignerElements.Factories;

namespace Testing.Base
{
    public class ElementBase : UserControl
    {
        public ElementBase() 
        { 
            Interaction.GetBehaviors(this).Add(new ElementDragBehavior(
                new ChoiceSceneStoryDesignerElementFactory()         
            ));
        }
    }
}
