using ModelLayer.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Masters
{
    public interface IStoneRepository
    {
        StoneModel GetStone(Int16 Stoneid);
        IEnumerable<StoneModel> GetAllStone();
        string AddStone(StoneModel stone);
        string UpdateStone(StoneModel stone);
        string DeleteStone(Int16 Stoneid);
        Int16 getNextSortOrder();
        Boolean SortOrderExists(Int16 SortOrder);
    }
}
