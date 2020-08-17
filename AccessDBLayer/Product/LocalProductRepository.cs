using AccessDBLayer.Helper;
using ModelLayer.Product;
using ServiceLayer.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDBLayer.Product
{
    public class LocalProductRepository : IProductRepository
    {
        public string AddProduct(ProductModel productModel)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_Product where [ProductCode] = @ProductCode";
                comm.Parameters.AddWithValue("@ProductCode", productModel.ProductCode);
                DataTable dt = OleDBManager.GetDataSetwithCommand(comm).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return "Product already exists";
                }
                else
                {
                    comm = new OleDbCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = @"Insert into tbl_Product (ProductType, Code,Subcode, SrNo, ProductCode, CategoryId, SettingId, Metalid, Weight, isCustom, CustomLabour, ImagePath, NoofStones, TypeId, isWithoutStones) 
                                        values (@ProductType, @Code,@Subcode, @SrNo, @ProductCode, @CategoryId, @SettingId, @MetalId, @Weight, @isCustom, @CustomLabour, @ImagePath, @NoofStones, @TypeId, @isWithoutStones)";
                    comm.Parameters.AddWithValue("@ProductType", productModel.ProductType);
                    comm.Parameters.AddWithValue("@Code", productModel.Code);
                    comm.Parameters.AddWithValue("@SubCode", productModel.Subcode);
                    comm.Parameters.AddWithValue("@SrNo", productModel.SrNo);
                    comm.Parameters.AddWithValue("@ProductCode", productModel.ProductCode);
                    comm.Parameters.AddWithValue("@CategoryId", productModel.CategoryId);
                    comm.Parameters.AddWithValue("@SettingId", productModel.SettingId);
                    comm.Parameters.AddWithValue("@Metalid", productModel.Metalid);
                    comm.Parameters.AddWithValue("@Weight", productModel.Weight);
                    comm.Parameters.AddWithValue("@isCustom", productModel.isCustom);
                    comm.Parameters.AddWithValue("@CustomLabour", productModel.CustomLabour);
                    comm.Parameters.AddWithValue("@ImagePath", productModel.ImagePath);
                    comm.Parameters.AddWithValue("@NoofStones", productModel.NoofStones);
                    comm.Parameters.AddWithValue("@TypeId", productModel.TypeId);
                    comm.Parameters.AddWithValue("@isWithoutStones", productModel.isWithoutStones);
                    Int32 ProductId = OleDBManager.WriteToDbwithIdentity(comm);

                    if (productModel.isWithoutStones == 0)
                    {
                        if (ProductId > 0 && dt != null)
                        {
                            foreach (var dr in productModel.productStoneModels)
                            {
                                comm = new OleDbCommand();
                                comm.CommandType = CommandType.Text;
                                comm.CommandText = @"Insert into tbl_ProdStoneSize (ProductId, ShapeId, Qty, StoneType) values (@ProductId, @ShapeId, @Qty, @StoneTypeId)";
                                comm.Parameters.AddWithValue("@ProductId", ProductId);
                                comm.Parameters.AddWithValue("@ShapeId", dr.ShapeId);
                                comm.Parameters.AddWithValue("@Qty", dr.Qty);
                                comm.Parameters.AddWithValue("@StoneTypeId", dr.StoneTypeId);
                                OleDBManager.WriteToDb(comm);
                            }
                        }
                    }
                    return "Product Added";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteProduct(long ProductId)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = @"delete from tbl_Product where ProductId = @ProductId";
                comm.Parameters.AddWithValue("@ProductId", ProductId);
                OleDBManager.WriteToDb(comm);

                comm = new OleDbCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = @"delete from tbl_ProdStoneSize where ProductId = @ProductId";
                comm.Parameters.AddWithValue("@ProductId", ProductId);
                OleDBManager.WriteToDb(comm);

                return "Product Deleted";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public IEnumerable<ProductModel> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProduct(long ProductId)
        {
            ProductModel productModel = new ProductModel();
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select * from tbl_Product where ProductId = @ProductId";
                comm.Parameters.AddWithValue("@ProductId", ProductId);
                productModel = ConvertionHelper.ToObject<ProductModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0].Rows[0]);

                comm = new OleDbCommand();
                comm.CommandText = @"Select iif(StoneType=0, 'CUT', 'CAB') as StoneType, StoneType as StoneTypeId,([Size]+' ('+[b.Shape]+')') as Shape, a.ShapeId, Qty   
                                    from (tbl_ProdStoneSize  as a inner join tbl_Shapemaster as b on a.ShapeId = b.ShapeId) where (ProductId = @ProductId) ";
                comm.Parameters.AddWithValue("@ProductId", ProductId);
                productModel.productStoneModels = ConvertionHelper.DataTableToList<ProductStoneModel>(OleDBManager.GetDataSetwithCommand(comm).Tables[0]);

                return productModel;
            }
            catch (Exception ex)
            {
                return productModel;
            }
        }

        public int Get_NextProductNoByProductCode(int ProductCode)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select Max(Srno)+1 as Sno from tbl_Product where TypeId = @TypeId";
                comm.Parameters.AddWithValue("@TypeId", ProductCode);
                OleDbDataReader rdr = OleDBManager.getReaderSP(comm);
                Int32 EnquiryNo = 0;
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        EnquiryNo = Convert.ToInt32(rdr["Sno"] == DBNull.Value ? 1 : rdr["Sno"]);
                    }
                }
                return EnquiryNo;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Get_NextProductNoByProductType(int ProductType)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandText = @"Select Max(Srno)+1 as Sno from tbl_Product where ProductType = @ProductType";
                comm.Parameters.AddWithValue("@ProductType", ProductType);
                OleDbDataReader rdr = OleDBManager.getReaderSP(comm);
                Int32 EnquiryNo = 0;
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        EnquiryNo = Convert.ToInt32(rdr["Sno"] == DBNull.Value ? 1 : rdr["Sno"]);
                    }
                }
                return EnquiryNo;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public string UpdateProduct(ProductModel productModel)
        {
            OleDbCommand comm;
            try
            {
                comm = new OleDbCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = @"Update tbl_Product set CategoryId = @CategoryId, SettingId = @SettingId, Metalid = @MetalId, Weight = @Weight, isCustom = @IsCustom, 
                                    CustomLabour=@CustomLabour, ImagePath=@ImagePath, NoofStones=@NoofStones, isWithoutStones = @isWithoutStones where ProductId = @ProductId";
                comm.Parameters.AddWithValue("@CategoryId", productModel.CategoryId);
                comm.Parameters.AddWithValue("@SettingId", productModel.SettingId);
                comm.Parameters.AddWithValue("@Metalid", productModel.Metalid);
                comm.Parameters.AddWithValue("@Weight", productModel.Weight);
                comm.Parameters.AddWithValue("@isCustom", productModel.isCustom);
                comm.Parameters.AddWithValue("@CustomLabour", productModel.CustomLabour);
                comm.Parameters.AddWithValue("@ImagePath", productModel.ImagePath);
                comm.Parameters.AddWithValue("@NoofStones", productModel.NoofStones);
                comm.Parameters.AddWithValue("@isWithoutStones", productModel.isWithoutStones);
                comm.Parameters.AddWithValue("@ProductId", productModel.ProductId);
                OleDBManager.WriteToDbWithoutCommit(comm);

                comm = new OleDbCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = @"delete from tbl_ProdStoneSize where ProductId = @ProductId";
                comm.Parameters.AddWithValue("@ProductId", productModel.ProductId);
                OleDBManager.WriteToDb(comm);

                if (productModel.isWithoutStones == 0)
                {
                    if (productModel.ProductId > 0)
                    {
                        foreach (var dr in productModel.productStoneModels)
                        {
                            comm = new OleDbCommand();
                            comm.CommandType = CommandType.Text;
                            comm.CommandText = @"Insert into tbl_ProdStoneSize (ProductId, ShapeId, Qty, StoneType) values (@ProductId, @ShapeId, @Qty, @StoneTypeId)";
                            comm.Parameters.AddWithValue("@ProductId", productModel.ProductId);
                            comm.Parameters.AddWithValue("@ShapeId", dr.ShapeId);
                            comm.Parameters.AddWithValue("@Qty", dr.Qty);
                            comm.Parameters.AddWithValue("@StoneTypeId", dr.StoneTypeId);
                            OleDBManager.WriteToDb(comm);
                        }
                    }
                }
                return "Product Updated";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
