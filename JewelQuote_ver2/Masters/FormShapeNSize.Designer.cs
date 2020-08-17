namespace JewelQuote.Masters
{
    partial class FormShapeNSize
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
            this.ddlShape = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSize = new MyControl.Controls.MyTextBox();
            this.txtShape = new MyControl.Controls.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnDelete1 = new FontAwesome.Sharp.IconButton();
            this.btnReset1 = new FontAwesome.Sharp.IconButton();
            this.btnSave1 = new FontAwesome.Sharp.IconButton();
            this.btnDelete2 = new FontAwesome.Sharp.IconButton();
            this.btnReset2 = new FontAwesome.Sharp.IconButton();
            this.btnSave2 = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlShape
            // 
            this.ddlShape.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ddlShape.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlShape.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlShape.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlShape.FormattingEnabled = true;
            this.ddlShape.Location = new System.Drawing.Point(465, 416);
            this.ddlShape.Name = "ddlShape";
            this.ddlShape.Size = new System.Drawing.Size(227, 24);
            this.ddlShape.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(413, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Shape";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(390, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Stone Size";
            // 
            // txtSize
            // 
            this.txtSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSize.BorderColor = System.Drawing.Color.Transparent;
            this.txtSize.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSize.Location = new System.Drawing.Point(465, 388);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(227, 22);
            this.txtSize.TabIndex = 5;
            // 
            // txtShape
            // 
            this.txtShape.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtShape.BorderColor = System.Drawing.Color.Transparent;
            this.txtShape.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShape.Location = new System.Drawing.Point(95, 389);
            this.txtShape.Name = "txtShape";
            this.txtShape.Size = new System.Drawing.Size(227, 22);
            this.txtShape.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 35;
            this.label3.Text = "Shape";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(374, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 466);
            this.panel1.TabIndex = 37;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(5, 72);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(363, 290);
            this.dataGridView1.TabIndex = 38;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.Location = new System.Drawing.Point(380, 72);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(363, 290);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // btnDelete1
            // 
            this.btnDelete1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.btnDelete1.FlatAppearance.BorderSize = 0;
            this.btnDelete1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDelete1.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDelete1.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnDelete1.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDelete1.IconSize = 20;
            this.btnDelete1.Location = new System.Drawing.Point(240, 462);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Rotation = 0D;
            this.btnDelete1.Size = new System.Drawing.Size(91, 27);
            this.btnDelete1.TabIndex = 3;
            this.btnDelete1.Text = "Delete";
            this.btnDelete1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete1.UseVisualStyleBackColor = false;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // btnReset1
            // 
            this.btnReset1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReset1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.btnReset1.FlatAppearance.BorderSize = 0;
            this.btnReset1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnReset1.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReset1.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnReset1.IconColor = System.Drawing.Color.Gainsboro;
            this.btnReset1.IconSize = 20;
            this.btnReset1.Location = new System.Drawing.Point(146, 462);
            this.btnReset1.Name = "btnReset1";
            this.btnReset1.Rotation = 0D;
            this.btnReset1.Size = new System.Drawing.Size(91, 27);
            this.btnReset1.TabIndex = 2;
            this.btnReset1.Text = "Reset";
            this.btnReset1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset1.UseVisualStyleBackColor = false;
            this.btnReset1.Click += new System.EventHandler(this.btnReset1_Click);
            // 
            // btnSave1
            // 
            this.btnSave1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.btnSave1.FlatAppearance.BorderSize = 0;
            this.btnSave1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSave1.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSave1.IconChar = FontAwesome.Sharp.IconChar.SdCard;
            this.btnSave1.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSave1.IconSize = 20;
            this.btnSave1.Location = new System.Drawing.Point(52, 462);
            this.btnSave1.Name = "btnSave1";
            this.btnSave1.Rotation = 0D;
            this.btnSave1.Size = new System.Drawing.Size(91, 27);
            this.btnSave1.TabIndex = 1;
            this.btnSave1.Text = "Save";
            this.btnSave1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave1.UseVisualStyleBackColor = false;
            this.btnSave1.Click += new System.EventHandler(this.btnSave1_Click);
            // 
            // btnDelete2
            // 
            this.btnDelete2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.btnDelete2.FlatAppearance.BorderSize = 0;
            this.btnDelete2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete2.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDelete2.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDelete2.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnDelete2.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDelete2.IconSize = 20;
            this.btnDelete2.Location = new System.Drawing.Point(604, 462);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Rotation = 0D;
            this.btnDelete2.Size = new System.Drawing.Size(91, 27);
            this.btnDelete2.TabIndex = 9;
            this.btnDelete2.Text = "Delete";
            this.btnDelete2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete2.UseVisualStyleBackColor = false;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // btnReset2
            // 
            this.btnReset2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReset2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.btnReset2.FlatAppearance.BorderSize = 0;
            this.btnReset2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset2.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnReset2.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReset2.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnReset2.IconColor = System.Drawing.Color.Gainsboro;
            this.btnReset2.IconSize = 20;
            this.btnReset2.Location = new System.Drawing.Point(510, 462);
            this.btnReset2.Name = "btnReset2";
            this.btnReset2.Rotation = 0D;
            this.btnReset2.Size = new System.Drawing.Size(91, 27);
            this.btnReset2.TabIndex = 8;
            this.btnReset2.Text = "Reset";
            this.btnReset2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset2.UseVisualStyleBackColor = false;
            this.btnReset2.Click += new System.EventHandler(this.btnReset2_Click);
            // 
            // btnSave2
            // 
            this.btnSave2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.btnSave2.FlatAppearance.BorderSize = 0;
            this.btnSave2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave2.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSave2.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSave2.IconChar = FontAwesome.Sharp.IconChar.SdCard;
            this.btnSave2.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSave2.IconSize = 20;
            this.btnSave2.Location = new System.Drawing.Point(416, 462);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Rotation = 0D;
            this.btnSave2.Size = new System.Drawing.Size(91, 27);
            this.btnSave2.TabIndex = 7;
            this.btnSave2.Text = "Save";
            this.btnSave2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave2.UseVisualStyleBackColor = false;
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(154, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "SHAPES";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(520, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 47;
            this.label5.Text = "SIZE N\' SHAPE";
            // 
            // FormShapeNSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 556);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete2);
            this.Controls.Add(this.btnReset2);
            this.Controls.Add(this.btnSave2);
            this.Controls.Add(this.btnDelete1);
            this.Controls.Add(this.btnReset1);
            this.Controls.Add(this.btnSave1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtShape);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.ddlShape);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormShapeNSize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Stone Size N\' Shape";
            this.Load += new System.EventHandler(this.FormShapeNSize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlShape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MyControl.Controls.MyTextBox txtSize;
        private MyControl.Controls.MyTextBox txtShape;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private FontAwesome.Sharp.IconButton btnDelete1;
        private FontAwesome.Sharp.IconButton btnReset1;
        private FontAwesome.Sharp.IconButton btnSave1;
        private FontAwesome.Sharp.IconButton btnDelete2;
        private FontAwesome.Sharp.IconButton btnReset2;
        private FontAwesome.Sharp.IconButton btnSave2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}