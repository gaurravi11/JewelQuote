using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Masters
{
    public class ShpModel
    {
        public Int16 ShpId { get; set; }

        [DisplayName("Shape")]
        public string ShpName { get; set; }
    }
}
