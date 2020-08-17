using ModelLayer.Product;
using ServiceLayer.Product;
using AccessDBLayer.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JewelQuote_ver2.Helper;
using System.IO;
using ServiceLayer.Masters;
using AccessDBLayer.Masters;

namespace JewelQuote.Product
{
    public partial class FormProductList : Form
    {
        IProductSearch _productSearch;
        IProductTypeRepository _productTypeRepository;
        ProductSearchModel productSearchModel;
        public FormProductList()
        {
            InitializeComponent();
            _productSearch = new LocalProductSearch();
            _productTypeRepository = new LocalProductTypeRepository();
        }

        private void FormProductList_Load(object sender, EventArgs e)
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

                if (productSearchModel.isWithoutStone == false)
                    UtilityUI.FillDataGridView(dataGridView1, _productSearch.GetProductsSearch(productSearchModel), new string[] { "Productid", "Cnt" });
                else
                    UtilityUI.FillDataGridView(dataGridView1, _productSearch.GetProductsSearch(productSearchModel), new string[] { "Productid" });
            }
            catch (Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProductDetails();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            UtilityUI.ExportToExcel(dataGridView1);
        }

        private void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedIndex > -1)
            {
                UtilityUI.FillDropDown(ddlCode, ConvertionHelper.ToDataTable(_productTypeRepository.GetCodeByTypeId(Convert.ToInt16(ddlType.SelectedValue))), "Code", "TypeId");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Int32 ProductId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ProductId"].Value);

                FormUpdateProduct frm = new FormUpdateProduct(ProductId);
                frm.ShowDialog();
                ProductDetails();
            }
        }
    }
}
