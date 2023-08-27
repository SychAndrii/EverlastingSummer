using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Base;

namespace Testing.StoryDesignerElements.Factories
{
    public abstract class StoryDesignerElementFactory
    {
        public abstract StoryDesignerElementBase Create();
    }
}
