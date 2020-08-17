using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessDBLayer.Helper;
using ModelLayer.Masters;
using ServiceLayer.Masters;

namespace AccessDBLayer.Masters
{
    public class LocalStoneRepository : IStoneRepository
    {
        public string AddStone(StoneModel stone)
        {
            OleDbCommand comm;
            OleDbConnection oleDbConnection = OleDBManager.getConnection();
            OleDbTransaction oleDbTransaction = oleDbConnection.BeginTransaction();
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_StoneMaster where StoneName = @StoneName ";
                comm.Parameters.AddWithValue("@StoneName", stone.StoneName);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    oleDbTransaction.Commit();
                    return "Stone Name already exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.Connection = oleDbConnection;
                    comm.Transaction = oleDbTransaction;
                    comm.CommandText = @"Insert into tbl_StoneMaster (StoneName, SortOrder, Isdefault) values (@StoneName, @SortOrder, @Isdefault)";
                    comm.Parameters.AddWithValue("@StoneName", stone.StoneName);
                    comm.Parameters.AddWithValue("@SortOrder", stone.SortOrder);
                    comm.Parameters.AddWithValue("@Isdefault", stone.IsDefault);
                    Int32 StoneId = OleDBManager.WriteToDbwithIdentityWithConn(comm);

                    if (StoneId > 0)
                    {
                        comm = new OleDbCommand();
                        comm.CommandType = CommandType.Text;
                        comm.Connection = oleDbConnection;
                        comm.Transaction = oleDbTransaction;
                        comm.CommandText = @"Insert into tbl_StoneRate (Stoneid, ShapeId, Weight, Rate, StoneType) Select @StoneId, ShapeId, 0, 0, 0 from tbl_ShapeMaster";
                        comm.Parameters.AddWithValue("@StoneId", StoneId);
                        OleDBManager.WriteToDbWithoutCommitWithConn(comm);

                        comm = new OleDbCommand();
                        comm.CommandType = CommandType.Text;
                        comm.Connection = oleDbConnection;
                        comm.Transaction = oleDbTransaction;
                        comm.CommandText = @"Insert into tbl_StoneRate (Stoneid, ShapeId, Weight, Rate, StoneType) Select @StoneId, ShapeId, 0, 0, 1 from tbl_ShapeMaster";
                        comm.Parameters.AddWithValue("@StoneId", StoneId);
                        OleDBManager.WriteToDbWithoutCommitWithConn(comm);
                    }
                    oleDbTransaction.Commit();
                    return "Stone Added";
                }
            }
            catch (Exception ex)
            {
                oleDbTransaction.Rollback();
                throw ex;
            }
            finally
            {
                oleDbConnection.Close();
                oleDbConnection.Dispose();
            }
        }
        public string UpdateStone(StoneModel stone)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_StoneMaster where StoneName = @StoneName and StoneId <> @StoneId ";
                comm.Parameters.AddWithValue("@StoneName", stone.StoneName);
                comm.Parameters.AddWithValue("@StoneId", stone.StoneId);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Stone Name already exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Update tbl_StoneMaster set StoneName = @StoneName, SortOrder = @SortOrder, Isdefault = @Isdefault where StoneId = @StoneId";
                    comm.Parameters.AddWithValue("@StoneName", stone.StoneName);
                    comm.Parameters.AddWithValue("@SortOrder", stone.SortOrder);
                    comm.Parameters.AddWithValue("@Isdefault", stone.IsDefault);
                    comm.Parameters.AddWithValue("@StoneId", stone.StoneId);
                    OleDBManager.WriteToDbWithoutCommit(comm);

                    return "Stone Updated";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public string DeleteStone(short Stoneid)
        {
            OleDbCommand comm;
            OleDbConnection oleDbConnection = OleDBManager.getConnection();
            OleDbTransaction oleDbTransaction = oleDbConnection.BeginTransaction();
            try
            {
                comm = new OleDbCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = @"Select * from tbl_ProductStone where MetalId =  @Metalid";
                comm.Parameters.AddWithValue("@StoneId", Stoneid);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    oleDbTransaction.Commit();
                    return "Stone is Used in Product, Cannot be deleted";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.Connection = oleDbConnection;
                    comm.Transaction = oleDbTransaction;
                    comm.CommandText = @"delete from tbl_StoneMaster where StoneId = @StoneId";
                    comm.Parameters.AddWithValue("@StoneId", Stoneid);
                    OleDBManager.WriteToDbWithoutCommitWithConn(comm);

                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.Connection = oleDbConnection;
                    comm.Transaction = oleDbTransaction;
                    comm.CommandText = @"delete from tbl_StoneRate where StoneId = @StoneId";
                    comm.Parameters.AddWithValue("@StoneId", Stoneid);
                    OleDBManager.WriteToDbWithoutCommitWithConn(comm);

                    oleDbTransaction.Commit();
                    return "Stone Deleted";
                }
            }
            catch (Exception ex)
            {
                oleDbTransaction.Commit();
                throw ex;
            }
            finally
            {
                oleDbConnection.Close();
                oleDbConnection.Dispose();
            }
        }

        public IEnumerable<StoneModel> GetAllStone()
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select StoneName, StoneId, SortOrder, IsDefault from tbl_StoneMaster order by sortorder, StoneName ";
                return ConvertionHelper.DataTableToList<StoneModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public StoneModel GetStone(short Stoneid)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select StoneName, StoneId, SortOrder, IsDefault from tbl_StoneMaster where (StoneId = @StoneId) order by sortorder ";
                comm.Parameters.AddWithValue("@StoneId", Stoneid);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                    return ConvertionHelper.ToObject<StoneModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0].Rows[0]);
                else
                    return new StoneModel();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public short getNextSortOrder()
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select iif(max(sortorder) is null,1,max(sortorder)+1) as Sortorder from tbl_stonemaster ";
                return (Convert.ToInt16(OleDBManager.GetDataSetwithCommand(comm).Tables[0].Rows[0]["Sortorder"]));
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public bool SortOrderExists(short SortOrder)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_stonemaster where sortorder = @sortorder ";
                comm.Parameters.AddWithValue("@sortorder", SortOrder);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];

                if (dt == null || dt.Rows.Count == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
    }
}
