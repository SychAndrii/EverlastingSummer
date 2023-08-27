using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Base;

namespace Testing.StoryDesignerElements.Factories
{
    class StandardSceneStoryDesignerElementFactory : StoryDesignerElementFactory
    {
        public override StoryDesignerElementBase Create()
        {
            return new StandardSceneStoryDesignerElement();
        }
    }
}
