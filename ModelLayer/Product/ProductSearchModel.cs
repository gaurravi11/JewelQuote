using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Product
{
    public class ProductSearchModel
    {
        public Int32 ProductTypeId { get; set; }
        public Int32 ProductCodeId { get; set; }
        public String ProductCode { get; set; }
        public String ProductFromNo { get; set; }
        public String ProductToNo { get; set; }
        public String ProductNos { get; set; }
        public Boolean isWithoutStone { get; set; }
    }
}
