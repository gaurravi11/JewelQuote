using AccessDBLayer.Helper;
using ModelLayer.Masters;
using ServiceLayer.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace AccessDBLayer.Masters
{
    public class LocalShapeRepository : IShapeRepository
    {
        public string AddShape(ShpModel shape)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_Shp where [ShpName] = @ShpName";
                comm.Parameters.AddWithValue("@ShpName", shape.ShpName);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ShpId"].ToString();
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Insert into tbl_Shp (ShpName) values (@ShpName)";
                    comm.Parameters.AddWithValue("@ShpName", shape.ShpName);
                    return OleDBManager.WriteToDbwithIdentity(comm).ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UpdateShape(ShpModel shape)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_Shp where ShpName = @ShpName and ShpId <> @ShpId";
                comm.Parameters.AddWithValue("@ShpName", shape.ShpName);
                comm.Parameters.AddWithValue("@ShpId", shape.ShpId);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Shape Name already exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Update tbl_Shp set ShpName = @ShpName where ShpId = @ShpId";
                    comm.Parameters.AddWithValue("@ShpName", shape.ShpName);
                    comm.Parameters.AddWithValue("@ShpId", shape.ShpId);
                    OleDBManager.WriteToDbWithoutCommit(comm);

                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Update tbl_ShapeMaster set Shape = @ShpName where ShpId = @ShpId";
                    comm.Parameters.AddWithValue("@ShpName", shape.ShpName);
                    comm.Parameters.AddWithValue("@ShpId", shape.ShpId);
                    OleDBManager.WriteToDbWithoutCommit(comm);

                    return "Shape Updated";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteShape(short ShapeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShpModel> GetAllShape()
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select ShpId, ShpName from tbl_Shp";
                return ConvertionHelper.DataTableToList<ShpModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ShpModel GetShape(short ShapeId)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select ShpId, ShpName from tbl_Shp where (ShpId = @ShpId) order by ShpName ";
                comm.Parameters.AddWithValue("@ShpId", ShapeId);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                    return ConvertionHelper.ToObject<ShpModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0].Rows[0]);
                else
                    return new ShpModel();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        
    }
}
