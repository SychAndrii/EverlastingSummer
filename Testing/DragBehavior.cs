using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows;
using System.Xml;
using System.Windows.Markup;

namespace Testing
{
    public class DragBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseMove += OnMouseMove;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= OnMouseMove;
            base.OnDetaching();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(AssociatedObject, new DataObject("Element", CopyFrameworkElement(AssociatedObject)), DragDropEffects.Move);
            }
        }

        private UIElement CopyFrameworkElement(UIElement elem)
        {
            string xaml = XamlWriter.Save(elem);
            StringReader stringReader = new StringReader(xaml);
            XmlReader xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings());
            var copy = XamlReader.Load(xmlReader) as UIElement;
            return copy;
        }
    }
}
