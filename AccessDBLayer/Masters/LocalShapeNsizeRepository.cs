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
    public class LocalShapeNsizeRepository : ISizeNShapeRepository
    {
        public string AddShapeNSize(ShapeModel shape)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_ShapeMaster where [ShpId] = @ShpId and [Size] = @Size ";
                comm.Parameters.AddWithValue("@ShpId", shape.ShpId);
                comm.Parameters.AddWithValue("@Size", shape.Size);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Shape N' Size already exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Insert into tbl_ShapeMaster ([Size], [Shape], ShpId) values (@Size, @Shape, @ShpId)";
                    comm.Parameters.AddWithValue("@Size", shape.Size);
                    comm.Parameters.AddWithValue("@Shape", shape.Shape);
                    comm.Parameters.AddWithValue("@ShpId", shape.ShpId);
                    Int32 ShapeId = OleDBManager.WriteToDbwithIdentity(comm);

                    if (ShapeId > 0)
                    {
                        comm = new OleDbCommand();
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = @"Insert into tbl_StoneRate (Stoneid, ShapeId, Weight, Rate, StoneType) Select StoneId, @ShapeId, 0, 0, 0 from tbl_StoneMaster";
                        comm.Parameters.AddWithValue("@ShapeId", ShapeId);
                        OleDBManager.WriteToDbWithoutCommit(comm);

                        comm.CommandText = @"Insert into tbl_StoneRate (Stoneid, ShapeId, Weight, Rate, StoneType) Select StoneId, @ShapeId, 0, 0, 1 from tbl_StoneMaster";
                        comm.Parameters.AddWithValue("@ShapeId", ShapeId);
                        OleDBManager.WriteToDbWithoutCommit(comm);
                    }

                    return "Shape N' Size Added";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdateShapeNSize(ShapeModel shape)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_ShapeMaster where [ShpId] = @ShpId and [Size] = @Size and ShapeId <> @ShapeId";
                comm.Parameters.AddWithValue("@ShpId", shape.ShpId);
                comm.Parameters.AddWithValue("@Size", shape.Size);
                comm.Parameters.AddWithValue("@ShapeId", shape.ShapeId);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Shape N' Size already exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandText = @"update tbl_ShapeMaster set [Size] = @Size, [Shape] = @Shape, ShpId = @ShpId where ShapeId = @ShapeId";
                    comm.Parameters.AddWithValue("@Size", shape.Size);
                    comm.Parameters.AddWithValue("@Shape", shape.Shape);
                    comm.Parameters.AddWithValue("@ShpId", shape.ShpId);
                    comm.Parameters.AddWithValue("@ShapeId", shape.ShapeId);
                    OleDBManager.WriteToDbWithoutCommit(comm);
                    return "Shape N' Size Updated";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteShapeNSize(short ShapeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShapeModel> GetAllShapeNSize()
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_ShapeMaster";
                return ConvertionHelper.DataTableToList<ShapeModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetAllShapeNSize_dt()
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select *, ([Size]+' ('+[Shape]+')') as SizeName from tbl_ShapeMaster";
                return OleDBManager.GetDataSetwithCommand(comm).Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ShapeModel GetShapeNSize(short ShapeId)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_ShapeMaster where ShapeId = @ShapeId";
                comm.Parameters.AddWithValue("@ShapeId", ShapeId);
                return ConvertionHelper.ToObject<ShapeModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       
    }
}
