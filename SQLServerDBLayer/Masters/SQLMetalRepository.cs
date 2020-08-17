using ServiceLayer.Masters;
using ModelLayer.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerDBLayer.Masters
{
    class SQLMetalRepository : IMetalRepository
    {
        public string AddMetal(MetalModel metal)
        {
            throw new NotImplementedException();
        }

        public string DeleteMetal(short Metalid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MetalModel> GetAllMetal()
        {
            throw new NotImplementedException();
        }

        public MetalModel GetMetal(short Metalid)
        {
            throw new NotImplementedException();
        }

        public string UpdateMetal(MetalModel metal)
        {
            throw new NotImplementedException();
        }
    }
}
