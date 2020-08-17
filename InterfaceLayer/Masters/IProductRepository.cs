using ModelLayer.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Masters
{
    public interface IProductRepository
    {
        Int32 Get_NextProductNoByProductType(Int32 ProductType);
        Int32 Get_NextProductNoByProductCode(Int32 ProductCode);
        ProductModel GetProduct(Int64 ProductId);
        IEnumerable<ProductModel> GetAllProduct();
        string AddProduct(ProductModel productModel);
        string UpdateProduct(ProductModel productModel);
        string DeleteProduct(Int64 ProductId);
    }
}
