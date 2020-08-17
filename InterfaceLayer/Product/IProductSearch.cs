using ModelLayer.Product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Product
{
    public interface IProductSearch
    {
        DataTable GetProductsSearch(ProductSearchModel productSearchModel);
    }
}
