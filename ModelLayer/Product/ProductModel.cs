using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Product
{
    public class ProductModel
    {
        public Int64 ProductId { get; set; }
        public Int32 ProductType { get; set; }
        public Int16 TypeId { get; set; }
        public string Code { get; set; }
        public string Subcode { get; set; }
        public string SrNo { get; set; }
        public string ProductCode { get; set; }
        public Int32 CategoryId { get; set; }
        public Int32 SettingId { get; set; }
        public Int32 Metalid { get; set; }
        public decimal Weight { get; set; }
        public Boolean isCustom { get; set; }
        public decimal CustomLabour { get; set; }
        public string ImagePath { get; set; }
        public int NoofStones { get; set; }
        public Int16 isWithoutStones { get; set; }
        public List<ProductStoneModel> productStoneModels { get; set; }
    }

    public class ProductStoneModel
    {
        public Int64 ProductShapeid { get; set; }
        public Int32 Sno { get; set; }
        public Int64 ProductId { get; set; }
        public Int32 StoneTypeId { get; set; }
        public String StoneType { get; set; }
        public Int32 ShapeId { get; set; }
        public String Shape { get; set; }
        public Int32 Qty { get; set; }
        
    }
}
