using AccessDBLayer.Helper;
using ModelLayer.Product;
using ServiceLayer.Product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDBLayer.Product
{
    public class LocalProductSearch : IProductSearch
    {
        public DataTable GetProductsSearch(ProductSearchModel productSearchModel)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                if (productSearchModel.isWithoutStone == false)
                {
                    cmd.CommandText = @"select a.ProductId,ProductCode, CategoryName, SettingName, Weight, iif(d.StoneType = 0, 'CUT', 'CAB') as StoneType, 
                                ([Size]+' ('+[e.Shape]+')') as Shape, d.Qty as StoneQty,
                                iif(d.ProductShapeId = (Select Top 1 ProductShapeId from tbl_ProdStoneSize as f where a.ProductId = f.Productid), 1,2) as Cnt, 
                                CLng((Weight * b.Rate) + (d.Qty * c.Rate)) as Labour, CustomLabour
                                from ((((tbl_Product as a
                                inner join tbl_Category as b on a.CategoryId = b.Categoryid)
                                inner join tbl_Setting as c on a.SettingId = c.Settingid)
                                inner join tbl_ProdStoneSize as d on a.ProductId = d.ProductId)
                                inner join tbl_ShapeMaster as e on d.ShapeId = e.ShapeId) where a.ProductType = " + productSearchModel.ProductTypeId.ToString() + " and a.Code = '" + productSearchModel.ProductCode + "'"
                                        + (productSearchModel.ProductFromNo != "" ? " and Srno between " + productSearchModel.ProductFromNo + " and " + productSearchModel.ProductToNo : "")
                                        + (productSearchModel.ProductNos != "" ? " and Srno in (" + productSearchModel.ProductNos + ")" : "")
                                        + " and isWithoutStones = 0 Order by a.ProductId, d.ProductShapeId";
                }
                else
                {
                    cmd.CommandText = @"select a.ProductId,ProductCode, CategoryName, Weight, 0 as StoneQty, CLng(Weight * b.Rate) as Labour, CustomLabour
                                from (tbl_Product as a
                                inner join tbl_Category as b on a.CategoryId = b.Categoryid)
                                where a.ProductType =" + productSearchModel.ProductTypeId + " and a.Code = '" + productSearchModel.ProductCode + "'"
                                       + (productSearchModel.ProductFromNo != "" ? " and Srno between " + productSearchModel.ProductFromNo + " and " + productSearchModel.ProductToNo : "")
                                       + (productSearchModel.ProductNos != "" ? " and Srno in (" + productSearchModel.ProductNos + ")" : "")
                                       + " and isWithoutStones = 1 Order by a.ProductId";
                }
                DataTable dtProduct = OleDBManager.GetDataSetwithCommand(cmd).Tables[0];
                if (productSearchModel.isWithoutStone == false)
                {
                    foreach (DataRow dr in dtProduct.Rows)
                    {
                        if (Convert.ToInt16(dr["Cnt"]) != 1)
                        {
                            dr["ProductCode"] = "";
                            dr["CategoryName"] = "";
                            dr["SettingName"] = "";
                            dr["Weight"] = "0";
                        }
                    }
                }
                return dtProduct;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
