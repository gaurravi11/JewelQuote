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
    public partial class FormSettingCategory : Form
    {
        ISettingRepository _SettingRepository;
        SettingCategoryModel SettingCategoryModel;
        public FormSettingCategory()
        {
            InitializeComponent();
            _SettingRepository = new LocalSettingRepository();
        }

        private void Reset()
        {
            SettingCategoryModel = new SettingCategoryModel();
            txtCategory.Text = txtRate.Text = "";
            UtilityUI.FillDataGridView_fill(dataGridView1, _SettingRepository.GetAllSetting(), new string[] { "SettingId" }, "SettingName");
            txtCategory.Focus();
            chkDefault.Checked = false;
            btnSave.Text = "Save";
        }
        private void FormSettingCategory_Load(object sender, EventArgs e)
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
                    UtilityUI.ShowInfoMsg("Please Enter Setting Category");
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

                SettingCategoryModel.SettingName = txtCategory.Text;
                SettingCategoryModel.Rate = UtilityUI.getDecimal(txtRate.Text);
                SettingCategoryModel.IsDefault = chkDefault.Checked;

                if (SettingCategoryModel.SettingId == 0)
                    result = _SettingRepository.AddSetting(SettingCategoryModel);
                else
                    result = _SettingRepository.UpdateSetting(SettingCategoryModel);

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
                
                SettingCategoryModel.SettingId = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["SettingId"].Value);

                SettingCategoryModel = _SettingRepository.GetSetting(SettingCategoryModel.SettingId);
                if (SettingCategoryModel != null)
                {
                    txtCategory.Text = SettingCategoryModel.SettingName;
                    txtRate.Text = SettingCategoryModel.Rate.ToString();
                    chkDefault.Checked = SettingCategoryModel.IsDefault;
                    btnSave.Text = "Update";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (SettingCategoryModel.SettingId != 0)
                {
                    if (UtilityUI.ShowDialogMsg("Do you want to delete ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        UtilityUI.ShowInfoMsg(_SettingRepository.DeleteSetting(SettingCategoryModel.SettingId));
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
