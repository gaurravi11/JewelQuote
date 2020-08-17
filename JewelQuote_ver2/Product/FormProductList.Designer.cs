namespace JewelQuote.Product
{
    partial class FormProductList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtNos = new MyControl.Controls.MyTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTo = new MyControl.Controls.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFrom = new MyControl.Controls.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlType = new System.Windows.Forms.ComboBox();
            this.chkWithoutStone = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new FontAwesome.Sharp.IconButton();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(8, 76);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(732, 473);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // txtNos
            // 
            this.txtNos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNos.BorderColor = System.Drawing.Color.Transparent;
            this.txtNos.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNos.Location = new System.Drawing.Point(99, 45);
            this.txtNos.Name = "txtNos";
            this.txtNos.Size = new System.Drawing.Size(446, 22);
            this.txtNos.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 67;
            this.label5.Text = "ProductNos";
            // 
            // txtTo
            // 
            this.txtTo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTo.BorderColor = System.Drawing.Color.Transparent;
            this.txtTo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTo.Location = new System.Drawing.Point(534, 15);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(78, 22);
            this.txtTo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(487, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 65;
            this.label4.Text = "To No";
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFrom.BorderColor = System.Drawing.Color.Transparent;
            this.txtFrom.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFrom.Location = new System.Drawing.Point(403, 15);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(78, 22);
            this.txtFrom.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(340, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 63;
            this.label3.Text = "From No";
            // 
            // ddlCode
            // 
            this.ddlCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ddlCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlCode.BackColor = System.Drawing.SystemColors.Window;
            this.ddlCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCode.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCode.FormattingEnabled = true;
            this.ddlCode.Location = new System.Drawing.Point(271, 15);
            this.ddlCode.Name = "ddlCode";
            this.ddlCode.Size = new System.Drawing.Size(63, 24);
            this.ddlCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 61;
            this.label2.Text = "Code";
            // 
            // ddlType
            // 
            this.ddlType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ddlType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlType.BackColor = System.Drawing.SystemColors.Window;
            this.ddlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlType.FormattingEnabled = true;
            this.ddlType.Location = new System.Drawing.Point(99, 15);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(121, 24);
            this.ddlType.TabIndex = 0;
            this.ddlType.SelectedIndexChanged += new System.EventHandler(this.ddlType_SelectedIndexChanged);
            // 
            // chkWithoutStone
            // 
            this.chkWithoutStone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkWithoutStone.AutoSize = true;
            this.chkWithoutStone.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkWithoutStone.Location = new System.Drawing.Point(618, 16);
            this.chkWithoutStone.Name = "chkWithoutStone";
            this.chkWithoutStone.Size = new System.Drawing.Size(113, 21);
            this.chkWithoutStone.TabIndex = 4;
            this.chkWithoutStone.Text = "Without Stone";
            this.chkWithoutStone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkWithoutStone.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 58;
            this.label1.Text = "Product Type";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnExport.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExport.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btnExport.IconColor = System.Drawing.Color.Gainsboro;
            this.btnExport.IconSize = 20;
            this.btnExport.Location = new System.Drawing.Point(645, 41);
            this.btnExport.Name = "btnExport";
            this.btnExport.Rotation = 0D;
            this.btnExport.Size = new System.Drawing.Size(91, 27);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSearch.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnSearch.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSearch.IconSize = 20;
            this.btnSearch.Location = new System.Drawing.Point(551, 41);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Rotation = 0D;
            this.btnSearch.Size = new System.Drawing.Size(91, 27);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FormProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(748, 556);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtNos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddlCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlType);
            this.Controls.Add(this.chkWithoutStone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormProductList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Product List";
            this.Load += new System.EventHandler(this.FormProductList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private MyControl.Controls.MyTextBox txtNos;
        private System.Windows.Forms.Label label5;
        private MyControl.Controls.MyTextBox txtTo;
        private System.Windows.Forms.Label label4;
        private MyControl.Controls.MyTextBox txtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlType;
        private System.Windows.Forms.CheckBox chkWithoutStone;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnExport;
        private FontAwesome.Sharp.IconButton btnSearch;
    }
}