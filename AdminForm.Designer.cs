namespace TCPClient
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_AddAdmin = new System.Windows.Forms.ToolStripButton();
            this.tool_UpdateAdmin = new System.Windows.Forms.ToolStripButton();
            this.tool_DeleteAdmin = new System.Windows.Forms.ToolStripButton();
            this.tool_PremAdmin = new System.Windows.Forms.ToolStripButton();
            this.tool_CloseAdmin = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_AddAdmin,
            this.tool_UpdateAdmin,
            this.tool_DeleteAdmin,
            this.tool_PremAdmin,
            this.tool_CloseAdmin});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(334, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_AddAdmin
            // 
            this.tool_AddAdmin.Image = ((System.Drawing.Image)(resources.GetObject("tool_AddAdmin.Image")));
            this.tool_AddAdmin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_AddAdmin.Name = "tool_AddAdmin";
            this.tool_AddAdmin.Size = new System.Drawing.Size(52, 22);
            this.tool_AddAdmin.Text = "添加";
            this.tool_AddAdmin.Click += new System.EventHandler(this.tool_AddAdmin_Click);
            // 
            // tool_UpdateAdmin
            // 
            this.tool_UpdateAdmin.Image = ((System.Drawing.Image)(resources.GetObject("tool_UpdateAdmin.Image")));
            this.tool_UpdateAdmin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_UpdateAdmin.Name = "tool_UpdateAdmin";
            this.tool_UpdateAdmin.Size = new System.Drawing.Size(52, 22);
            this.tool_UpdateAdmin.Text = "修改";
            this.tool_UpdateAdmin.Click += new System.EventHandler(this.tool_UpdateAdmin_Click);
            // 
            // tool_DeleteAdmin
            // 
            this.tool_DeleteAdmin.Image = ((System.Drawing.Image)(resources.GetObject("tool_DeleteAdmin.Image")));
            this.tool_DeleteAdmin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_DeleteAdmin.Name = "tool_DeleteAdmin";
            this.tool_DeleteAdmin.Size = new System.Drawing.Size(52, 22);
            this.tool_DeleteAdmin.Text = "删除";
            // 
            // tool_PremAdmin
            // 
            this.tool_PremAdmin.Image = ((System.Drawing.Image)(resources.GetObject("tool_PremAdmin.Image")));
            this.tool_PremAdmin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_PremAdmin.Name = "tool_PremAdmin";
            this.tool_PremAdmin.Size = new System.Drawing.Size(52, 22);
            this.tool_PremAdmin.Text = "权限";
            // 
            // tool_CloseAdmin
            // 
            this.tool_CloseAdmin.Image = ((System.Drawing.Image)(resources.GetObject("tool_CloseAdmin.Image")));
            this.tool_CloseAdmin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_CloseAdmin.Name = "tool_CloseAdmin";
            this.tool_CloseAdmin.Size = new System.Drawing.Size(52, 22);
            this.tool_CloseAdmin.Text = "关闭";
            this.tool_CloseAdmin.Click += new System.EventHandler(this.tool_CloseAdmin_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(9, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 161);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(306, 141);
            this.dataGridView1.TabIndex = 0;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 210);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户设置";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool_AddAdmin;
        private System.Windows.Forms.ToolStripButton tool_UpdateAdmin;
        private System.Windows.Forms.ToolStripButton tool_DeleteAdmin;
        private System.Windows.Forms.ToolStripButton tool_PremAdmin;
        private System.Windows.Forms.ToolStripButton tool_CloseAdmin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;

    }
}