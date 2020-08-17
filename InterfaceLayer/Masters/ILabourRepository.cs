using ModelLayer.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Masters
{
    public interface ILabourRepository
    {
        LabourCategoryModel GetCategory(Int16 CategoryId);
        IEnumerable<LabourCategoryModel> GetAllCategory();
        DataTable GetAllCategory_dt();
        string AddCategory(LabourCategoryModel Category);
        string UpdateCategory(LabourCategoryModel Category);
        string DeleteCategory(Int16 CategoryId);
    }
}
