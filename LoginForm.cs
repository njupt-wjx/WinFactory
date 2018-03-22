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
    public partial class LoginForm : Form
    {
        private string StaffNamePara;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            MyDatabase DataBase = new MyDatabase();
            if (UserName.Text == "")//判断用户名是否为空
            {
                MessageBox.Show("请输入用户名", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Password.Text == "")//判断密码是否为空
                {
                    MessageBox.Show("请输入密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string sql = "select Password from Admin where UserName='"+UserName.Text.Trim()+"'";
                    MySqlDataReader sdr = DataBase.getReader(sql);              
                    sdr.Read();//读取
                    if (sdr.HasRows)//验证用户名和密码
                    {
                        if (sdr["Password"].ToString().Trim()==Password.Text)
                        {
                            DataBase.closeConn();
                            //MainForm mainForm = new MainForm();
                            //mainForm.Show();
                            StaffNamePara = UserName.Text.Trim();
                            this.Hide();

                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码错误");//弹出提示信息
                        }
                        //sdr.Close();
                        //cmd = new SqlCommand("select * from tb_User where UserName='" + txtName.Text + "'", conn);
                        //SqlDataReader sdr1 = cmd.ExecuteReader();
                        //sdr1.Read();
                        //string UserPower = sdr1["power"].ToString().Trim();
                        //conn.Close();//关闭链接
                        //frmMain main = new frmMain();
                        //main.power = UserPower;
                        //main.Names = txtName.Text;
                        //main.Times = DateTime.Now.ToShortDateString();
                        //main.Show();//打开主窗体
                        //this.Hide();//隐藏当前登录窗体
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误");//弹出提示信息
                    }
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                Application.Exit();
                //System.Environment.Exit(0);
            }
        }

        public string getStaffNamePara()
        {
            return StaffNamePara;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
