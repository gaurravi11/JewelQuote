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
    public partial class FormLabourCategory : Form
    {
        ILabourRepository _labourRepository;
        LabourCategoryModel labourCategoryModel;
        public FormLabourCategory()
        {
            InitializeComponent();
            _labourRepository = new LocalLabourRepository();
        }

        private void Reset()
        {
            labourCategoryModel = new LabourCategoryModel();
            txtCategory.Text = txtRate.Text = "";
            UtilityUI.FillDataGridView_fill(dataGridView1, _labourRepository.GetAllCategory(), new string[] { "CategoryId" }, "CategoryName");
            txtCategory.Focus();
            chkDefault.Checked = false;
            btnSave.Text = "Save";
        }
        private void FormLabourCategory_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategory.Text == "")
                {
                    UtilityUI.ShowInfoMsg("Please Enter Labour Category");
                    txtCategory.Focus();
                    return;
                }
                if (txtRate.Text == "")
                {
                    UtilityUI.ShowInfoMsg("Please Enter Rate");
                    txtRate.Focus();
                    return;
                }
                string result = "";

                labourCategoryModel.CategoryName = txtCategory.Text;
                labourCategoryModel.Rate = UtilityUI.getDecimal(txtRate.Text);
                labourCategoryModel.IsDefault = chkDefault.Checked;

                if (labourCategoryModel.CategoryId == 0)
                    result = _labourRepository.AddCategory(labourCategoryModel);
                else
                    result = _labourRepository.UpdateCategory(labourCategoryModel);

                UtilityUI.ShowInfoMsg(result);
                Reset();
            }
            catch (Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                
                labourCategoryModel.CategoryId = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["CategoryId"].Value);

                labourCategoryModel = _labourRepository.GetCategory(labourCategoryModel.CategoryId);
                if (labourCategoryModel != null)
                {
                    txtCategory.Text = labourCategoryModel.CategoryName;
                    txtRate.Text = labourCategoryModel.Rate.ToString();
                    chkDefault.Checked = labourCategoryModel.IsDefault;
                    btnSave.Text = "Update";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (labourCategoryModel.CategoryId != 0)
                {
                    if (UtilityUI.ShowDialogMsg("Do you want to delete ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        UtilityUI.ShowInfoMsg(_labourRepository.DeleteCategory(labourCategoryModel.CategoryId));
                        Reset();
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
