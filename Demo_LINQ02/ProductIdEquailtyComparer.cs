using Demo_LINQ02.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_LINQ02
{
    internal class ProductIdEquailtyComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.ProductID == y.ProductID;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return HashCode.Combine(obj.ProductID);
        }
    }
}
