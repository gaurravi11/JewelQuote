using AccessDBLayer.Masters;
using JewelQuote_ver2.Helper;
using ModelLayer.Masters;
using ServiceLayer.Masters;
using System;
using System.Windows.Forms;

namespace JewelQuote_ver2.Masters
{
    public partial class FormMetal : Form
    {
        private IMetalRepository _metalRepository;
        MetalModel metal;
        public FormMetal()
        {
            InitializeComponent();
            _metalRepository = new LocalMetalRepository();
        }

        private void reset()
        {
            metal = new MetalModel();
            txtMetal.Text = txtRate.Text = "";
            UtilityUI.FillDataGridView_fill(dataGridView1, _metalRepository.GetAllMetal(), new string[] { "MetalId", "description" }, "MetalName");
            txtMetal.Focus();
            chkDefault.Checked = false;
            btnSave.Text = "Save";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMetal.Text == "")
                {
                    UtilityUI.ShowInfoMsg("Please Enter Metal Name");
                    txtMetal.Focus();
                    return;
                }
                if (txtRate.Text == "")
                {
                    UtilityUI.ShowInfoMsg("Please Enter Metal Rate");
                    txtRate.Focus();
                    return;
                }
                string result = "";

                metal.MetalName = txtMetal.Text;
                metal.Rate = UtilityUI.getDecimal(txtRate.Text);
                metal.IsDefault = chkDefault.Checked;

                if (metal.MetalId == 0)
                    result = _metalRepository.AddMetal(metal);
                else
                    result = _metalRepository.UpdateMetal(metal);

                UtilityUI.ShowInfoMsg(result);
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

        private void FormMetal_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                reset();
                metal.MetalId = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["Metalid"].Value);

                metal = _metalRepository.GetMetal(metal.MetalId);
                if (metal != null)
                {
                    txtMetal.Text = metal.MetalName;
                    txtRate.Text = metal.Rate.ToString();
                    chkDefault.Checked = metal.IsDefault;
                    btnSave.Text = "Update";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (metal.MetalId != 0)
                {
                    if (UtilityUI.ShowDialogMsg("Do you want to delete ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        UtilityUI.ShowInfoMsg(_metalRepository.DeleteMetal(metal.MetalId));
                        reset();
                    }
                }
            }
            catch (Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
