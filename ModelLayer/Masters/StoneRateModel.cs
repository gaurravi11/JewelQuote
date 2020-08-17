using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Masters
{
    public class StoneRateModel
    {
        public Int64 RateId { get; set; }
        public Int32 StoneId { get; set; }
        public Int32 ShapeId { get; set; }
        public decimal Weight { get; set; }
        public decimal Rate { get; set; }
        public Int16 StoneType { get; set; }
    }
}
