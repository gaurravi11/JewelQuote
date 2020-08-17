using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Masters
{
    public class ProductTypeModel
    {
        public Int32 TypeId { get; set; }
        public Int16 Id { get; set; }

        [DisplayName("Product Type")]
        public String TypeName { get; set; }
        public String Code { get; set; }

        [DisplayName("isDefault")]
        public Boolean IsDefault { get; set; }
        public String FolderLocation { get; set; }

        
    }
}
