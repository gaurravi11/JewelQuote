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
    public class LocalProductTypeRepository : IProductTypeRepository
    {
        public TypeModel GetType(Int32 Typeid)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select TypeId, Type from tbl_Type where (TypeId = @TypeId)";
                comm.Parameters.AddWithValue("@Typeid", Typeid);
                return ConvertionHelper.ToObject<TypeModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<TypeModel> GetAllType()
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select TypeId, Type from tbl_Type order by Type";
                return ConvertionHelper.DataTableToList<TypeModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string AddType(TypeModel type)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_Type where [Type] = @Type";
                comm.Parameters.AddWithValue("@Type", type.Type);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Product Type already Exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Insert into tbl_Type (Type) values (@Type)";
                    comm.Parameters.AddWithValue("@Type", type.Type);
                    OleDBManager.WriteToDbWithoutCommit(comm);

                    return "Product Type Added";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UpdateType(TypeModel type)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_Type where [Type] = @Type and TypeId <> @TypeId";
                comm.Parameters.AddWithValue("@Type", type.Type);
                comm.Parameters.AddWithValue("@TypeId", type.TypeId);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Product Type already Exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Update tbl_Type set Type = @Type where TypeId = @TypeId";
                    comm.Parameters.AddWithValue("@Type", type.Type);
                    comm.Parameters.AddWithValue("@TypeId", type.TypeId);
                    OleDBManager.WriteToDbWithoutCommit(comm);

                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Update tbl_ProductType set TypeName = @TypeName where Id = @TypeId";
                    comm.Parameters.AddWithValue("@TypeName", type.Type);
                    comm.Parameters.AddWithValue("@TypeId", type.TypeId);
                    OleDBManager.WriteToDbWithoutCommit(comm);

                    return "Product Type Updated";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteType(Int32 Typeid)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = @"Select * from tbl_ProductType where Id =  @Typeid";
                comm.Parameters.AddWithValue("@Typeid", Typeid);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Product Type with Code Exists, Cannot be deleted";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"delete from tbl_Type where Typeid =  @Typeid";
                    comm.Parameters.AddWithValue("@Typeid", Typeid);
                    OleDBManager.WriteToDbWithoutCommit(comm);

                    return "Product Type Deleted";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductTypeModel GetProductType(int ProductTypeid)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_ProductType where TypeId = @Typeid order by Isdefault ";
                comm.Parameters.AddWithValue("@Typeid", ProductTypeid);
                return ConvertionHelper.ToObject<ProductTypeModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<ProductTypeModel> GetAllProductType()
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_ProductType order by Isdefault ";
                return ConvertionHelper.DataTableToList<ProductTypeModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string AddProductType(ProductTypeModel productType)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_ProductType where Id = @Id and Code = @Code";
                comm.Parameters.AddWithValue("@Id", productType.Id);
                comm.Parameters.AddWithValue("@Code", productType.Code);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Product Type with code Already Exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandText = @"Select * from tbl_ProductType where Id = @Id and IsDefault = Yes ";
                    comm.Parameters.AddWithValue("@Id", productType.Id);
                    dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                    if (dt.Rows.Count > 0 && productType.IsDefault == true)
                    {
                        return "Product Type already have default code";
                    }
                    else
                    {
                        comm = new OleDbCommand();
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = @"Insert into tbl_ProductType (Id ,TypeName, Code, IsDefault, FolderLocation) values (@Id, @TypeName, @Code, @IsDefault, @FolderLocation)";
                        comm.Parameters.AddWithValue("@Id", productType.Id);
                        comm.Parameters.AddWithValue("@TypeName", productType.TypeName);
                        comm.Parameters.AddWithValue("@Code", productType.Code);
                        comm.Parameters.AddWithValue("@IsDefault", productType.IsDefault);
                        comm.Parameters.AddWithValue("@FolderLocation", productType.FolderLocation);
                        OleDBManager.WriteToDbWithoutCommit(comm);
                        return "Product Type Saved";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        public string UpdateProductType(ProductTypeModel productType)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_ProductType where Id = @Id and Code = @Code and TypeId <> @TypeId";
                comm.Parameters.AddWithValue("@Id", productType.Id);
                comm.Parameters.AddWithValue("@Code", productType.Code);
                comm.Parameters.AddWithValue("@TypeId", productType.TypeId);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Product Type with code Already Exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandText = @"Select * from tbl_ProductType where [Id] = @Id and IsDefault = Yes and TypeId <> @TypeId ";
                    comm.Parameters.AddWithValue("@Id", productType.Id);
                    comm.Parameters.AddWithValue("@TypeId", productType.TypeId);
                    dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                    if (dt.Rows.Count > 0 && productType.IsDefault == true)
                    {
                        return "Product Type already have default code";
                    }
                    else
                    {
                        comm = new OleDbCommand();
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = @"Update tbl_ProductType set Id = @Id ,TypeName = @TypeName, Code = @Code, IsDefault = @IsDefault, FolderLocation = @FolderLocation where TypeId = @TypeId";
                        comm.Parameters.AddWithValue("@Id", productType.Id);
                        comm.Parameters.AddWithValue("@TypeName", productType.TypeName);
                        comm.Parameters.AddWithValue("@Code", productType.Code);
                        comm.Parameters.AddWithValue("@IsDefault", productType.IsDefault);
                        comm.Parameters.AddWithValue("@FolderLocation", productType.FolderLocation);
                        comm.Parameters.AddWithValue("@TypeId", productType.TypeId);
                        OleDBManager.WriteToDbWithoutCommit(comm);
                        return "Product Type Updated";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteProductType(int ProductTypeid)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = @"Select * from tbl_Product where Typeid = (@TypeId)";
                comm.Parameters.AddWithValue("@TypeId", ProductTypeid);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Product Type with code is Used in Product, Cannot be deleted";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"delete from tbl_ProductType where Typeid = (@TypeId)";
                    comm.Parameters.AddWithValue("@TypeId", ProductTypeid);
                    OleDBManager.WriteToDbWithoutCommit(comm);

                    return "Product Type with code Deleted";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public IEnumerable<ProductTypeModel> GetCodeByTypeId(int Typeid)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_ProductType where (Id = @TypeId) order by Isdefault ";
                comm.Parameters.AddWithValue("@TypeId", Typeid);
                return ConvertionHelper.DataTableToList<ProductTypeModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        
    }
}
