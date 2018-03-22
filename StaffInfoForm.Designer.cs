namespace TCPClient
{
    partial class StaffInfoForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.dateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
            this.txtPeople = new System.Windows.Forms.TextBox();
            this.combCulture = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.dateTimePickerEntry = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerResign = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.People = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Culture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResignTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_SearchAll = new System.Windows.Forms.Button();
            this.btn_SearchIDorStaffName = new System.Windows.Forms.Button();
            this.btn_ExportExcel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "年龄";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "出生日期";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(454, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "民族";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(543, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "文化程度";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "家庭住址";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(648, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "电话";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(289, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "入职时间";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(454, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "离职时间";
            this.label10.Visible = false;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(44, 22);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(52, 21);
            this.txtID.TabIndex = 10;
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(131, 22);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(66, 21);
            this.txtStaffName.TabIndex = 11;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(235, 22);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(47, 21);
            this.txtAge.TabIndex = 12;
            // 
            // dateTimePickerBirth
            // 
            this.dateTimePickerBirth.Location = new System.Drawing.Point(341, 22);
            this.dateTimePickerBirth.Name = "dateTimePickerBirth";
            this.dateTimePickerBirth.Size = new System.Drawing.Size(105, 21);
            this.dateTimePickerBirth.TabIndex = 13;
            // 
            // txtPeople
            // 
            this.txtPeople.Location = new System.Drawing.Point(483, 20);
            this.txtPeople.Name = "txtPeople";
            this.txtPeople.Size = new System.Drawing.Size(51, 21);
            this.txtPeople.TabIndex = 14;
            // 
            // combCulture
            // 
            this.combCulture.FormattingEnabled = true;
            this.combCulture.Items.AddRange(new object[] {
            "小学",
            "初中",
            "高中",
            "专科",
            "大专",
            "本科",
            "硕士",
            "博士"});
            this.combCulture.Location = new System.Drawing.Point(597, 20);
            this.combCulture.Name = "combCulture";
            this.combCulture.Size = new System.Drawing.Size(44, 20);
            this.combCulture.TabIndex = 15;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(72, 65);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(210, 21);
            this.txtAddress.TabIndex = 16;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(678, 22);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(78, 21);
            this.txtPhone.TabIndex = 17;
            // 
            // dateTimePickerEntry
            // 
            this.dateTimePickerEntry.Location = new System.Drawing.Point(341, 63);
            this.dateTimePickerEntry.Name = "dateTimePickerEntry";
            this.dateTimePickerEntry.Size = new System.Drawing.Size(105, 21);
            this.dateTimePickerEntry.TabIndex = 18;
            // 
            // dateTimePickerResign
            // 
            this.dateTimePickerResign.Location = new System.Drawing.Point(505, 65);
            this.dateTimePickerResign.Name = "dateTimePickerResign";
            this.dateTimePickerResign.Size = new System.Drawing.Size(105, 21);
            this.dateTimePickerResign.TabIndex = 19;
            this.dateTimePickerResign.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(23, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(733, 314);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "员工基本信息表(编号不能相同)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DimGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.StaffName,
            this.Age,
            this.Birth,
            this.People,
            this.Culture,
            this.Address,
            this.Phone,
            this.EntryTime,
            this.ResignTime});
            this.dataGridView1.Location = new System.Drawing.Point(14, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(706, 288);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // ID
            // 
            this.ID.HeaderText = "编号";
            this.ID.Name = "ID";
            // 
            // StaffName
            // 
            this.StaffName.HeaderText = "姓名";
            this.StaffName.Name = "StaffName";
            // 
            // Age
            // 
            this.Age.HeaderText = "年龄";
            this.Age.Name = "Age";
            // 
            // Birth
            // 
            this.Birth.HeaderText = "出生日期";
            this.Birth.Name = "Birth";
            // 
            // People
            // 
            this.People.HeaderText = "民族";
            this.People.Name = "People";
            // 
            // Culture
            // 
            this.Culture.HeaderText = "文化";
            this.Culture.Name = "Culture";
            // 
            // Address
            // 
            this.Address.HeaderText = "家庭住址";
            this.Address.Name = "Address";
            // 
            // Phone
            // 
            this.Phone.HeaderText = "联系电话";
            this.Phone.Name = "Phone";
            // 
            // EntryTime
            // 
            this.EntryTime.HeaderText = "入职时间";
            this.EntryTime.Name = "EntryTime";
            // 
            // ResignTime
            // 
            this.ResignTime.HeaderText = "离职时间";
            this.ResignTime.Name = "ResignTime";
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(678, 66);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 21;
            this.btn_Add.Text = "增加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(91, 441);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 22;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改记录ToolStripMenuItem,
            this.删除记录ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // 修改记录ToolStripMenuItem
            // 
            this.修改记录ToolStripMenuItem.Name = "修改记录ToolStripMenuItem";
            this.修改记录ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改记录ToolStripMenuItem.Text = "修改记录";
            this.修改记录ToolStripMenuItem.Click += new System.EventHandler(this.修改记录ToolStripMenuItem_Click);
            // 
            // 删除记录ToolStripMenuItem
            // 
            this.删除记录ToolStripMenuItem.Name = "删除记录ToolStripMenuItem";
            this.删除记录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除记录ToolStripMenuItem.Text = "删除记录";
            this.删除记录ToolStripMenuItem.Click += new System.EventHandler(this.删除记录ToolStripMenuItem_Click);
            // 
            // btn_SearchAll
            // 
            this.btn_SearchAll.Location = new System.Drawing.Point(249, 441);
            this.btn_SearchAll.Name = "btn_SearchAll";
            this.btn_SearchAll.Size = new System.Drawing.Size(75, 23);
            this.btn_SearchAll.TabIndex = 24;
            this.btn_SearchAll.Text = "查询全部";
            this.btn_SearchAll.UseVisualStyleBackColor = true;
            this.btn_SearchAll.Click += new System.EventHandler(this.btn_SearchAll_Click);
            // 
            // btn_SearchIDorStaffName
            // 
            this.btn_SearchIDorStaffName.Location = new System.Drawing.Point(408, 441);
            this.btn_SearchIDorStaffName.Name = "btn_SearchIDorStaffName";
            this.btn_SearchIDorStaffName.Size = new System.Drawing.Size(112, 23);
            this.btn_SearchIDorStaffName.TabIndex = 25;
            this.btn_SearchIDorStaffName.Text = "按编号或姓名查询";
            this.btn_SearchIDorStaffName.UseVisualStyleBackColor = true;
            this.btn_SearchIDorStaffName.Click += new System.EventHandler(this.btn_SearchIDorStaffName_Click);
            // 
            // btn_ExportExcel
            // 
            this.btn_ExportExcel.Location = new System.Drawing.Point(587, 441);
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.Size = new System.Drawing.Size(75, 23);
            this.btn_ExportExcel.TabIndex = 26;
            this.btn_ExportExcel.Text = "导出数据到Excel";
            this.btn_ExportExcel.UseVisualStyleBackColor = true;
            this.btn_ExportExcel.Click += new System.EventHandler(this.btn_ExportExcel_Click);
            // 
            // StaffInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 486);
            this.Controls.Add(this.btn_ExportExcel);
            this.Controls.Add(this.btn_SearchIDorStaffName);
            this.Controls.Add(this.btn_SearchAll);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePickerResign);
            this.Controls.Add(this.dateTimePickerEntry);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.combCulture);
            this.Controls.Add(this.txtPeople);
            this.Controls.Add(this.dateTimePickerBirth);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StaffInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工基本信息";
            this.Load += new System.EventHandler(this.StaffInfoForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirth;
        private System.Windows.Forms.TextBox txtPeople;
        private System.Windows.Forms.ComboBox combCulture;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.DateTimePicker dateTimePickerEntry;
        private System.Windows.Forms.DateTimePicker dateTimePickerResign;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn People;
        private System.Windows.Forms.DataGridViewTextBoxColumn Culture;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResignTime;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 修改记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除记录ToolStripMenuItem;
        private System.Windows.Forms.Button btn_SearchAll;
        private System.Windows.Forms.Button btn_SearchIDorStaffName;
        private System.Windows.Forms.Button btn_ExportExcel;
    }
}