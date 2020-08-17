using ModelLayer.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Masters
{
    public interface IStoneRateRepository
    {
        IEnumerable<StoneRateModel> GetStoneRate(Int16 StoneType);
        IEnumerable<StoneRateModel> GetStoneWeight(Int16 StoneType);
        string UpdateStoneRate(StoneRateModel stoneRateModel);
        string UpdateStoneWeight(StoneRateModel stoneRateModel);
    }
}
