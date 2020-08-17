using AccessDBLayer.Helper;
using Dapper;
using ModelLayer.Masters;
using ServiceLayer.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace AccessDBLayer.Masters
{
    public class LocalMetalRepository : IMetalRepository
    {
        public string AddMetal(MetalModel metal)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_MetalMaster where MetalName = @MetalName ";
                comm.Parameters.AddWithValue("@MetalName", metal.MetalName);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Metal Name already exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Insert into tbl_MetalMaster (MetalName, Rate, IsDefault) values (@MetalName, @Rate, @IsDefault)";
                    comm.Parameters.AddWithValue("@MetalName", metal.MetalName);
                    comm.Parameters.AddWithValue("@Rate", metal.Rate);
                    comm.Parameters.AddWithValue("@IsDefault", metal.IsDefault);
                    Int32 MetalId = OleDBManager.WriteToDbwithIdentity(comm);

                    if (MetalId != 0 && metal.IsDefault == true)
                    {
                        comm = new OleDbCommand();
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = @"update tbl_MetalMaster set IsDefault = 0 where Metalid <> @MetalId";
                        comm.Parameters.AddWithValue("@MetalId", MetalId);
                        OleDBManager.WriteToDbWithoutCommit(comm);
                    }
                    return "Metal Added";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateMetal(MetalModel metal)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = @"Update tbl_MetalMaster set MetalName = @MetalName, Rate = @Rate, IsDefault = @IsDefault where MetalId =  @Metalid";
                comm.Parameters.AddWithValue("@MetalName", metal.MetalName);
                comm.Parameters.AddWithValue("@Rate", metal.Rate);
                comm.Parameters.AddWithValue("@IsDefault", metal.IsDefault);
                comm.Parameters.AddWithValue("@MetalId", metal.MetalId);
                OleDBManager.WriteToDbWithoutCommit(comm);

                if (metal.IsDefault == true)
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"update tbl_MetalMaster set IsDefault = 0 where Metalid <> @MetalId";
                    comm.Parameters.AddWithValue("@MetalId", metal.MetalId);
                    OleDBManager.WriteToDbWithoutCommit(comm);
                }

                return "Metal Updated";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteMetal(short Metalid)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = @"Select * from tbl_Product where MetalId =  @Metalid";
                comm.Parameters.AddWithValue("@MetalId", Metalid);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Metal is Used in Product, Cannot be deleted";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"delete from tbl_MetalMaster where MetalId =  @Metalid";
                    comm.Parameters.AddWithValue("@MetalId", Metalid);
                    OleDBManager.WriteToDbWithoutCommit(comm);

                    return "Metal Deleted";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<MetalModel> GetAllMetal()
        {
            //OleDbCommand comm;
            //try
            //{
            //    comm = new OleDbCommand();
            //    comm.CommandText = @"Select * from tbl_MetalMaster order by IsDefault, MetalName";
            //    return ConvertionHelper.DataTableToList<MetalModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0]);
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
            try
            {
                String query = @"Select * from tbl_MetalMaster order by IsDefault, MetalName";
                return DapperOleDBManager.GetListObject<MetalModel>(query, new DynamicParameters());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public MetalModel GetMetal(short Metalid)
        {
            //OleDbCommand comm;
            //try
            //{
            //    comm = new OleDbCommand();
            //    comm.CommandText = @"Select * from tbl_MetalMaster where (@Metalid  = 0 or Metalid = @Metalid)  order by IsDefault, MetalName";
            //    comm.Parameters.AddWithValue("@Metalid", Metalid);
            //    DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
            //    if (dt != null && dt.Rows.Count > 0)
            //        return ConvertionHelper.ToObject<MetalModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0].Rows[0]);
            //    else
            //        return new MetalModel();
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}

            try
            {
                String query = @"Select * from tbl_MetalMaster where (@Metalid  = 0 or Metalid = @Metalid)  order by IsDefault, MetalName";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Metalid", Metalid);
                return DapperOleDBManager.GetSingleObject<MetalModel>(query, parameters);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}
