namespace TCPClient
{
    partial class DailyProductionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.combClass = new System.Windows.Forms.ComboBox();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.txtKind = new System.Windows.Forms.TextBox();
            this.txtManchineNumber = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.dataGridView_Show = new System.Windows.Forms.DataGridView();
            this.Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编辑记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btn_DateStaffName = new System.Windows.Forms.Button();
            this.btn_ExportExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Show)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "班次";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "员工姓名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "产品种类";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(600, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "负责机器";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(750, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "产量";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(42, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(107, 21);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // combClass
            // 
            this.combClass.FormattingEnabled = true;
            this.combClass.Items.AddRange(new object[] {
            "早班",
            "晚班"});
            this.combClass.Location = new System.Drawing.Point(205, 16);
            this.combClass.Name = "combClass";
            this.combClass.Size = new System.Drawing.Size(53, 20);
            this.combClass.TabIndex = 7;
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(346, 16);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(70, 21);
            this.txtStaffName.TabIndex = 8;
            // 
            // txtKind
            // 
            this.txtKind.Location = new System.Drawing.Point(497, 16);
            this.txtKind.Name = "txtKind";
            this.txtKind.Size = new System.Drawing.Size(71, 21);
            this.txtKind.TabIndex = 9;
            // 
            // txtManchineNumber
            // 
            this.txtManchineNumber.Location = new System.Drawing.Point(650, 16);
            this.txtManchineNumber.Name = "txtManchineNumber";
            this.txtManchineNumber.Size = new System.Drawing.Size(55, 21);
            this.txtManchineNumber.TabIndex = 10;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(777, 16);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(51, 21);
            this.txtOutput.TabIndex = 11;
            // 
            // dataGridView_Show
            // 
            this.dataGridView_Show.AllowUserToAddRows = false;
            this.dataGridView_Show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Show.BackgroundColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Show.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_Show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Show.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Order,
            this.Date,
            this.Class,
            this.StaffName,
            this.Kind,
            this.MachineNumber,
            this.Output});
            this.dataGridView_Show.Location = new System.Drawing.Point(12, 73);
            this.dataGridView_Show.Name = "dataGridView_Show";
            this.dataGridView_Show.Size = new System.Drawing.Size(929, 384);
            this.dataGridView_Show.TabIndex = 12;
            this.dataGridView_Show.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Show_CellMouseDown);
            this.dataGridView_Show.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Show_ColumnHeaderMouseClick);
            // 
            // Order
            // 
            this.Order.HeaderText = "序号";
            this.Order.Name = "Order";
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.HeaderText = "日期";
            this.Date.Name = "Date";
            // 
            // Class
            // 
            this.Class.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Class.HeaderText = "班次";
            this.Class.Name = "Class";
            // 
            // StaffName
            // 
            this.StaffName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StaffName.HeaderText = "员工姓名";
            this.StaffName.Name = "StaffName";
            // 
            // Kind
            // 
            this.Kind.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Kind.HeaderText = "产品种类";
            this.Kind.Name = "Kind";
            // 
            // MachineNumber
            // 
            this.MachineNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MachineNumber.HeaderText = "负责机器";
            this.MachineNumber.Name = "MachineNumber";
            // 
            // Output
            // 
            this.Output.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Output.HeaderText = "产量";
            this.Output.Name = "Output";
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(866, 15);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 13;
            this.btn_Add.Text = "增加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(379, 472);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 14;
            this.btn_Search.Text = "查询全部";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑记录ToolStripMenuItem,
            this.删除记录ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 编辑记录ToolStripMenuItem
            // 
            this.编辑记录ToolStripMenuItem.Name = "编辑记录ToolStripMenuItem";
            this.编辑记录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.编辑记录ToolStripMenuItem.Text = "修改记录";
            this.编辑记录ToolStripMenuItem.Click += new System.EventHandler(this.编辑记录ToolStripMenuItem_Click);
            // 
            // 删除记录ToolStripMenuItem
            // 
            this.删除记录ToolStripMenuItem.Name = "删除记录ToolStripMenuItem";
            this.删除记录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除记录ToolStripMenuItem.Text = "删除记录";
            this.删除记录ToolStripMenuItem.Click += new System.EventHandler(this.删除记录ToolStripMenuItem_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(206, 472);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 17;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(18, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "至";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(42, 42);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(107, 21);
            this.dateTimePicker2.TabIndex = 19;
            // 
            // btn_DateStaffName
            // 
            this.btn_DateStaffName.Location = new System.Drawing.Point(532, 472);
            this.btn_DateStaffName.Name = "btn_DateStaffName";
            this.btn_DateStaffName.Size = new System.Drawing.Size(106, 23);
            this.btn_DateStaffName.TabIndex = 20;
            this.btn_DateStaffName.Text = "按日期员工查询";
            this.btn_DateStaffName.UseVisualStyleBackColor = true;
            this.btn_DateStaffName.Click += new System.EventHandler(this.btn_DateStaffName_Click);
            // 
            // btn_ExportExcel
            // 
            this.btn_ExportExcel.Location = new System.Drawing.Point(704, 472);
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.Size = new System.Drawing.Size(107, 23);
            this.btn_ExportExcel.TabIndex = 21;
            this.btn_ExportExcel.Text = "导出数据到Excel";
            this.btn_ExportExcel.UseVisualStyleBackColor = true;
            this.btn_ExportExcel.Click += new System.EventHandler(this.btn_ExportExcel_Click);
            // 
            // DailyProductionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 507);
            this.Controls.Add(this.btn_ExportExcel);
            this.Controls.Add(this.btn_DateStaffName);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.dataGridView_Show);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtManchineNumber);
            this.Controls.Add(this.txtKind);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.combClass);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DailyProductionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日常生产管理";
            this.Load += new System.EventHandler(this.DailyProductionForm_Load);
            this.Resize += new System.EventHandler(this.DailyProductionForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Show)).EndInit();
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
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox combClass;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.TextBox txtKind;
        private System.Windows.Forms.TextBox txtManchineNumber;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.DataGridView dataGridView_Show;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kind;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Output;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 编辑记录ToolStripMenuItem;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.ToolStripMenuItem 删除记录ToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btn_DateStaffName;
        private System.Windows.Forms.Button btn_ExportExcel;
    }
}