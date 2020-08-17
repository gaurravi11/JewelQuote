using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JewelQuote_ver2.Helper
{
    public class UtilityUI
    {
        static string SoftwareName = "Jewel Quote";
        public static void ShowInfoMsg(string msg)
        {
            MessageBox.Show(msg, SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static void ShowErrorMsg(string msg)
        {
            MessageBox.Show(msg, SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowExceptionMsg(Exception ex)
        {
            MessageBox.Show(ex.ToString(), SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowDialogMsg(string msg, MessageBoxButtons messageBoxButtons)
        {
            return MessageBox.Show(msg, SoftwareName, messageBoxButtons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static void datagridviewstyle(DataGridView dataGridView1)
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        public static void DropDownLoading(ComboBox ddl)
        {
            try
            {
                ddl.DataSource = null;
                ddl.Items.Add("Loading.........");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            finally
            {
            }

        }

        public static void FillDropDown(ComboBox ddl, DataTable dt, string textField, string valueField)
        {
            try
            {
                ddl.DataSource = dt;
                ddl.ValueMember = valueField;
                ddl.DisplayMember = textField;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            finally
            {
            }

        }

        public static void FillDropDownWithSelect(ComboBox ddl, DataTable dt, string textField, string valueField)
        {
            try
            {
                DataTable dt_new = dt.Copy();
                DataRow dr = dt_new.NewRow();
                dr[textField] = "Select"; //SomeName
                dr[valueField] = 0;
                dt_new.Rows.InsertAt(dr, 0);
                dt_new.AcceptChanges();
                ddl.DataSource = dt_new;
                ddl.ValueMember = valueField;
                ddl.DisplayMember = textField;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            finally
            {
            }

        }

        public static void FillDropDownWithAll(ComboBox ddl, DataTable dt, string textField, string valueField)
        {
            try
            {
                DataTable dt_new = dt.Copy();
                DataRow dr = dt_new.NewRow();
                dr[textField] = "All"; //SomeName
                dr[valueField] = 0;
                dt_new.Rows.InsertAt(dr, 0);
                dt_new.AcceptChanges();
                ddl.DataSource = dt_new;
                ddl.ValueMember = valueField;
                ddl.DisplayMember = textField;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            finally
            {
            }

        }

        public static bool IsValidInt(string str)
        {
            try
            {
                Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidDouble(string str)
        {
            try
            {
                Convert.ToDouble(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void FillDataGridView(DataGridView dgr, DataTable dt_data, string[] strVisible)
        {
            try
            {
                DataTable dt = dt_data.Copy();
                if (dt.Rows.Count > 0)
                {
                    foreach (System.Data.DataColumn col in dt.Columns) col.AllowDBNull = true;
                    dgr.DataSource = dt;
                    if (strVisible != null)
                    {
                        foreach (string str in strVisible)
                        {
                            dgr.Columns[str].Visible = false;
                        }
                    }
                    foreach (DataGridViewColumn column in dgr.Columns)
                    {
                        if (column.Name.ToLower() != "sno")
                        {
                            if (column.ValueType == typeof(decimal) || column.ValueType == typeof(int) || column.ValueType == typeof(double) || column.ValueType == typeof(Int64) || column.ValueType == typeof(Int32))
                                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else
                        {
                            column.Width = 50;
                        }
                        if (column.ValueType == typeof(DateTime))
                            column.DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
                else
                {
                    dgr.DataSource = null;
                }
            }
            catch (Exception ex) { UtilityUI.ShowExceptionMsg(ex); }
        }

        public static void FillDataGridView<T>(DataGridView dgr, IEnumerable<T> items, string[] strVisible) where T : class, new()
        {
            try
            {
                if (items.Count() > 0)
                {
                    dgr.DataSource = items;
                    if (strVisible != null)
                    {
                        foreach (string str in strVisible)
                        {
                            dgr.Columns[str].Visible = false;
                        }
                    }
                    foreach (DataGridViewColumn column in dgr.Columns)
                    {
                        if (column.Name.ToLower() != "sno")
                        {
                            if (column.ValueType == typeof(decimal) || column.ValueType == typeof(int) || column.ValueType == typeof(double) || column.ValueType == typeof(Int64) || column.ValueType == typeof(Int32))
                                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else
                        {
                            column.Width = 50;
                        }
                        if (column.ValueType == typeof(DateTime))
                            column.DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
                else
                {
                    dgr.DataSource = null;
                }
            }
            catch (Exception ex) { UtilityUI.ShowExceptionMsg(ex); }
        }
        public static void FillDataGridView(DataGridView dgr, DataTable dt_data, string[] strVisible, string totalcolumn, string[] strTotal)
        {
            try
            {
                DataTable dt = dt_data.Copy();
                if (dt.Rows.Count > 0)
                {
                    foreach (System.Data.DataColumn col in dt.Columns) col.AllowDBNull = true;
                    if (strTotal.Length > 0 && dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.NewRow();
                        if (totalcolumn != null && totalcolumn != "")
                        {
                            if (dr.Table.Columns[totalcolumn] != null)
                            {
                                dr[totalcolumn] = "TOTAL";
                            }
                        }
                        foreach (string str in strTotal)
                        {
                            if (dr.Table.Columns[str] != null)
                            {
                                dr[str] = Roundwith2(Convert.ToDouble(dt.Compute("sum(" + str + ")", ""))).ToString("0.00");
                            }
                        }
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                    dgr.DataSource = dt;
                    if (totalcolumn != null && totalcolumn != "" && strTotal.Length > 0 && dgr.Rows.Count > 0)
                    {
                        //dgr.Rows[dgr.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Wheat;
                        dgr.Rows[dgr.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                        dgr.Rows[dgr.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.White;
                    }
                    if (strVisible != null)
                    {
                        foreach (string str in strVisible)
                        {
                            dgr.Columns[str].Visible = false;
                        }
                    }
                    foreach (DataGridViewColumn column in dgr.Columns)
                    {
                        if (column.Name.ToLower() != "sno")
                        {
                            if (column.ValueType == typeof(decimal) || column.ValueType == typeof(int) || column.ValueType == typeof(double) || column.ValueType == typeof(Int64) || column.ValueType == typeof(Int32))
                                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else
                        {
                            column.Width = 50;
                        }
                        if (column.ValueType == typeof(DateTime))
                            column.DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
                else
                {
                    dgr.DataSource = null;
                }
            }
            catch (Exception ex) { UtilityUI.ShowExceptionMsg(ex); }
        }

        public static void FillDataGridView_fill(DataGridView dgr, DataTable dt_data, string[] strVisible, string FillColumnName)
        {
            try
            {
                DataTable dt = dt_data.Copy();
                if (dt.Rows.Count > 0)
                {
                    foreach (System.Data.DataColumn col in dt.Columns) col.AllowDBNull = true;
                    dgr.DataSource = dt;

                    if (strVisible != null)
                    {
                        foreach (string str in strVisible)
                        {
                            dgr.Columns[str].Visible = false;
                        }
                    }
                    foreach (DataGridViewColumn column in dgr.Columns)
                    {
                        if (column.Name.ToLower() == "opening" || column.Name.ToLower() == "closing")
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        else if (column.Name.ToLower() != "sno")
                        {
                            if (column.ValueType == typeof(decimal) || column.ValueType == typeof(int) || column.ValueType == typeof(double) || column.ValueType == typeof(Int64) || column.ValueType == typeof(Int32))
                                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else
                            column.Width = 50;

                        if (column.ValueType == typeof(DateTime))
                            column.DefaultCellStyle.Format = "dd/MM/yyyy";

                        if (FillColumnName != "")
                        {
                            if (column.Name.ToLower() == FillColumnName.ToLower())
                            {
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            }
                            else
                            {
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            }
                        }
                    }
                }
                else
                {
                    dgr.DataSource = null;
                }
            }
            catch (Exception ex) { }
        }

        public static void FillDataGridView_fill<T>(DataGridView dgr, IEnumerable<T> items, string[] strVisible, string FillColumnName)
        {
            try
            {
                if (items.Count() > 0)
                { 
                    dgr.DataSource = items;

                    if (strVisible != null)
                    {
                        foreach (string str in strVisible)
                        {
                            dgr.Columns[str].Visible = false;
                        }
                    }
                    foreach (DataGridViewColumn column in dgr.Columns)
                    {
                        if (column.Name.ToLower() == "opening" || column.Name.ToLower() == "closing")
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        else if (column.Name.ToLower() != "sno")
                        {
                            if (column.ValueType == typeof(decimal) || column.ValueType == typeof(int) || column.ValueType == typeof(double) || column.ValueType == typeof(Int64) || column.ValueType == typeof(Int32))
                                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else
                            column.Width = 50;

                        if (column.ValueType == typeof(DateTime))
                            column.DefaultCellStyle.Format = "dd/MM/yyyy";

                        if (FillColumnName != "")
                        {
                            if (column.Name.ToLower() == FillColumnName.ToLower())
                            {
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            }
                            else
                            {
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            }
                        }
                    }
                }
                else
                {
                    dgr.DataSource = null;
                }
            }
            catch (Exception ex) { UtilityUI.ShowExceptionMsg(ex); }
        }

        public static void FillDataGridView_fill(DataGridView dgr, DataTable dt_data, string[] strVisible, string totalcolumn, string[] strTotal, string FillColumnName)
        {
            try
            {
                DataTable dt = dt_data.Copy();
                if (dt.Rows.Count > 0)
                {
                    foreach (System.Data.DataColumn col in dt.Columns) col.AllowDBNull = true;
                    if (strTotal.Length > 0 && dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.NewRow();
                        if (totalcolumn != null && totalcolumn != "")
                        {
                            if (dr.Table.Columns[totalcolumn] != null)
                            {
                                dr[totalcolumn] = "TOTAL";
                            }
                        }
                        foreach (string str in strTotal)
                        {
                            if (dr.Table.Columns[str] != null)
                            {
                                dr[str] = Roundwith2(Convert.ToDouble(dt.Compute("sum(" + str + ")", ""))).ToString("0.00");
                            }
                        }
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                    dgr.DataSource = dt;
                    if (totalcolumn != null && totalcolumn != "" && strTotal.Length > 0 && dgr.Rows.Count > 0)
                    {
                        dgr.Rows[dgr.Rows.Count - 1].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                    }
                    if (strVisible != null)
                    {
                        foreach (string str in strVisible)
                        {
                            dgr.Columns[str].Visible = false;
                        }
                    }
                    foreach (DataGridViewColumn column in dgr.Columns)
                    {
                        if (column.Name.ToLower() == "opening" || column.Name.ToLower() == "closing")
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        else if (column.Name.ToLower() != "sno")
                        {
                            if (column.ValueType == typeof(decimal) || column.ValueType == typeof(int) || column.ValueType == typeof(double) || column.ValueType == typeof(Int64) || column.ValueType == typeof(Int32))
                                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else
                            column.Width = 50;

                        if (column.ValueType == typeof(DateTime))
                            column.DefaultCellStyle.Format = "dd/MM/yyyy";

                        if (FillColumnName != "")
                        {
                            if (column.Name.ToLower() == FillColumnName.ToLower())
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            else
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                    }
                }
                else
                {
                    dgr.DataSource = null;
                }
            }
            catch (Exception ex) { UtilityUI.ShowExceptionMsg(ex); }
        }

        public static double Round(object str)
        {
            return Math.Round(Convert.ToDouble(str), 0);
        }

        public static double Roundwith2(object str)
        {
            return Math.Round(Convert.ToDouble(str), 2);
        }

        public static void LebelAtCenter(Form frm, Label lbl)
        {
            int X = frm.Width / 2 - lbl.Width / 2;
            lbl.Location = new Point(X, lbl.Location.Y);
        }


        public static string GetFormattedMaskedDatetime(string str)
        {
            try
            {
                Regex rgx = new Regex(@"(\\|-|\.)");
                string FormattedDate_Date = rgx.Replace(str, @"/");
                if (FormattedDate_Date == "  /  /")
                    return "";
                else
                    return FormattedDate_Date;

            }
            catch
            {
                return "";
            }
        }

        public static bool IsValidMaskedDateTimeText(string str)
        {
            try
            {
                Regex rgx = new Regex(@"(\\|-|\.)");
                string FormattedDate_Date = rgx.Replace(str, @"/");

                if (!string.IsNullOrEmpty(FormattedDate_Date) && FormattedDate_Date != "  /  /")
                {
                    DateTime date;
                    if (!DateTime.TryParseExact(FormattedDate_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        return false;
                    }
                }
                else if (FormattedDate_Date == "  /  /")
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidMaskedDateTimeTextOrBlank(string str)
        {
            try
            {
                Regex rgx = new Regex(@"(\\|-|\.)");
                string FormattedDate_Date = rgx.Replace(str, @"/");

                if (!string.IsNullOrEmpty(FormattedDate_Date) && FormattedDate_Date != "  /  /")
                {
                    DateTime date;
                    if (!DateTime.TryParseExact(FormattedDate_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        return false;
                    }
                }
                else if (FormattedDate_Date == "  /  /")
                {
                    return true;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Int32 getInt32(string str)
        {
            try
            {
                if (str == null || str == "")
                    return 0;

                Int32 value;
                if (Int32.TryParse(str, out value))
                    return value;
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }

        public static double getDouble(string str)
        {
            try
            {
                if (str == null || str == "")
                    return 0;

                double value;
                if (double.TryParse(str, out value))
                    return value;
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }

        public static decimal getDecimal(string str)
        {
            try
            {
                if (str == null || str == "")
                    return 0;

                decimal value;
                if (decimal.TryParse(str, out value))
                    return value;
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }
        public static double Roundoff(string Amount)
        {
            if (UtilityUI.Roundwith2(getDouble(Amount) - Math.Round(getDouble(Amount))) < 0)
            {
                return (UtilityUI.Roundwith2(Math.Round(getDouble(Amount)) - getDouble(Amount)));
            }
            else if (UtilityUI.Roundwith2(getDouble(Amount) - UtilityUI.Round(getDouble(Amount))) == 0.50)
            {
                return (0.50);
            }
            else
            {
                return (0 - UtilityUI.Roundwith2(getDouble(Amount) - Math.Round(getDouble(Amount))));
            }
        }

        public static void ExportToExcel(DataGridView dgv)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel Files(*.xls;)|*.xls;";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {

                    int cols;
                    //open file
                    StreamWriter wr = new StreamWriter(saveFileDialog1.FileName.ToString());
                    //determine the number of columns and write columns to file
                    cols = dgv.Columns.Count;
                    for (int i = 0; i < cols; i++)
                    {
                        if (dgv.Columns[i].Visible == true)
                        {
                            wr.Write(dgv.Columns[i].HeaderText.ToString().ToUpper() + "\t");
                        }
                    }
                    wr.WriteLine();
                    //write rows to excel file
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            if (dgv.Columns[j].Visible == true)
                            {
                                if (dgv.Rows[i].Cells[j].Value != null)
                                    wr.Write(dgv.Rows[i].Cells[j].Value + "\t");
                                else
                                {
                                    wr.Write("\t");
                                }
                            }
                        }
                        wr.WriteLine();
                    }
                    //close file
                    wr.Close();
                    MessageBox.Show("Excel file created , you can find the file " + saveFileDialog1.FileName.ToString() + "", "Export To Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }
    }
}
