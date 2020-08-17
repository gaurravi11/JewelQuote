using ModelLayer.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Masters
{
    public interface IProductTypeRepository
    {
        //TypeModel
        TypeModel GetType(Int32 Typeid);
        IEnumerable<TypeModel> GetAllType();
        string AddType(TypeModel type);
        string UpdateType(TypeModel type);
        string DeleteType(Int32 Typeid);

        //ProductTypeModel
        ProductTypeModel GetProductType(Int32 ProductTypeid);
        IEnumerable<ProductTypeModel> GetAllProductType();
        IEnumerable<ProductTypeModel> GetCodeByTypeId(Int32 Typeid);
        string AddProductType(ProductTypeModel productType);
        string UpdateProductType(ProductTypeModel productType);
        string DeleteProductType(Int32 ProductTypeid);
    }
}
