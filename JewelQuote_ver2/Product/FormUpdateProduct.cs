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
    public partial class FormUpdateProduct : Form
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        ISizeNShapeRepository _shapeNsizeRepository;
        IProductTypeRepository _productTypeRepository;
        ILabourRepository _labourRepository;
        ISettingRepository _settingRepository;
        IMetalRepository _metalRepository;
        IProductRepository _productRepository;

        ProductModel product;
        IEnumerable<MetalModel> metalModel;
        Int32 Sno = 0;

        public FormUpdateProduct(Int64 ProductId)
        {
            InitializeComponent();
            _shapeNsizeRepository = new LocalShapeNsizeRepository();
            _productTypeRepository = new LocalProductTypeRepository();
            _labourRepository = new LocalLabourRepository();
            _settingRepository = new LocalSettingRepository();
            _metalRepository = new LocalMetalRepository();
            _productRepository = new LocalProductRepository();

            product = _productRepository.GetProduct(ProductId);
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
        private void fillProduct()
        {
            lblProductCode.Text = product.ProductCode;
            ddlLabour.SelectedValue = product.CategoryId;
            ddlSetting.SelectedValue = product.SettingId;
            ddlMetal.SelectedValue = product.Metalid;
            txtWeight.Text = product.Weight.ToString();
            chkWithoutStone.Checked = Convert.ToBoolean(product.isWithoutStones);
            UtilityUI.FillDataGridView_fill(dataGridView1, ConvertionHelper.ToDataTable(product.productStoneModels), new string[] { "ProductShapeid", "ProductId", "ShapeId", "StoneTypeId" }, "Shape");
            CalcLabour();
            CalcSetting();
            chkCustomLabour.Checked = product.isCustom;
            txtTotalLabour.Text = product.isCustom == true ? product.CustomLabour.ToString() : (UtilityUI.getDecimal(txtLabour.Text) + UtilityUI.getDecimal(txtSetting.Text)).ToString();
            GetMetalTotal();
            CalcGhat();
            if (product.ImagePath != "")
            {
                ProductTypeModel productType = _productTypeRepository.GetProductType(product.TypeId);
                string sourcePath = "";
                if (productType != null && productType.FolderLocation != "")
                {
                    sourcePath = productType.FolderLocation;
                }
                if (Directory.Exists(sourcePath))
                {
                    openFileDialog1.FileName = sourcePath + product.ImagePath;
                    using (var img = new Bitmap(openFileDialog1.FileName))
                    {
                        pictureBox1.Image = new Bitmap(img);
                    }
                }
            }
            
        }

        private void FormUpdateProduct_Load(object sender, EventArgs e)
        {
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
            metalModel = _metalRepository.GetAllMetal();
            fillProduct();
        }

        private void ddlLabour_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcLabour();
        }

        private void ddlSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSetting();
        }

        private void ddlMetal_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMetalTotal();
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            GetMetalTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
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
                    Imagelocation = lblProductCode.Text;

                    ProductTypeModel productType = _productTypeRepository.GetProductType(product.TypeId);
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
                        if (openFileDialog1.FileName != Path.Combine(sourcePath, Imagelocation))
                            File.Copy(openFileDialog1.FileName, Path.Combine(sourcePath, Imagelocation), true);
                    }
                }
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
                str = _productRepository.UpdateProduct(product);
                UtilityUI.ShowInfoMsg(str);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
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

        private void txtTotalLabour_TextChanged(object sender, EventArgs e)
        {
            CalcGhat();
        }

        private void txtMetalCost_TextChanged(object sender, EventArgs e)
        {
            CalcGhat();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (UtilityUI.ShowDialogMsg("Do you want to delete ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    UtilityUI.ShowInfoMsg(_productRepository.DeleteProduct(product.ProductId));
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
