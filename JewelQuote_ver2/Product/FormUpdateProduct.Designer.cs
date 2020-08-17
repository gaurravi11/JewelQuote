namespace JewelQuote.Product
{
    partial class FormUpdateProduct
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
            this.chkCustomLabour = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGhat = new MyControl.Controls.MyTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMetalCost = new MyControl.Controls.MyTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalLabour = new MyControl.Controls.MyTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSetting = new MyControl.Controls.MyTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLabour = new MyControl.Controls.MyTextBox();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStoneQty = new MyControl.Controls.MyTextBox();
            this.ddlShapeNSize = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ddlStoneType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkWithoutStone = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWeight = new MyControl.Controls.MyTextBox();
            this.ddlMetal = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlSetting = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlLabour = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnzImageRemove = new FontAwesome.Sharp.IconButton();
            this.btnImage = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkCustomLabour
            // 
            this.chkCustomLabour.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkCustomLabour.AutoSize = true;
            this.chkCustomLabour.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCustomLabour.Location = new System.Drawing.Point(13, 376);
            this.chkCustomLabour.Name = "chkCustomLabour";
            this.chkCustomLabour.Size = new System.Drawing.Size(312, 21);
            this.chkCustomLabour.TabIndex = 111;
            this.chkCustomLabour.Text = "Note : For Custom Labour Charges please Check";
            this.chkCustomLabour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCustomLabour.UseVisualStyleBackColor = true;
            this.chkCustomLabour.CheckedChanged += new System.EventHandler(this.chkCustomLabour_CheckedChanged);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(520, 481);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 17);
            this.label13.TabIndex = 132;
            this.label13.Text = "Total Ghat Cost";
            // 
            // txtGhat
            // 
            this.txtGhat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGhat.BorderColor = System.Drawing.Color.Transparent;
            this.txtGhat.Enabled = false;
            this.txtGhat.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGhat.InputType = MyControl.Controls.MyTextBox.TextType.Double;
            this.txtGhat.Location = new System.Drawing.Point(626, 479);
            this.txtGhat.Name = "txtGhat";
            this.txtGhat.Size = new System.Drawing.Size(106, 22);
            this.txtGhat.TabIndex = 131;
            this.txtGhat.Text = "0.00";
            this.txtGhat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(487, 430);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 17);
            this.label14.TabIndex = 130;
            this.label14.Text = "Total Labour Charges";
            // 
            // txtMetalCost
            // 
            this.txtMetalCost.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMetalCost.BorderColor = System.Drawing.Color.Transparent;
            this.txtMetalCost.Enabled = false;
            this.txtMetalCost.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMetalCost.InputType = MyControl.Controls.MyTextBox.TextType.Double;
            this.txtMetalCost.Location = new System.Drawing.Point(626, 453);
            this.txtMetalCost.Name = "txtMetalCost";
            this.txtMetalCost.Size = new System.Drawing.Size(106, 22);
            this.txtMetalCost.TabIndex = 129;
            this.txtMetalCost.Text = "0.00";
            this.txtMetalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMetalCost.TextChanged += new System.EventHandler(this.txtMetalCost_TextChanged);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(547, 456);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 17);
            this.label12.TabIndex = 128;
            this.label12.Text = "Metal Cost";
            // 
            // txtTotalLabour
            // 
            this.txtTotalLabour.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTotalLabour.BorderColor = System.Drawing.Color.Transparent;
            this.txtTotalLabour.Enabled = false;
            this.txtTotalLabour.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTotalLabour.InputType = MyControl.Controls.MyTextBox.TextType.Double;
            this.txtTotalLabour.Location = new System.Drawing.Point(626, 427);
            this.txtTotalLabour.Name = "txtTotalLabour";
            this.txtTotalLabour.Size = new System.Drawing.Size(106, 22);
            this.txtTotalLabour.TabIndex = 112;
            this.txtTotalLabour.Text = "0.00";
            this.txtTotalLabour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalLabour.TextChanged += new System.EventHandler(this.txtTotalLabour_TextChanged);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(517, 403);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 17);
            this.label11.TabIndex = 127;
            this.label11.Text = "Setting Charges";
            // 
            // txtSetting
            // 
            this.txtSetting.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSetting.BorderColor = System.Drawing.Color.Transparent;
            this.txtSetting.Enabled = false;
            this.txtSetting.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSetting.InputType = MyControl.Controls.MyTextBox.TextType.Double;
            this.txtSetting.Location = new System.Drawing.Point(626, 401);
            this.txtSetting.Name = "txtSetting";
            this.txtSetting.Size = new System.Drawing.Size(106, 22);
            this.txtSetting.TabIndex = 126;
            this.txtSetting.Text = "0.00";
            this.txtSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSetting.TextChanged += new System.EventHandler(this.txtSetting_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(482, 377);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 17);
            this.label10.TabIndex = 125;
            this.label10.Text = "Casting / Filing / Polish";
            // 
            // txtLabour
            // 
            this.txtLabour.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLabour.BorderColor = System.Drawing.Color.Transparent;
            this.txtLabour.Enabled = false;
            this.txtLabour.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLabour.InputType = MyControl.Controls.MyTextBox.TextType.Double;
            this.txtLabour.Location = new System.Drawing.Point(626, 375);
            this.txtLabour.Name = "txtLabour";
            this.txtLabour.Size = new System.Drawing.Size(106, 22);
            this.txtLabour.TabIndex = 124;
            this.txtLabour.Text = "0.00";
            this.txtLabour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLabour.TextChanged += new System.EventHandler(this.txtLabour_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnExit.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnExit.IconColor = System.Drawing.Color.Gainsboro;
            this.btnExit.IconSize = 20;
            this.btnExit.Location = new System.Drawing.Point(422, 515);
            this.btnExit.Name = "btnExit";
            this.btnExit.Rotation = 0D;
            this.btnExit.Size = new System.Drawing.Size(91, 27);
            this.btnExit.TabIndex = 115;
            this.btnExit.Text = "Exit (Esc)";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSave.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.SdCard;
            this.btnSave.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSave.IconSize = 20;
            this.btnSave.Location = new System.Drawing.Point(234, 515);
            this.btnSave.Name = "btnSave";
            this.btnSave.Rotation = 0D;
            this.btnSave.Size = new System.Drawing.Size(91, 27);
            this.btnSave.TabIndex = 113;
            this.btnSave.Text = "Update";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtStoneQty);
            this.groupBox1.Controls.Add(this.ddlShapeNSize);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ddlStoneType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(13, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 211);
            this.groupBox1.TabIndex = 110;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stone Size N Shape";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 53);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(697, 139);
            this.dataGridView1.TabIndex = 91;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnAdd.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAdd.IconColor = System.Drawing.Color.Gainsboro;
            this.btnAdd.IconSize = 20;
            this.btnAdd.Location = new System.Drawing.Point(624, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Rotation = 0D;
            this.btnAdd.Size = new System.Drawing.Size(65, 25);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(486, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 89;
            this.label9.Text = "Stone Qty";
            // 
            // txtStoneQty
            // 
            this.txtStoneQty.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStoneQty.BorderColor = System.Drawing.Color.Transparent;
            this.txtStoneQty.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStoneQty.InputType = MyControl.Controls.MyTextBox.TextType.Numeric;
            this.txtStoneQty.Location = new System.Drawing.Point(556, 21);
            this.txtStoneQty.Name = "txtStoneQty";
            this.txtStoneQty.Size = new System.Drawing.Size(60, 22);
            this.txtStoneQty.TabIndex = 2;
            // 
            // ddlShapeNSize
            // 
            this.ddlShapeNSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ddlShapeNSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlShapeNSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlShapeNSize.BackColor = System.Drawing.SystemColors.Window;
            this.ddlShapeNSize.Font = new System.Drawing.Font("Century Gothic", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlShapeNSize.FormattingEnabled = true;
            this.ddlShapeNSize.Location = new System.Drawing.Point(299, 21);
            this.ddlShapeNSize.Name = "ddlShapeNSize";
            this.ddlShapeNSize.Size = new System.Drawing.Size(178, 23);
            this.ddlShapeNSize.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(210, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 87;
            this.label8.Text = "Size N\' Shape";
            // 
            // ddlStoneType
            // 
            this.ddlStoneType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ddlStoneType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlStoneType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlStoneType.BackColor = System.Drawing.SystemColors.Window;
            this.ddlStoneType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStoneType.Font = new System.Drawing.Font("Century Gothic", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlStoneType.FormattingEnabled = true;
            this.ddlStoneType.Items.AddRange(new object[] {
            "CUT",
            "CAB"});
            this.ddlStoneType.Location = new System.Drawing.Point(107, 21);
            this.ddlStoneType.Name = "ddlStoneType";
            this.ddlStoneType.Size = new System.Drawing.Size(91, 23);
            this.ddlStoneType.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 78;
            this.label7.Text = "Stone Type";
            // 
            // chkWithoutStone
            // 
            this.chkWithoutStone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkWithoutStone.AutoSize = true;
            this.chkWithoutStone.Location = new System.Drawing.Point(98, 120);
            this.chkWithoutStone.Name = "chkWithoutStone";
            this.chkWithoutStone.Size = new System.Drawing.Size(124, 21);
            this.chkWithoutStone.TabIndex = 109;
            this.chkWithoutStone.Text = "Is Without Stone";
            this.chkWithoutStone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkWithoutStone.UseVisualStyleBackColor = true;
            this.chkWithoutStone.CheckedChanged += new System.EventHandler(this.chkWithoutStone_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 123;
            this.label6.Text = "Metal Weight";
            // 
            // txtWeight
            // 
            this.txtWeight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtWeight.BorderColor = System.Drawing.Color.Transparent;
            this.txtWeight.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWeight.InputType = MyControl.Controls.MyTextBox.TextType.Double;
            this.txtWeight.Location = new System.Drawing.Point(381, 91);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(121, 22);
            this.txtWeight.TabIndex = 108;
            this.txtWeight.TextChanged += new System.EventHandler(this.txtWeight_TextChanged);
            // 
            // ddlMetal
            // 
            this.ddlMetal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ddlMetal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlMetal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlMetal.BackColor = System.Drawing.SystemColors.Window;
            this.ddlMetal.Font = new System.Drawing.Font("Century Gothic", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlMetal.FormattingEnabled = true;
            this.ddlMetal.Location = new System.Drawing.Point(115, 91);
            this.ddlMetal.Name = "ddlMetal";
            this.ddlMetal.Size = new System.Drawing.Size(121, 23);
            this.ddlMetal.TabIndex = 107;
            this.ddlMetal.SelectedIndexChanged += new System.EventHandler(this.ddlMetal_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 122;
            this.label5.Text = "Metal";
            // 
            // ddlSetting
            // 
            this.ddlSetting.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ddlSetting.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlSetting.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlSetting.BackColor = System.Drawing.SystemColors.Window;
            this.ddlSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSetting.Font = new System.Drawing.Font("Century Gothic", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSetting.FormattingEnabled = true;
            this.ddlSetting.Location = new System.Drawing.Point(381, 66);
            this.ddlSetting.Name = "ddlSetting";
            this.ddlSetting.Size = new System.Drawing.Size(121, 23);
            this.ddlSetting.TabIndex = 106;
            this.ddlSetting.SelectedIndexChanged += new System.EventHandler(this.ddlSetting_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 121;
            this.label4.Text = "Setting Category";
            // 
            // ddlLabour
            // 
            this.ddlLabour.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ddlLabour.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlLabour.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlLabour.BackColor = System.Drawing.SystemColors.Window;
            this.ddlLabour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLabour.Font = new System.Drawing.Font("Century Gothic", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlLabour.FormattingEnabled = true;
            this.ddlLabour.Location = new System.Drawing.Point(115, 66);
            this.ddlLabour.Name = "ddlLabour";
            this.ddlLabour.Size = new System.Drawing.Size(121, 23);
            this.ddlLabour.TabIndex = 105;
            this.ddlLabour.SelectedIndexChanged += new System.EventHandler(this.ddlLabour_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 120;
            this.label3.Text = "Category";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 119;
            this.label2.Text = "Product Code";
            // 
            // btnzImageRemove
            // 
            this.btnzImageRemove.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnzImageRemove.BackColor = System.Drawing.Color.White;
            this.btnzImageRemove.FlatAppearance.BorderSize = 0;
            this.btnzImageRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnzImageRemove.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnzImageRemove.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnzImageRemove.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnzImageRemove.IconColor = System.Drawing.Color.Red;
            this.btnzImageRemove.IconSize = 24;
            this.btnzImageRemove.Location = new System.Drawing.Point(710, 9);
            this.btnzImageRemove.Name = "btnzImageRemove";
            this.btnzImageRemove.Rotation = 0D;
            this.btnzImageRemove.Size = new System.Drawing.Size(23, 25);
            this.btnzImageRemove.TabIndex = 118;
            this.btnzImageRemove.UseVisualStyleBackColor = false;
            this.btnzImageRemove.Click += new System.EventHandler(this.btnzImageRemove_Click);
            // 
            // btnImage
            // 
            this.btnImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnImage.BackColor = System.Drawing.Color.White;
            this.btnImage.FlatAppearance.BorderSize = 0;
            this.btnImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImage.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnImage.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnImage.IconChar = FontAwesome.Sharp.IconChar.Image;
            this.btnImage.IconColor = System.Drawing.Color.Black;
            this.btnImage.IconSize = 24;
            this.btnImage.Location = new System.Drawing.Point(683, 9);
            this.btnImage.Name = "btnImage";
            this.btnImage.Rotation = 0D;
            this.btnImage.Size = new System.Drawing.Size(27, 25);
            this.btnImage.TabIndex = 117;
            this.btnImage.UseVisualStyleBackColor = false;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(575, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 116;
            this.pictureBox1.TabStop = false;
            // 
            // lblProductCode
            // 
            this.lblProductCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblProductCode.Location = new System.Drawing.Point(112, 17);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(12, 17);
            this.lblProductCode.TabIndex = 133;
            this.lblProductCode.Text = ".";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDelete.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnDelete.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.IconSize = 20;
            this.btnDelete.Location = new System.Drawing.Point(328, 515);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Rotation = 0D;
            this.btnDelete.Size = new System.Drawing.Size(91, 27);
            this.btnDelete.TabIndex = 134;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FormUpdateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(748, 556);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.chkCustomLabour);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtGhat);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtMetalCost);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTotalLabour);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSetting);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtLabour);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkWithoutStone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.ddlMetal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ddlSetting);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ddlLabour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnzImageRemove);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUpdateProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product View";
            this.Load += new System.EventHandler(this.FormUpdateProduct_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCustomLabour;
        private System.Windows.Forms.Label label13;
        private MyControl.Controls.MyTextBox txtGhat;
        private System.Windows.Forms.Label label14;
        private MyControl.Controls.MyTextBox txtMetalCost;
        private System.Windows.Forms.Label label12;
        private MyControl.Controls.MyTextBox txtTotalLabour;
        private System.Windows.Forms.Label label11;
        private MyControl.Controls.MyTextBox txtSetting;
        private System.Windows.Forms.Label label10;
        private MyControl.Controls.MyTextBox txtLabour;
        private FontAwesome.Sharp.IconButton btnExit;
        private FontAwesome.Sharp.IconButton btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FontAwesome.Sharp.IconButton btnAdd;
        private System.Windows.Forms.Label label9;
        private MyControl.Controls.MyTextBox txtStoneQty;
        private System.Windows.Forms.ComboBox ddlShapeNSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ddlStoneType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkWithoutStone;
        private System.Windows.Forms.Label label6;
        private MyControl.Controls.MyTextBox txtWeight;
        private System.Windows.Forms.ComboBox ddlMetal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlSetting;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlLabour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnzImageRemove;
        private FontAwesome.Sharp.IconButton btnImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblProductCode;
        private FontAwesome.Sharp.IconButton btnDelete;
    }
}