using AccessDBLayer.Masters;
using JewelQuote_ver2.Helper;
using ModelLayer.Masters;
using ServiceLayer.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewelQuote.Masters
{
    public partial class FormProductType : Form
    {
        private IProductTypeRepository _productTypeRepository;
        TypeModel typeModel;
        ProductTypeModel ProductTypeModel;
        public FormProductType()
        {
            InitializeComponent();
            _productTypeRepository = new LocalProductTypeRepository();
        }

        private void reset_type()
        {
            typeModel = new TypeModel();
            txtType.Text = "";
            UtilityUI.FillDataGridView_fill(dataGridView1, _productTypeRepository.GetAllType(), new string[] { "TypeId" }, "Type");
            txtType.Focus();
            btnSave1.Text = "Save";
        }

        private void reset_producttype()
        {
            ProductTypeModel = new ProductTypeModel();
            txtCode.Text = txtFolder.Text = "";
            chkDefault.Checked = false;
            UtilityUI.FillDataGridView(dataGridView2, _productTypeRepository.GetAllProductType(), new string[] { "TypeId", "Id" });
            ddlType.Focus();
            ddlType.SelectedIndex = 0;
            btnSave2.Text = "Save";
        }

        private void FormProductType_Load(object sender, EventArgs e)
        {
            UtilityUI.FillDropDownWithSelect(ddlType, ConvertionHelper.ToDataTable(_productTypeRepository.GetAllType()), "Type", "TypeId");
            reset_type();
            reset_producttype();
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtType.Text == "")
                {
                    UtilityUI.ShowInfoMsg("Please Enter Product Type");
                    txtType.Focus();
                    return;
                }
                
                string result = "";

                typeModel.Type = txtType.Text;

                if (typeModel.TypeId == 0)
                    result = _productTypeRepository.AddType(typeModel);
                else
                {
                    result = _productTypeRepository.UpdateType(typeModel);
                    UtilityUI.FillDataGridView(dataGridView2, _productTypeRepository.GetAllProductType(), new string[] { "TypeId", "Id" });
                }

                UtilityUI.ShowInfoMsg(result);
                reset_type();
                UtilityUI.FillDropDownWithSelect(ddlType, ConvertionHelper.ToDataTable(_productTypeRepository.GetAllType()), "Type", "TypeId");
            }
            catch (Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
            }
        }

        private void btnReset1_Click(object sender, EventArgs e)
        {
            reset_type();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                typeModel.TypeId = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["TypeId"].Value);

                typeModel = _productTypeRepository.GetType(typeModel.TypeId);
                if (typeModel != null)
                {
                    txtType.Text = typeModel.Type;
                    btnSave1.Text = "Update";
                }
            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            try
            {
                if (typeModel.TypeId != 0)
                {
                    if (UtilityUI.ShowDialogMsg("Do you want to delete ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        UtilityUI.ShowInfoMsg(_productTypeRepository.DeleteType(typeModel.TypeId));
                        reset_type();
                        UtilityUI.FillDropDownWithSelect(ddlType, ConvertionHelper.ToDataTable(_productTypeRepository.GetAllType()), "Type", "TypeId");
                    }
                }
            }
            catch (Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlType.SelectedIndex <= 0)
                {
                    UtilityUI.ShowInfoMsg("Please Select Product Type");
                    ddlType.Focus();
                    return;
                }
                if (txtCode.Text == "")
                {
                    UtilityUI.ShowInfoMsg("Please Enter Product Code");
                    txtCode.Focus();
                    return;
                }
                if (txtFolder.Text == "")
                {
                    UtilityUI.ShowInfoMsg("Please Enter Folder Location");
                    txtFolder.Focus();
                    return;
                }

                ProductTypeModel.Id = Convert.ToInt16(ddlType.SelectedValue);
                ProductTypeModel.TypeName = ddlType.Text;
                ProductTypeModel.Code = txtCode.Text;
                ProductTypeModel.IsDefault = chkDefault.Checked;
                ProductTypeModel.FolderLocation = txtFolder.Text;

                if (ProductTypeModel.TypeId == 0)
                    UtilityUI.ShowInfoMsg(_productTypeRepository.AddProductType(ProductTypeModel));
                else
                    UtilityUI.ShowInfoMsg(_productTypeRepository.UpdateProductType(ProductTypeModel));
                reset_producttype();
            }
            catch (Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
            }
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            reset_producttype();
        }

        private void btnlocation_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ProductTypeModel.TypeId = Convert.ToInt16(dataGridView2.Rows[e.RowIndex].Cells["TypeId"].Value);

                ProductTypeModel = _productTypeRepository.GetProductType(ProductTypeModel.TypeId);
                if (ProductTypeModel != null)
                {
                    txtCode.Text = ProductTypeModel.Code;
                    txtFolder.Text = ProductTypeModel.FolderLocation;
                    ddlType.SelectedValue = ProductTypeModel.Id;
                    chkDefault.Checked = ProductTypeModel.IsDefault;
                    btnSave2.Text = "Update";
                }
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductTypeModel.TypeId != 0)
                {
                    if (UtilityUI.ShowDialogMsg("Do you want to delete ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        UtilityUI.ShowInfoMsg(_productTypeRepository.DeleteProductType(ProductTypeModel.TypeId));
                        reset_producttype();
                    }
                }
            }
            catch (Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
            }
        }
    }
}
