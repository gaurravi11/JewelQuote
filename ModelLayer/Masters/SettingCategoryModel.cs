using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Masters
{
    public class SettingCategoryModel
    {
        public Int16 SettingId { get; set; }

        [DisplayName("Setting Category")]
        public string SettingName { get; set; }
        public decimal Rate { get; set; }

        [DisplayName("isDefault")]
        public Boolean IsDefault { get; set; }
    }
}
