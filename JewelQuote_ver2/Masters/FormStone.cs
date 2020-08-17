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
    public partial class FormStone : Form
    {
        IStoneRepository _stoneRepository;
        StoneModel stoneModel;
        public FormStone()
        {
            InitializeComponent();
            _stoneRepository = new LocalStoneRepository();
        }
        private void reset()
        {
            stoneModel = new StoneModel();
            txtStone.Text = txtSort.Text = "";
            chkDefault.Checked = false;
            UtilityUI.FillDataGridView_fill(dataGridView1, _stoneRepository.GetAllStone(), new string[] { "StoneId", "Colour", "Description" }, "StoneName");
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            txtStone.Focus();
        }
        private void FormStone_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStone.Text == "")
                {
                    UtilityUI.ShowInfoMsg("Please Enter Stone Name");
                    txtStone.Focus();
                    return;
                }
                if (txtSort.Text == "")
                {
                    txtSort.Text = _stoneRepository.getNextSortOrder().ToString();
                }
                else if (stoneModel.StoneId == 0 && _stoneRepository.SortOrderExists(Convert.ToInt16(txtSort.Text)))
                {
                    UtilityUI.ShowInfoMsg("Sort Order exists");
                    txtSort.Focus();
                    return;
                }

                stoneModel.StoneName = txtStone.Text.ToUpper();
                stoneModel.SortOrder = UtilityUI.getInt32(txtSort.Text);
                stoneModel.IsDefault = chkDefault.Checked;

                if (stoneModel.StoneId == 0)
                    UtilityUI.ShowInfoMsg(_stoneRepository.AddStone(stoneModel));
                else
                    UtilityUI.ShowInfoMsg(_stoneRepository.UpdateStone(stoneModel));
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                stoneModel.StoneId = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["StoneId"].Value);

                stoneModel = _stoneRepository.GetStone(stoneModel.StoneId);
                if (stoneModel != null)
                {
                    txtStone.Text = stoneModel.StoneName;
                    txtSort.Text = stoneModel.SortOrder.ToString();
                    chkDefault.Checked = stoneModel.IsDefault;
                    btnDelete.Enabled = true;
                    btnSave.Text = "Update";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (stoneModel.StoneId != 0)
                {
                    if (UtilityUI.ShowDialogMsg("Do you want to delete ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        UtilityUI.ShowInfoMsg(_stoneRepository.DeleteStone(stoneModel.StoneId));
                        reset();
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
