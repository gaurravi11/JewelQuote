using AccessDBLayer.Masters;
using JewelQuote_ver2.Helper;
using ModelLayer.Masters;
using ServiceLayer.Masters;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JewelQuote.Masters
{
    public partial class FormShapeNSize : Form
    {
        IShapeRepository _shapeRepository;
        ISizeNShapeRepository _shapeNsizeRepository;

        ShpModel ShpModel;
        ShapeModel ShapeModel;

        public FormShapeNSize()
        {
            InitializeComponent();

            _shapeRepository = new LocalShapeRepository();
            _shapeNsizeRepository = new LocalShapeNsizeRepository();
        }

        private void reset_Shape()
        {
            ShpModel = new ShpModel();
            txtShape.Text = "";
            UtilityUI.FillDataGridView_fill(dataGridView1, _shapeRepository.GetAllShape(), new string[] { "ShpId" }, "ShpName");
            btnSave1.Text = "Save";
            btnDelete1.Enabled = false;
            txtShape.Focus();
        }

        private void reset_Size()
        {
            ShapeModel = new ShapeModel();
            txtSize.Text = "";
            //UtilityUI.FillDropDownWithSelect(ddlShape, ConvertionHelper.ToDataTable(_shapeRepository.GetAllShape()), "ShpName", "ShpId");
            UtilityUI.FillDataGridView_fill(dataGridView2, _shapeNsizeRepository.GetAllShapeNSize_dt(), new string[] { "ShapeId", "ShpId", "Description" }, "SizeName");
            btnSave2.Text = "Save";
            btnDelete2.Enabled = false;
            txtSize.Focus();
        }

        private void FormShapeNSize_Load(object sender, System.EventArgs e)
        {
            UtilityUI.FillDropDownWithSelect(ddlShape, ConvertionHelper.ToDataTable(_shapeRepository.GetAllShape()), "ShpName", "ShpId");
            reset_Size();
            reset_Shape();
        }

        private void btnSave1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (txtShape.Text == "")
                {
                    UtilityUI.ShowInfoMsg("Please Enter Shape Name");
                    txtShape.Focus();
                    return;
                }

                ShpModel.ShpName = txtShape.Text.ToUpper();
                string rslt = "";
                if (ShpModel.ShpId == 0)
                {
                    rslt = _shapeRepository.AddShape(ShpModel);

                    if (UtilityUI.IsValidInt(rslt))
                        UtilityUI.ShowInfoMsg("Shape Saved");
                    else
                        UtilityUI.ShowInfoMsg(rslt);
                }
                else
                {
                    rslt = _shapeRepository.UpdateShape(ShpModel);
                    UtilityUI.FillDataGridView_fill(dataGridView2, _shapeNsizeRepository.GetAllShapeNSize(), new string[] { "ShapeId", "ShpId", "Description" }, "SizeName");
                }
                reset_Shape();
                UtilityUI.FillDropDownWithSelect(ddlShape, ConvertionHelper.ToDataTable(_shapeRepository.GetAllShape()), "ShpName", "ShpId");
            }
            catch (Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
            }
        }

        private void btnReset1_Click(object sender, EventArgs e)
        {
            reset_Shape();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ShpModel.ShpId = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["ShpId"].Value);

                ShpModel = _shapeRepository.GetShape(ShpModel.ShpId);
                if (ShpModel != null)
                {
                    txtShape.Text = ShpModel.ShpName;
                    btnDelete1.Enabled = true;
                    btnSave1.Text = "Update";
                }
            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ShpModel.ShpId != 0)
                {
                    if (UtilityUI.ShowDialogMsg("Do you want to delete ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        UtilityUI.ShowInfoMsg(_shapeRepository.DeleteShape(ShpModel.ShpId));
                        reset_Shape();
                        UtilityUI.FillDropDownWithSelect(ddlShape, ConvertionHelper.ToDataTable(_shapeRepository.GetAllShape()), "ShpName", "ShpId");
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
                if (txtSize.Text == "")
                {
                    UtilityUI.ShowInfoMsg("Please Enter Stone Size");
                    txtSize.Focus();
                    return;
                }

                if (ddlShape.SelectedIndex <= 0)
                {
                    UtilityUI.ShowInfoMsg("Select Shape");
                    ddlShape.Focus();
                    return;
                }

                ShapeModel.Size = txtSize.Text.ToUpper();
                ShapeModel.ShpId = Convert.ToInt32(ddlShape.SelectedValue);
                ShapeModel.Shape = ddlShape.Text;

                if (ShapeModel.ShapeId == 0)
                    UtilityUI.ShowInfoMsg(_shapeNsizeRepository.AddShapeNSize(ShapeModel));
                else
                    UtilityUI.ShowInfoMsg(_shapeNsizeRepository.UpdateShapeNSize(ShapeModel));
                reset_Size();
            }
            catch (Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
            }
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            reset_Size();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ShapeModel.ShapeId = Convert.ToInt16(dataGridView2.Rows[e.RowIndex].Cells["ShapeId"].Value);

                ShapeModel = _shapeNsizeRepository.GetShapeNSize((short)ShapeModel.ShapeId);
                if (ShpModel != null)
                {
                    ddlShape.SelectedValue = ShapeModel.ShpId;
                    txtSize.Text = ShapeModel.Size;
                    btnDelete2.Enabled = true;
                    btnSave2.Text = "Update";
                }
            }
        }
    }
}
