using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls.Helpers
{
  public static class ForEachExtension
  {
    public static void ForEach<T>(this IEnumerable<T> seq, Action<T> action)
    {
      foreach (T item in seq)
        action(item);
    }
  }
}
