using AccessDBLayer.Masters;
using AccessDBLayer.Product;
using JewelQuote_ver2.Helper;
using ModelLayer.Masters;
using ModelLayer.Product;
using ServiceLayer.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewelQuote.Product
{
    public partial class FormProduct : Form
    {
        //Interfaces
        ISizeNShapeRepository _shapeNsizeRepository;
        IProductTypeRepository _productTypeRepository;
        ILabourRepository _labourRepository;
        ISettingRepository _settingRepository;
        IMetalRepository _metalRepository;
        IProductRepository _productRepository;

        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        ProductModel product;
        IEnumerable<MetalModel> metalModel;
        Int32 Sno = 0;
        public FormProduct()
        {
            InitializeComponent();

            _shapeNsizeRepository = new LocalShapeNsizeRepository();
            _productTypeRepository = new LocalProductTypeRepository();
            _labourRepository = new LocalLabourRepository();
            _settingRepository = new LocalSettingRepository();
            _metalRepository = new LocalMetalRepository();
            _productRepository = new LocalProductRepository();
        }

        private void reset()
        {
            Sno = 0;
            product = new ProductModel();
            product.productStoneModels = new List<ProductStoneModel>();
            openFileDialog1 = new OpenFileDialog();
            ddlStoneType.SelectedIndex = 0;
            ddlMetal.SelectedIndex = ddlSetting.SelectedIndex = ddlShapeNSize.SelectedIndex = ddlLabour.SelectedIndex = 0;
            pictureBox1.Image = null;
            txtWeight.Text = "";
            dataGridView1.DataSource = null;
            txtLabour.Text = txtSetting.Text = txtMetalCost.Text = "0.00";
            chkCustomLabour.Checked = false;
            ddlType.Focus();
            txtStoneQty.Text = "1";
            if (ddlCode.SelectedIndex > -1)
                txtProductCode.Text = _productRepository.Get_NextProductNoByProductCode(Convert.ToInt32(ddlCode.SelectedValue)).ToString();
        }
        private void GetMetalTotal()
        {
            if (ddlMetal.SelectedIndex >= 0)
                txtMetalCost.Text = (metalModel.Where(x => x.MetalId == Convert.ToInt32(ddlMetal.SelectedValue)).SingleOrDefault().Rate * UtilityUI.getDecimal(txtWeight.Text)).ToString();
            CalcLabour();
        }
        private void CalcLabour()
        {
            if (ddlLabour.SelectedIndex >= 0)
            {
                LabourCategoryModel labourCategoryModel = _labourRepository.GetCategory(Convert.ToInt16(ddlLabour.SelectedValue));
                txtLabour.Text = (UtilityUI.getDecimal(txtWeight.Text) * labourCategoryModel.Rate).ToString();
            }
            else
                txtLabour.Text = "0";
        }
        private void CalcSetting()
        {
            if (ddlSetting.SelectedIndex >= 0 && product.productStoneModels != null)
            {
                SettingCategoryModel categoryModel = _settingRepository.GetSetting(Convert.ToInt16(ddlSetting.SelectedValue));
                txtSetting.Text = (product.productStoneModels.Sum(x => x.Qty) * categoryModel.Rate).ToString();
            }
            else
                txtSetting.Text = "0";
        }

        private void CalcTotalLabour()
        {
            txtTotalLabour.Text = (UtilityUI.getDecimal(txtLabour.Text) + UtilityUI.getDecimal(txtSetting.Text)).ToString();
        }

        private void CalcGhat()
        {
            if (chkCustomLabour.Checked)
            {
                txtGhat.Text = (UtilityUI.getDouble(txtTotalLabour.Text) - UtilityUI.getDouble(txtSetting.Text) + UtilityUI.getDouble(txtMetalCost.Text)).ToString();
            }
            else
            {
                txtGhat.Text = (UtilityUI.getDouble(txtLabour.Text) + UtilityUI.getDouble(txtMetalCost.Text)).ToString();
            }
        }
        private void btnImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.Title = "Please select an Student file";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var img = new Bitmap(openFileDialog1.FileName))
                {
                    pictureBox1.Image = new Bitmap(img);
                }
            }
        }

        private void btnzImageRemove_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            openFileDialog1 = new OpenFileDialog();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {

            ddlType.SelectedIndexChanged -= ddlType_SelectedIndexChanged;
            ddlMetal.SelectedIndexChanged -= ddlMetal_SelectedIndexChanged;
            
            UtilityUI.FillDropDown(ddlMetal, ConvertionHelper.ToDataTable(_metalRepository.GetAllMetal()), "MetalName", "Metalid");
            ddlMetal.SelectedIndexChanged += ddlMetal_SelectedIndexChanged;
            UtilityUI.FillDropDownWithSelect(ddlShapeNSize, _shapeNsizeRepository.GetAllShapeNSize_dt(), "SizeName", "Shapeid");
            ddlLabour.SelectedIndexChanged -= ddlLabour_SelectedIndexChanged;
            UtilityUI.FillDropDown(ddlLabour, (_labourRepository.GetAllCategory_dt()), "CategoryName", "CategoryId");
            ddlLabour.SelectedIndex = -1;
            ddlLabour.SelectedIndexChanged += ddlLabour_SelectedIndexChanged;
            ddlSetting.SelectedIndexChanged -= ddlSetting_SelectedIndexChanged;
            UtilityUI.FillDropDown(ddlSetting, (_settingRepository.GetAllSetting_dt()), "SettingName", "Settingid");
            ddlSetting.SelectedIndex = -1;
            ddlSetting.SelectedIndexChanged += ddlSetting_SelectedIndexChanged;
            
            UtilityUI.FillDropDown(ddlType, ConvertionHelper.ToDataTable(_productTypeRepository.GetAllType()), "Type", "Typeid");
            ddlType.SelectedIndex = -1;
            ddlType.SelectedIndexChanged += ddlType_SelectedIndexChanged;
            ddlType.SelectedIndex = 0;

            metalModel = _metalRepository.GetAllMetal();
            reset();
        }

        private void chkCustomLabour_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomLabour.Checked)
                txtTotalLabour.Enabled = true;
            else
            {
                txtTotalLabour.Enabled = false;
                CalcTotalLabour();
            }
        }

        private void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedIndex > -1)
            {
                ddlCode.SelectedIndexChanged -= ddlCode_SelectedIndexChanged;
                UtilityUI.FillDropDown(ddlCode, ConvertionHelper.ToDataTable(_productTypeRepository.GetCodeByTypeId(Convert.ToInt16(ddlType.SelectedValue))), "Code", "TypeId");
                ddlCode.SelectedIndexChanged += ddlCode_SelectedIndexChanged;
                if (ddlCode.SelectedIndex > -1)
                    txtProductCode.Text = _productRepository.Get_NextProductNoByProductCode(Convert.ToInt32(ddlCode.SelectedValue)).ToString();
            }
        }

        private void ddlLabour_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcLabour();
        }

        private void ddlSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSetting();
        }

        private void ddlCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCode.SelectedIndex > -1)
                txtProductCode.Text = _productRepository.Get_NextProductNoByProductCode(Convert.ToInt32(ddlCode.SelectedValue)).ToString();
        }

        private void chkWithoutStone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWithoutStone.Checked)
            {
                groupBox1.Enabled = false;
                dataGridView1.DataSource = null;
                product.productStoneModels = new List<ProductStoneModel>();
            }
            else
                groupBox1.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlShapeNSize.SelectedIndex <= 0)
            {
                UtilityUI.ShowInfoMsg("Select Shape N' Size of Stone");
                ddlShapeNSize.Focus();
                return;
            }
            if (txtStoneQty.Text == "")
            {
                UtilityUI.ShowInfoMsg("Enter Stone Quantity");
                txtStoneQty.Focus();
                return;
            }

            if (Sno == 0)
            {
                ProductStoneModel productStone = new ProductStoneModel();
                if (product.productStoneModels.Count == 0)
                {
                    productStone.Sno = 1;
                }
                else
                    productStone.Sno = product.productStoneModels.Max(x => x.Sno) + 1;

                productStone.StoneTypeId = Convert.ToInt16(ddlStoneType.SelectedIndex);
                productStone.StoneType = (ddlStoneType.Text);
                productStone.ShapeId = Convert.ToInt16(ddlShapeNSize.SelectedValue);
                productStone.Shape = (ddlShapeNSize.Text);
                productStone.Qty = UtilityUI.getInt32(txtStoneQty.Text);
                product.productStoneModels.Add(productStone);
            }
            else
            {
                var productStone = product.productStoneModels.Where(x => x.Sno == Sno).SingleOrDefault();
                productStone.StoneTypeId = Convert.ToInt16(ddlStoneType.SelectedIndex);
                productStone.StoneType = (ddlStoneType.Text);
                productStone.ShapeId = Convert.ToInt16(ddlShapeNSize.SelectedValue);
                productStone.Shape = (ddlShapeNSize.Text);
                productStone.Qty = UtilityUI.getInt32(txtStoneQty.Text);
            }
            Sno = 0;
            UtilityUI.FillDataGridView_fill(dataGridView1, ConvertionHelper.ToDataTable(product.productStoneModels), new string[] { "ProductShapeid", "ProductId", "ShapeId", "StoneTypeId" }, "Shape");
            ddlShapeNSize.SelectedIndex = 0;
            txtStoneQty.Text = "1";
            ddlStoneType.Focus();
            CalcSetting();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Sno = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["Sno"].Value);
                ddlShapeNSize.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ShapeId"].Value);
                ddlStoneType.SelectedIndex = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["StoneTypeId"].Value);
                txtStoneQty.Text = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value).ToString();
            }
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            GetMetalTotal();
        }

        private void ddlMetal_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMetalTotal();
        }

        private void txtLabour_TextChanged(object sender, EventArgs e)
        {
            CalcTotalLabour();
            CalcGhat();
        }

        private void txtSetting_TextChanged(object sender, EventArgs e)
        {
            CalcTotalLabour();
            CalcGhat();
        }

        private void txtGhat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalLabour_TextChanged(object sender, EventArgs e)
        {
            CalcGhat();
        }

        private void txtMetalCost_TextChanged(object sender, EventArgs e)
        {
            CalcGhat();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlType.SelectedIndex < 0)
                {
                    UtilityUI.ShowInfoMsg("Please Select Product Type");
                    ddlType.Focus();
                    return;
                }
                if (ddlCode.SelectedIndex < 0)
                {
                    UtilityUI.ShowInfoMsg("Please Select Code");
                    ddlCode.Focus();
                    return;
                }
                if (txtProductCode.Text == "")
                {
                    UtilityUI.ShowInfoMsg("Please Enter Product No");
                    txtProductCode.Focus();
                    return;
                }
                if (ddlLabour.SelectedIndex < 0)
                {
                    UtilityUI.ShowInfoMsg("Please Select Labour Category");
                    ddlLabour.Focus();
                    return;
                }
                if (ddlSetting.SelectedIndex < 0)
                {
                    UtilityUI.ShowInfoMsg("Please Select Setting Category");
                    ddlSetting.Focus();
                    return;
                }
                if (ddlMetal.SelectedIndex < 0)
                {
                    UtilityUI.ShowInfoMsg("Please Select Metal");
                    ddlMetal.Focus();
                    return;
                }
                if (UtilityUI.getDecimal(txtWeight.Text) == 0)
                {
                    UtilityUI.ShowInfoMsg("Please Enter Metal Weight");
                    txtWeight.Focus();
                    return;
                }
                if (!chkWithoutStone.Checked)
                {
                    if (product.productStoneModels.Count == 0)
                    {
                        UtilityUI.ShowInfoMsg("Enter Shape N Size of Stone");
                        ddlShapeNSize.Focus();
                        return;
                    }
                }
                string Imagelocation = "";
                if (openFileDialog1.FileName != "")
                {
                    Imagelocation = ddlCode.Text + " " + txtProductCode.Text + (txtSubCode.Text == "" ? "" : " " + txtSubCode.Text);

                    ProductTypeModel productType = _productTypeRepository.GetProductType(Convert.ToInt32(ddlCode.SelectedValue));
                    string sourcePath = "";
                    if (productType != null && productType.FolderLocation != "")
                    {
                        sourcePath = productType.FolderLocation;
                    }
                    else
                    {
                        UtilityUI.ShowErrorMsg("Please set the folder path in Product Type");
                        return;
                    }
                    if (sourcePath == "")
                    {
                        UtilityUI.ShowErrorMsg("Please set the folder path in Product Type");
                        return;
                    }
                    if (System.IO.Directory.Exists(sourcePath))
                    {
                        Imagelocation = Imagelocation + Path.GetExtension(openFileDialog1.FileName);
                        File.Copy(openFileDialog1.FileName, Path.Combine(sourcePath, Imagelocation), true);
                    }
                }
                product.ProductType = Convert.ToInt32(ddlType.SelectedValue);
                product.TypeId = Convert.ToInt16(ddlCode.SelectedValue);
                product.Code = ddlCode.Text;
                product.SrNo = txtProductCode.Text;
                product.Subcode = txtSubCode.Text;
                product.ProductCode = ddlCode.Text + " " + txtProductCode.Text + (txtSubCode.Text == "" ? "" : " " + txtSubCode.Text);
                product.CategoryId = Convert.ToInt32(ddlLabour.SelectedValue);
                product.SettingId = Convert.ToInt32(ddlSetting.SelectedValue);
                product.Metalid = Convert.ToInt32(ddlMetal.SelectedValue);
                product.Weight = UtilityUI.getDecimal(txtWeight.Text);
                product.isWithoutStones = Convert.ToInt16(chkWithoutStone.Checked);
                product.isCustom = chkCustomLabour.Checked;
                product.CustomLabour = product.isCustom == true ? UtilityUI.getDecimal(txtTotalLabour.Text) : 0;
                if (product.productStoneModels.Count == 0)
                    product.NoofStones = 0;
                else
                    product.NoofStones = product.productStoneModels.Sum(x => x.Qty);
                product.ImagePath = Imagelocation;

                string str = "";
                str = _productRepository.AddProduct(product);
                UtilityUI.ShowInfoMsg(str);
                reset();
            }
            catch (Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
