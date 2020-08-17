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
    public class LocalLabourRepository : ILabourRepository
    {
        public IEnumerable<LabourCategoryModel> GetAllCategory()
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select CategoryId, CategoryName, Rate, IsDefault from tbl_Category order by IsDefault, CategoryName";
                return ConvertionHelper.DataTableToList<LabourCategoryModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetAllCategory_dt()
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select CategoryId, CategoryName, Rate, IsDefault from tbl_Category order by IsDefault, CategoryName";
                return (OleDBManager.GetDataSetwithCommand(comm).Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public LabourCategoryModel GetCategory(short CategoryId)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select CategoryId, CategoryName, Rate, IsDefault from tbl_Category where (@CategoryId  = 0 or CategoryId = @CategoryId) order by IsDefault";
                comm.Parameters.AddWithValue("@CategoryId", CategoryId);
                return ConvertionHelper.ToObject<LabourCategoryModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string AddCategory(LabourCategoryModel Category)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_Category where [CategoryName] = @CategoryName";
                comm.Parameters.AddWithValue("@CategoryName", Category.CategoryName);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Labour Category already exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Insert into tbl_Category (CategoryName, Rate, IsDefault) values (@CategoryName, @Rate, @IsDefault)";
                    comm.Parameters.AddWithValue("@CategoryName", Category.CategoryName);
                    comm.Parameters.AddWithValue("@Rate", Category.Rate);
                    comm.Parameters.AddWithValue("@IsDefault", Category.IsDefault);
                    Int32 Id = OleDBManager.WriteToDbwithIdentity(comm);

                    if (Category.IsDefault == true && Id != 0)
                    {
                        comm.CommandText = @"Update tbl_Category Set Isdefault = 0 where CategoryId <> @CategoryId and IsDefault = YES";
                        comm.Parameters.AddWithValue("@CategoryId", Id);
                        OleDBManager.WriteToDbWithoutCommit(comm);
                    }
                    return "Labour Category Added";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdateCategory(LabourCategoryModel Category)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_Category where [CategoryName] = @CategoryName and Categoryid <> @Categoryid";
                comm.Parameters.AddWithValue("@CategoryName", Category.CategoryName);
                comm.Parameters.AddWithValue("@Categoryid", Category.CategoryId);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Labour Category already exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Update tbl_Category set CategoryName = @CategoryName, Rate = @Rate, IsDefault = @IsDefault where CategoryId = @CategoryId";
                    comm.Parameters.AddWithValue("@CategoryName", Category.CategoryName);
                    comm.Parameters.AddWithValue("@Rate", Category.Rate);
                    comm.Parameters.AddWithValue("@IsDefault", Category.IsDefault);
                    comm.Parameters.AddWithValue("@Categoryid", Category.CategoryId);
                    OleDBManager.WriteToDbWithoutCommit(comm);

                    if (Category.IsDefault == true)
                    {
                        comm.CommandText = @"Update tbl_Category Set Isdefault=0 where CategoryId <> @CategoryId and IsDefault = YES";
                        comm.Parameters.AddWithValue("@CategoryId", Category.CategoryId);
                        OleDBManager.WriteToDbWithoutCommit(comm);
                    }

                    return "Labour Category Updated";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteCategory(short CategoryId)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = @"Select * from tbl_Product where CategoryId =  @CategoryId";
                comm.Parameters.AddWithValue("@CategoryId", CategoryId);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Labour Category is Used in Product, Cannot be deleted";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"delete from tbl_Category where CategoryId =  @CategoryId";
                    comm.Parameters.AddWithValue("@CategoryId", CategoryId);
                    OleDBManager.WriteToDbWithoutCommit(comm);

                    return "Labour Category Deleted";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
