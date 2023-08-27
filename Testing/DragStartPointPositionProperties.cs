using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Testing
{
    public static class DragStartPositionProperties
    {
        public static double GetDragStartX(DependencyObject obj)
        {
            return (double)obj.GetValue(DragStartXProperty);
        }

        public static void SetDragStartX(DependencyObject obj, double value)
        {
            obj.SetValue(DragStartXProperty, value);
        }

        public static readonly DependencyProperty DragStartXProperty =
            DependencyProperty.RegisterAttached("DragStartX", typeof(double), typeof(DragStartPositionProperties), new PropertyMetadata(0.0));

        public static double GetDragStartY(DependencyObject obj)
        {
            return (double)obj.GetValue(DragStartYProperty);
        }

        public static void SetDragStartY(DependencyObject obj, double value)
        {
            obj.SetValue(DragStartYProperty, value);
        }

        public static readonly DependencyProperty DragStartYProperty =
            DependencyProperty.RegisterAttached("DragStartY", typeof(double), typeof(DragStartPositionProperties), new PropertyMetadata(0.0));
    }
}
