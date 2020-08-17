using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Masters
{
    public class StoneModel
    {
        public Int16 StoneId { get; set; }

        [DisplayName("Stone Name")]
        public string StoneName { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }

        [DisplayName("Sort Order")]
        public int SortOrder { get; set; }

        [DisplayName("isDefault")]
        public Boolean IsDefault { get; set; }
    }
}
