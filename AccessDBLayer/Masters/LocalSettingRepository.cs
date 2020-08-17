using AccessDBLayer.Helper;
using ModelLayer.Masters;
using ServiceLayer.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDBLayer.Masters
{
    public class LocalSettingRepository : ISettingRepository
    {
        public SettingCategoryModel GetSetting(short SettingId)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_Setting where (@SettingId  = 0 or SettingId = @SettingId)";
                comm.Parameters.AddWithValue("@SettingId", SettingId);
                return ConvertionHelper.ToObject<SettingCategoryModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SettingCategoryModel> GetAllSetting()
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_Setting order by IsDefault, SettingName";
                return ConvertionHelper.DataTableToList<SettingCategoryModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetAllSetting_dt()
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_Setting order by IsDefault, SettingName";
                return (OleDBManager.GetDataSetwithCommand(comm).Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string AddSetting(SettingCategoryModel Setting)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_Setting where [SettingName] = @SettingName";
                comm.Parameters.AddWithValue("@SettingName", Setting.SettingName);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Stone Setting Category already exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Insert into tbl_Setting (SettingName, Rate, IsDefault) values (@SettingName, @Rate, @IsDefault)";
                    comm.Parameters.AddWithValue("@SettingName", Setting.SettingName);
                    comm.Parameters.AddWithValue("@Rate", Setting.Rate);
                    comm.Parameters.AddWithValue("@IsDefault", Setting.IsDefault);
                    Int32 Id = OleDBManager.WriteToDbwithIdentity(comm);

                    if (Setting.IsDefault == true && Id != 0)
                    {
                        comm.CommandText = @"Update tbl_Setting set IsDefault = 0 where SettingId <> @SettingId and IsDefault = YES";
                        comm.Parameters.AddWithValue("@SettingId", Id);
                        OleDBManager.WriteToDbWithoutCommit(comm);
                    }

                    return "Stone Setting Category Added";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UpdateSetting(SettingCategoryModel Setting)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_Setting where [SettingName] = @SettingName and SettingId <> @SettingId";
                comm.Parameters.AddWithValue("@SettingName", Setting.SettingName);
                comm.Parameters.AddWithValue("@SettingId", Setting.SettingId);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Stone Setting Category already exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Update tbl_Setting set SettingName = @SettingName, Rate = @Rate, IsDefault = @IsDefault where SettingId =  @SettingId";
                    comm.Parameters.AddWithValue("@SettingName", Setting.SettingName);
                    comm.Parameters.AddWithValue("@Rate", Setting.Rate);
                    comm.Parameters.AddWithValue("@IsDefault", Setting.IsDefault);
                    comm.Parameters.AddWithValue("@SettingId", Setting.SettingId);
                    OleDBManager.WriteToDbWithoutCommit(comm);

                    if (Setting.IsDefault == true)
                    {
                        comm.CommandText = @"Update tbl_Setting set IsDefault = 0 where SettingId <> @SettingId and IsDefault = YES";
                        comm.Parameters.AddWithValue("@SettingId", Setting.SettingId);
                        OleDBManager.WriteToDbWithoutCommit(comm);
                    }

                    return "Stone Setting Category Type Updated";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteSetting(short SettingId)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = @"Select * from tbl_Product where SettingId =  @SettingId";
                comm.Parameters.AddWithValue("@SettingId", SettingId);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Setting Category is Used in Product, Cannot be deleted";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"delete from tbl_Setting where SettingId =  @SettingId";
                    comm.Parameters.AddWithValue("@SettingId", SettingId);
                    OleDBManager.WriteToDbWithoutCommit(comm);

                    return "Setting Category Deleted";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
