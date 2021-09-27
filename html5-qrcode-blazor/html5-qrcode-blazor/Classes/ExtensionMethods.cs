using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace html5_qrcode_blazor.Classes
{
    public static class ExtensionMethods
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self) => self.Select((item, index) => (item, index));
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable) => !enumerable?.Any() ?? true;
    }
}