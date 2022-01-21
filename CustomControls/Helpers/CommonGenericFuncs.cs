using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomControls
{
    public static class CommonGenericFuncs
    {
        public static T GetChildOfType<T>(this DependencyObject depObj)
            where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        public static T FindChild<T>(DependencyObject parent, string childName)
           where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

        public static T FindParent<T>(DependencyObject child)
                where T : DependencyObject
        {
            if (child == null) return null;

            T foundParent = null;
            DependencyObject currentParent = VisualTreeHelper.GetParent(child);

            do
            {
                var frameworkElement = currentParent as FrameworkElement;
                if (frameworkElement is T)
                {
                    foundParent = (T)currentParent;
                    break;
                }

                currentParent = VisualTreeHelper.GetParent(currentParent);

            } while (currentParent != null);

            return foundParent;
        }

        public static List<DependencyObject> FindAllChildren(this DependencyObject dpo, Predicate<DependencyObject> predicate)
        {
            var results = new List<DependencyObject>();
            if (predicate == null)
                return results;


            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dpo); i++)
            {
                var child = VisualTreeHelper.GetChild(dpo, i);
                if (predicate(child))
                    results.Add(child);

                var subChildren = child.FindAllChildren(predicate);
                results.AddRange(subChildren);
            }
            return results;
        }


        public static UIElement GetControlByName(UIElement gridRow, string name)
        {
            var child = FindChildCustomUIElement(gridRow, childControl =>
            {
                var textBlock = childControl as CustomTextBox;
                if (textBlock != null && textBlock.Name == name)
                    return true;
                else
                    return false;
            }) as CustomTextBox;

            return child;
        }

        public static DependencyObject FindChildCustomUIElement(DependencyObject parent, Func<DependencyObject, bool> predicate)
        {
            if (parent == null) return null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (predicate(child))
                {
                    return child;
                }
                else
                {
                    var foundChild = FindChildCustomUIElement(child, predicate);
                    if (foundChild != null)
                        return foundChild;
                }
            }

            return null;
        }

        public static UIElement FindUIElementOnUid(this DependencyObject parent, string uid)
        {
          var count = VisualTreeHelper.GetChildrenCount(parent);

          for (int i = 0; i < count; i++)
          {
            var el = VisualTreeHelper.GetChild(parent, i) as UIElement;
            if (el == null) continue;

            if (el.Uid == uid) return el;

            el = el.FindUIElementOnUid(uid);
            if (el != null) return el;
          }

          if (parent is ContentControl)
          {
            UIElement content = (parent as ContentControl).Content as UIElement;
            if (content != null)
            {
              if (content.Uid == uid) return content;

              var el = content.FindUIElementOnUid(uid);
              if (el != null) return el;
            }
          }
          return null;
        }

        public static T FindVisualParent<T>(UIElement element) where T : UIElement
            {
              UIElement parent = element;
              while (parent != null)
              {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                  return correctlyTyped;
                }

                parent = VisualTreeHelper.GetParent(parent) as UIElement;
              }
              return null;
            }

        public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject parent) where T : DependencyObject
        {
          if (parent == null)
            throw new ArgumentNullException(nameof(parent));

          var queue = new Queue<DependencyObject>(new[] { parent });

          while (queue.Any())
          {
            var reference = queue.Dequeue();
            var count = VisualTreeHelper.GetChildrenCount(reference);

            for (var i = 0; i < count; i++)
            {
              var child = VisualTreeHelper.GetChild(reference, i);
              if (child is T children)
                yield return children;

              queue.Enqueue(child);
            }
          }
        }

        public static IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
    {
      if (grid != null)
      {
        IEnumerable itemsSource = grid.ItemsSource as IEnumerable;
        if (itemsSource == null) yield return null;
        if (itemsSource != null)
        {
          foreach (object item in itemsSource)
          {
            DataGridRow row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
            if (null != row) yield return row;
          }
        }

      }

    }
  }
}
