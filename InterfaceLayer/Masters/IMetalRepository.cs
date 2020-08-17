using ModelLayer.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Masters
{
    public interface IMetalRepository
    {
        MetalModel GetMetal(Int16 Metalid);
        IEnumerable<MetalModel> GetAllMetal();
        string AddMetal(MetalModel metal);
        string UpdateMetal(MetalModel metal);
        string DeleteMetal(Int16 Metalid);
    }
}
