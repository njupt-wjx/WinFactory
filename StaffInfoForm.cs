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
    public partial class StaffInfoForm : Form
    {
        public StaffInfoForm()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            string StaffName = txtStaffName.Text;
            string Age = txtAge.Text;
            string Birth = dateTimePickerBirth.Text;
            string People = txtPeople.Text;
            string Culture = combCulture.Text;
            string Phone = txtPhone.Text;
            string Address = txtAddress.Text;
            string EntryTime = dateTimePickerEntry.Text;
            //string ResignTime = dateTimePickerResign.Text;

            if (ID == "" || StaffName == "" || Age == "" || Birth == "" || People == ""
                || Culture == "" || Phone == "" || Address == "" || EntryTime == "")
            {
                MessageBox.Show("不能为空");
            }
            else
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells["ID"].Value = ID;
                dataGridView1.Rows[rowIndex].Cells["StaffName"].Value = StaffName;
                dataGridView1.Rows[rowIndex].Cells["Age"].Value = Age;
                dataGridView1.Rows[rowIndex].Cells["Birth"].Value = Birth;
                dataGridView1.Rows[rowIndex].Cells["People"].Value = People;
                dataGridView1.Rows[rowIndex].Cells["Culture"].Value = Culture;
                dataGridView1.Rows[rowIndex].Cells["Phone"].Value = Phone;
                dataGridView1.Rows[rowIndex].Cells["Address"].Value = Address;
                dataGridView1.Rows[rowIndex].Cells["EntryTime"].Value = EntryTime;
            }
            
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            MyDatabase db = new MyDatabase();
            ///////////////////////////////////
            int RowCount = dataGridView1.RowCount;
            string[] arr = new string[RowCount];
            int flag = 0;//标志是否有相同值
            //计算ID值
            for (int i = 0; i < RowCount; i++)
            {
                arr[i] = dataGridView1.Rows[i].Cells["ID"].Value.ToString();
            }

            //列表是否有相同编号
            for (int i = 0; i < arr.Length;i++ )
            {
                for (int j = i + 1; j < arr.Length;j++ )
                {
                    if (arr[i]==arr[j])
                    {
                        flag = 1;
                    }
                }
            }
            if (flag == 1)
            {
                MessageBox.Show("列表中存在相同编号,请修改!");
                return;
            }

            //数据库是否有相同编号
            for (int i = 0; i < RowCount; i++)
            {
                string ID = dataGridView1.Rows[i].Cells["ID"].Value.ToString();

                string sql1 = "select * from StaffInfo where ID='"+ID+"'";
                MySqlDataReader sdr = db.getReader(sql1);              
                sdr.Read();//读取
                if (sdr.HasRows)
                {
                    MessageBox.Show("数据库编号"+ID+"已经存在,请修改");
                    return;
                }
            }

            for (int i = 0; i < RowCount;i++ )
            {
                string ID = dataGridView1.Rows[i].Cells["ID"].Value.ToString();
                string StaffName = dataGridView1.Rows[i].Cells["StaffName"].Value.ToString();
                string Age = dataGridView1.Rows[i].Cells["Age"].Value.ToString();
                string Birth = dataGridView1.Rows[i].Cells["Birth"].Value.ToString();
                string People = dataGridView1.Rows[i].Cells["People"].Value.ToString();
                string Culture = dataGridView1.Rows[i].Cells["Culture"].Value.ToString();
                string Address = dataGridView1.Rows[i].Cells["Address"].Value.ToString();
                string Phone = dataGridView1.Rows[i].Cells["Phone"].Value.ToString();
                string EntryTime = dataGridView1.Rows[i].Cells["EntryTime"].Value.ToString();
                string sql = "insert into StaffInfo" + "(ID,StaffName,Age,Birth,People,Culture,Address,Phone,EntryTime) values ('"
                                                     + ID + "'" + "," + "'" + StaffName + "'" + "," + "'" + Age + "'" + "," + "'" + Birth + "'" + "," + "'" + People + "'" + ","
                                                     + "'" + Culture + "'," + "'" + Address + "'," + "'" + Phone + "'," + "'" + EntryTime + "'"
                                                     + ")";
                db.executeSql(sql);
            }
            MessageBox.Show("添加数据成功");
        }

        private void 删除记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //currentIndex = e.RowIndex;///////////////////////////////////////////////////////获取当前行
            if (e.Button == MouseButtons.Left)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == -1)
                {
                    if (dataGridView1.CurrentRow.Selected == true)
                    {
                        // MessageBox.Show("选中了行头");
                    }

                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView1.CurrentCell.Selected == true)
                    {
                        //弹出操作菜单
                        contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                    }

                }
            }
        }

        private void btn_SearchAll_Click(object sender, EventArgs e)
        {
            btn_Add.Enabled = false;
            btn_Save.Enabled = false;
            MyDatabase db = new MyDatabase();
            string sql = "select * from StaffInfo";
            DataSet ds = db.getDataSet(sql, "StaffInfo");

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            dataGridView1.Columns["ID"].DataPropertyName = ds.Tables[0].Columns["ID"].ToString(); //绑定数据列
            dataGridView1.Columns["StaffName"].DataPropertyName = ds.Tables[0].Columns["StaffName"].ToString();
            dataGridView1.Columns["Age"].DataPropertyName = ds.Tables[0].Columns["Age"].ToString();
            dataGridView1.Columns["Birth"].DataPropertyName = ds.Tables[0].Columns["Birth"].ToString();
            dataGridView1.Columns["People"].DataPropertyName = ds.Tables[0].Columns["People"].ToString();
            dataGridView1.Columns["Culture"].DataPropertyName = ds.Tables[0].Columns["Culture"].ToString();
            dataGridView1.Columns["Address"].DataPropertyName = ds.Tables[0].Columns["Address"].ToString();
            dataGridView1.Columns["Phone"].DataPropertyName = ds.Tables[0].Columns["Phone"].ToString();
            dataGridView1.Columns["EntryTime"].DataPropertyName = ds.Tables[0].Columns["EntryTime"].ToString();
            dataGridView1.Columns["ResignTime"].DataPropertyName = ds.Tables[0].Columns["ResignTime"].ToString();
            //dataGridView_Show.Columns["Column2"].DataPropertyName = ds.Tables[0].Columns["ID"].ToString(); //绑定数据列
        }

        private void btn_SearchIDorStaffName_Click(object sender, EventArgs e)
        {
            btn_Add.Enabled = false;
            btn_Save.Enabled = false;
            MyDatabase db = new MyDatabase();
            string sql = "select * from StaffInfo where StaffName=" + "'" + txtStaffName.Text + "' or ID="+"'"+txtID.Text+"'";
            DataSet ds = db.getDataSet(sql, "StaffInfo");

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            dataGridView1.Columns["ID"].DataPropertyName = ds.Tables[0].Columns["ID"].ToString(); //绑定数据列
            dataGridView1.Columns["StaffName"].DataPropertyName = ds.Tables[0].Columns["StaffName"].ToString();
            dataGridView1.Columns["Age"].DataPropertyName = ds.Tables[0].Columns["Age"].ToString();
            dataGridView1.Columns["Birth"].DataPropertyName = ds.Tables[0].Columns["Birth"].ToString();
            dataGridView1.Columns["People"].DataPropertyName = ds.Tables[0].Columns["People"].ToString();
            dataGridView1.Columns["Culture"].DataPropertyName = ds.Tables[0].Columns["Culture"].ToString();
            dataGridView1.Columns["Address"].DataPropertyName = ds.Tables[0].Columns["Address"].ToString();
            dataGridView1.Columns["Phone"].DataPropertyName = ds.Tables[0].Columns["Phone"].ToString();
            dataGridView1.Columns["EntryTime"].DataPropertyName = ds.Tables[0].Columns["EntryTime"].ToString();
            dataGridView1.Columns["ResignTime"].DataPropertyName = ds.Tables[0].Columns["ResignTime"].ToString();
            //dataGridView_Show.Columns["Column2"].DataPropertyName = ds.Tables[0].Columns["ID"].ToString(); //绑定数据列
        }

        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            string fileName = "";
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
            CExportExcel.HVCenterAlign(worksheet, 1, 1, dataGridView1.Rows.Count + 1, dataGridView1.ColumnCount + 1);
            //写入标题             
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            { worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText; }
            //写入数值
            for (int r = 0; r < dataGridView1.Rows.Count; r++)
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = dataGridView1.Rows[r].Cells[i].Value;
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            MessageBox.Show(fileName + "导出成功", "提示", MessageBoxButtons.OK);
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);  //fileSaved = true;                 
                }
                catch (Exception ex)
                {//fileSaved = false;                      
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁           
        }

        private void StaffInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void 修改记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}
