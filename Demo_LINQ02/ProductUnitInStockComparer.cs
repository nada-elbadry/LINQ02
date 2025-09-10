using Demo_LINQ02.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_LINQ02
{
    internal class ProductUnitInStockComparer : IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x is null) return -1;
            if (y is null) return 1;
            return x.UnitsInStock.CompareTo(y.UnitsInStock);
        }

    }
}
