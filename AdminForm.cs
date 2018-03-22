using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCPClient
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void tool_CloseAdmin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tool_AddAdmin_Click(object sender, EventArgs e)
        {
            AdminAddForm adminAddForm = new AdminAddForm();
            adminAddForm.Text = tool_AddAdmin.Text + "用户";
            adminAddForm.Tag = 1;
            adminAddForm.ShowDialog();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void tool_UpdateAdmin_Click(object sender, EventArgs e)
        {

        }

   
    }
}
