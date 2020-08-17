using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Masters
{
    public class ShapeModel
    {
        public Int32 ShapeId { get; set; }
        public string Size { get; set; }
        public int ShpId { get; set; }
        public string Shape { get; set; }
        public string Description { get; set; }

        [DisplayName("Size Name")]
        public string SizeName
        {
            get
            {
                return Size + "  [" + Shape + "]";
            }
        }
    }
}
