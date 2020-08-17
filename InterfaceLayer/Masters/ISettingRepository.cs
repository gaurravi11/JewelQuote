using ModelLayer.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Masters
{
    public interface ISettingRepository
    {
        SettingCategoryModel GetSetting(Int16 SettingId);
        IEnumerable<SettingCategoryModel> GetAllSetting();
        DataTable GetAllSetting_dt();
        string AddSetting(SettingCategoryModel Setting);
        string UpdateSetting(SettingCategoryModel Setting);
        string DeleteSetting(Int16 SettingId);
    }
}
