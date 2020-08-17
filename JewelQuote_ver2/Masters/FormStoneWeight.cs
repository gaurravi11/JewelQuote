using System;
using AccessDBLayer.Masters;
using JewelQuote_ver2.Helper;
using ModelLayer.Masters;
using ServiceLayer.Masters;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace JewelQuote.Masters
{
    public partial class FormStoneWeight : Form
    {
        IStoneRateRepository _stoneRateRepository;
        IStoneRepository _stoneRepository;
        ISizeNShapeRepository _shapeRepository;

        DataTable dt_Updated = null;
        private void CreateUpdatetable()
        {
            dt_Updated = new DataTable();
            dt_Updated.Columns.Add("Row", typeof(int));
            dt_Updated.Columns.Add("Cell", typeof(int));
        }

        public FormStoneWeight()
        {
            InitializeComponent();

            _shapeRepository = new LocalShapeNsizeRepository();
            _stoneRepository = new LocalStoneRepository();
            _stoneRateRepository = new LocalStoneRateRepository();
        }

        private void GetStoneRate()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Shape", typeof(string));
            dt.Columns.Add("ShapeId", typeof(Int32));
            dt.Rows.Add("StoneId", 0);

            IEnumerable<StoneModel> stoneModels = _stoneRepository.GetAllStone();
            IEnumerable<ShapeModel> shapeModels = _shapeRepository.GetAllShapeNSize();
            IEnumerable<StoneRateModel> stoneRateModels = _stoneRateRepository.GetStoneRate(Convert.ToInt16(ddlType.SelectedValue));

            foreach (var shape in shapeModels)
            {
                DataRow dr1 = dt.NewRow();
                dr1["Shape"] = shape.SizeName;
                dr1["ShapeId"] = shape.ShapeId;
                dt.AcceptChanges();
                dt.Rows.Add(dr1);
            }
            foreach (var stone in stoneModels)
            {
                dt.Columns.Add(stone.StoneName, typeof(string));
                foreach (DataRow dr3 in dt.Rows)
                {
                    if (Convert.ToInt32(dr3["Shapeid"]) == 0)
                    {
                        dr3[stone.StoneName] = stone.StoneId;
                        break;
                    }
                }

                foreach (var stoneRate in stoneRateModels)
                {
                    if (Convert.ToInt32(stone.StoneId) == Convert.ToInt32(stoneRate.StoneId))
                    {
                        foreach (DataRow dr2 in dt.Rows)
                        {
                            if (Convert.ToInt32(stoneRate.ShapeId) == Convert.ToInt32(dr2["Shapeid"]))
                            {
                                dr2[stone.StoneName] = stoneRate.Weight;
                            }
                        }
                    }
                }
            }
            UtilityUI.FillDataGridView(dataGridView3, dt, new string[] { "ShapeId" }, "", new string[] { });
        }

        private void FormStoneRate_Load(object sender, EventArgs e)
        {
            ddlType.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetStoneRate();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            UtilityUI.ExportToExcel(dataGridView3);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int count = dataGridView3.Rows.Count;

                int Cellcount = dataGridView3.Columns.Count;

                if (dt_Updated != null)
                {
                    foreach (DataRow dr in dt_Updated.Rows)
                    {
                        if (UtilityUI.IsValidDouble(dataGridView3.Rows[Convert.ToInt32(dr["Row"])].Cells[Convert.ToInt32(dr["Cell"])].Value.ToString()))
                        {
                            StoneRateModel stoneRateModel = new StoneRateModel()
                            {
                                StoneId = Convert.ToInt32(dataGridView3.Rows[0].Cells[Convert.ToInt32(dr["Cell"])].FormattedValue),
                                ShapeId = Convert.ToInt32(dataGridView3.Rows[Convert.ToInt32(dr["Row"])].Cells[1].FormattedValue),
                                Weight = Convert.ToDecimal(dataGridView3.Rows[Convert.ToInt32(dr["Row"])].Cells[Convert.ToInt32(dr["Cell"])].FormattedValue),
                                StoneType = Convert.ToInt16(ddlType.SelectedIndex)
                            };
                            _stoneRateRepository.UpdateStoneWeight(stoneRateModel);
                        }
                    }
                }

                UtilityUI.ShowInfoMsg("Rate Updated");
            }
            catch(Exception ex)
            {
                UtilityUI.ShowExceptionMsg(ex);
            }
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dt_Updated == null)
                {
                    CreateUpdatetable();
                }

                dt_Updated.Rows.Add(e.RowIndex, e.ColumnIndex);
            }
            catch
            {
            }
        }
    }
}
