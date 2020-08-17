using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Masters
{
    public class MetalModel
    {
        public Int16 MetalId { get; set; }

        [DisplayName("Metal Name")]
        public String MetalName { get; set; }
        public Decimal Rate { get; set; }
        public String Description { get; set; }

        [DisplayName("isDefault")]
        public Boolean IsDefault { get; set; }
    }
}
