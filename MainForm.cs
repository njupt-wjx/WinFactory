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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                this.MaximizeBox = false;
                toolStripStatusLabel1.Text = "当前登录用户：" + loginForm.getStaffNamePara();
            }
        }

        private void 细纱机运行状况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void 早晚运行状况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            form2.Dispose();
        }

        private void 每日生产状况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyProductionForm dailyProductionForm = new DailyProductionForm();
            dailyProductionForm.ShowDialog();
            dailyProductionForm.Dispose();
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
            about.Dispose();
        }

        private void 系统退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            System.Environment.Exit(0);
        }

        private void 重新登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                this.MaximizeBox = false;
                toolStripStatusLabel1.Text = "当前登录用户：" + loginForm.getStaffNamePara();
            }
        }

        private void 用户设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
            adminForm.Dispose();
        }

        private void 系统帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("readme.txt");
        }

        private void 清空数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyDatabase myDatabase = new MyDatabase();
            DialogResult dr = MessageBox.Show("确定要删除吗！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.OK)
            {
                //用户选择确认的操作
                //MessageBox.Show("您选择的是【确认】");
                //MySqlConnection conn = new MySqlConnection("Host =localhost;Database=factory;Username=root;Password=123456");
                //MySqlCommand Cmd = new MySqlCommand();
                //conn.Open();
                try
                {
                    //if (conn.State == ConnectionState.Open)
                    //{
                    //    Cmd.Connection = conn;
                    //    for (int i = 1; i < 21;i++ )
                    //    {
                    //        Cmd.CommandText = "truncate table M" + i.ToString(); 
                    //        Cmd.CommandType = CommandType.Text;
                    //        int ret = Cmd.ExecuteNonQuery();
                    //    }

                    //}
                    for (int i = 1; i < 21; i++)
                    {
                        //DELETE FROM M1 WHERE Date < DATE_SUB(CURDATE(),INTERVAL 6 MONTH);
                        string sql = "delete from M" + i.ToString() + " where Date < DATE_SUB(curdate() , interval 6 month)";
                        myDatabase.executeSql(sql);
                    }

                    MessageBox.Show("清除成功", "提示");
                    MyDatabase.mysqlConn.Close();
                    MyDatabase.mysqlConn.Dispose();

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (dr == DialogResult.Cancel)
            {
                //用户选择取消的操作
                //MessageBox.Show("您选择的是【取消】");
            }
        }

        private void 备份还原数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HaveBackDBForm haveBackDBForm = new HaveBackDBForm();
            haveBackDBForm.ShowDialog();
            haveBackDBForm.Dispose();
        }

        private void 基础信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaffInfoForm staffInfoForm = new StaffInfoForm();
            staffInfoForm.ShowDialog();
            staffInfoForm.Dispose();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
        }

        private void 工艺参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessParaForm processParaForm = new ProcessParaForm();
            processParaForm.ShowDialog();
            processParaForm.Dispose();
        }
    }
}
