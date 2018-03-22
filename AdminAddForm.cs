using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TCPClient
{
    public partial class AdminAddForm : Form
    {
        public AdminAddForm()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            MyDatabase db = new MyDatabase();
            if (txtAdminName.Text != "")
            {
                string sql0 = "select * from Admin where UserName='" + txtAdminName.Text.Trim() + "'";
                MySqlDataReader sdr = db.getReader(sql0);
                sdr.Read();
                if (sdr.HasRows)
                {
                    MessageBox.Show("该用户名已经存在！请修改！");
                    return;
                }
            }
            
            if (txtAdminName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("不能为空！");
            }
            else
            {
                string sql1 = "insert into admin" + "(UserName,Password) values ('"+ txtAdminName.Text + "'" + "," + "'" + txtPassword.Text + "')";
                db.executeSql(sql1);
                MessageBox.Show("添加数据成功");
            }
        }
    }
}
