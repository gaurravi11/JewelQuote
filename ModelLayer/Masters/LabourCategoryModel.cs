using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Masters
{
    public class LabourCategoryModel
    {
        public Int16 CategoryId { get; set; }

        [DisplayName("Labour Category")]
        public string CategoryName { get; set; }
        public decimal Rate { get; set; }

        [DisplayName("isDefault")]
        public Boolean IsDefault { get; set; }
    }
}
