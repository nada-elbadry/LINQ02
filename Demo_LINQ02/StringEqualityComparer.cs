using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_LINQ02
{
    internal class StringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if (ReferenceEquals(x, y)) return true;
            return string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
        }
        //---------------------------------------------------------
        public int GetHashCode([DisallowNull] string obj)
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(obj);
        }
    }
}
