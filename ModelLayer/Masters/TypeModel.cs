using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Masters
{
    public class TypeModel
    {
        public Int32 TypeId { get; set; }

        [DisplayName("Product Type")]
        public string Type { get; set; }
    }
}
