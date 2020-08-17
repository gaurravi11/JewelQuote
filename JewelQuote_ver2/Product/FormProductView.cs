using AccessDBLayer.Masters;
using AccessDBLayer.Product;
using JewelQuote.UserControls;
using JewelQuote_ver2.Helper;
using ModelLayer.Product;
using ServiceLayer.Masters;
using ServiceLayer.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewelQuote.Product
{
    public partial class FormProductView : Form
    {
        IProductSearch _productSearch;
        IProductTypeRepository _productTypeRepository;
        ProductSearchModel productSearchModel;
        public FormProductView()
        {
            InitializeComponent();
            _productSearch = new LocalProductSearch();
            _productTypeRepository = new LocalProductTypeRepository();
        }
        private void FormProductView_Load(object sender, EventArgs e)
        {
            ddlType.SelectedIndexChanged -= ddlType_SelectedIndexChanged;
            UtilityUI.FillDropDown(ddlType, ConvertionHelper.ToDataTable(_productTypeRepository.GetAllType()), "Type", "Typeid");
            ddlType.SelectedIndexChanged += ddlType_SelectedIndexChanged;
            ddlType.SelectedIndex = 0;
        }

        private void ProductDetails()
        {
            try
            {
                productSearchModel = new ProductSearchModel()
                {
                    ProductTypeId = Convert.ToInt32(ddlType.SelectedValue),
                    ProductCode = ddlCode.Text,
                    ProductFromNo = txtFrom.Text,
                    ProductToNo = txtTo.Text,
                    ProductNos = txtNos.Text,
                    isWithoutStone = chkWithoutStone.Checked,
                };
                DataTable products = _productSearch.GetProductsSearch(productSearchModel);
                foreach (DataRow dr in products.Rows)
                    flowLayoutPanel1.Controls.Add(new UProductView(Convert.ToInt32(dr["ProductId"])));
            }
            catch (Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
            }
        }

        private void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedIndex > -1)
            {
                UtilityUI.FillDropDown(ddlCode, ConvertionHelper.ToDataTable(_productTypeRepository.GetCodeByTypeId(Convert.ToInt16(ddlType.SelectedValue))), "Code", "TypeId");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProductDetails();
        }
    }
}
