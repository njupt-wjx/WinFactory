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
    public partial class DailyProductionForm : Form
    {
        private static string[] goUpdatePara = new string[6];
        private int currentIndex;
        public DailyProductionForm()
        {
            InitializeComponent();
            ///////////////重绘窗口大小////////////////////////
            int count = this.Controls.Count * 2 + 2;
            float[] factor = new float[count];
            int i = 0;
            factor[i++] = Size.Width;
            factor[i++] = Size.Height;
            foreach (Control ctrl in this.Controls)
            {
                factor[i++] = ctrl.Location.X / (float)Size.Width;
                factor[i++] = ctrl.Location.Y / (float)Size.Height;
                ctrl.Tag = ctrl.Size;
            }
            Tag = factor;
        }


        private void DailyProductionForm_Load(object sender, EventArgs e)
        {
            //清空DataGridView
            //DataTable dt = (DataTable)dataGridView_Show.DataSource;
            //dt.Rows.Clear();
            //dataGridView_Show.DataSource = dt;  
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string Date = dateTimePicker1.Text;
            string Class = combClass.Text;
            string StaffName = txtStaffName.Text;
            string Kind = txtKind.Text;
            string ManchineNumber = txtManchineNumber.Text;
            string Output = txtOutput.Text;
            if (Class == "" || StaffName =="" || Kind == "" || ManchineNumber == "" || Output == "")
            {
                MessageBox.Show("不能为空");
            }
            else
            {
                int rowIndex = dataGridView_Show.Rows.Add();
                dataGridView_Show.Rows[rowIndex].Cells["Order"].Value = rowIndex;
                dataGridView_Show.Rows[rowIndex].Cells["Date"].Value = Date;
                dataGridView_Show.Rows[rowIndex].Cells["Class"].Value = Class;
                dataGridView_Show.Rows[rowIndex].Cells["StaffName"].Value = StaffName;
                dataGridView_Show.Rows[rowIndex].Cells["Kind"].Value = Kind;
                dataGridView_Show.Rows[rowIndex].Cells["MachineNumber"].Value = ManchineNumber;
                dataGridView_Show.Rows[rowIndex].Cells["Output"].Value = Output;
                //string sql = "insert into Daily_Production" + "(Date,Class,StaffName,Kind,MachineNumber,Output) values ('"
                //                                     + Date + "'" + "," + "'"+Class+"'" + "," +"'"+ StaffName+"'" + "," + "'"+Kind+"'" + "," + "'"+ManchineNumber+"'" + "," + "'"+Output+"'" + ")";
                //MyDatabase db = new MyDatabase();
                //db.executeSql(sql);
                //MessageBox.Show("添加数据成功");
            }
            
        }

        private void dataGridView_Show_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            currentIndex = e.RowIndex;///////////////////////////////////////////////////////获取当前行
            if (e.Button == MouseButtons.Left)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == -1)
                {
                    if (dataGridView_Show.CurrentRow.Selected == true)
                    { 
                       // MessageBox.Show("选中了行头");
                    }
                   
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >=0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView_Show.CurrentCell.Selected == true)
                    {
                        goUpdatePara[0] = dataGridView_Show.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                        goUpdatePara[1] = dataGridView_Show.Rows[e.RowIndex].Cells["Class"].Value.ToString();
                        goUpdatePara[2] = dataGridView_Show.Rows[e.RowIndex].Cells["StaffName"].Value.ToString();
                        goUpdatePara[3] = dataGridView_Show.Rows[e.RowIndex].Cells["Kind"].Value.ToString();
                        goUpdatePara[4] = dataGridView_Show.Rows[e.RowIndex].Cells["MachineNumber"].Value.ToString();
                        goUpdatePara[5] = dataGridView_Show.Rows[e.RowIndex].Cells["Output"].Value.ToString();
                        ////只选中一行时设置活动单元格
                        //if (dataGridView_Show.SelectedRows.Count == 1)
                        //{
                        //    dataGridView_Show.CurrentCell = dataGridView_Show.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        //}
                        //弹出操作菜单
                        contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                    }
                    
                }
            }
        }

        public string[] getGoUpdatePara()
        {
            return goUpdatePara;
        }

        private void 编辑记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDailyProductionForm updateForm = new UpdateDailyProductionForm();
            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                
                string[] comeUpdatePara = updateForm.getUpdatePara();
                dataGridView_Show.Rows[currentIndex].Cells["Date"].Value = comeUpdatePara[0];
                dataGridView_Show.Rows[currentIndex].Cells["Class"].Value = comeUpdatePara[1];
                dataGridView_Show.Rows[currentIndex].Cells["StaffName"].Value = comeUpdatePara[2];
                dataGridView_Show.Rows[currentIndex].Cells["Kind"].Value = comeUpdatePara[3];
                dataGridView_Show.Rows[currentIndex].Cells["MachineNumber"].Value = comeUpdatePara[4];
                dataGridView_Show.Rows[currentIndex].Cells["Output"].Value = comeUpdatePara[5];
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            int RowCount = dataGridView_Show.RowCount;
            for (int i = 0; i < RowCount;i++ )
            {
                string Date = dataGridView_Show.Rows[i].Cells["Date"].Value.ToString();
                string Class = dataGridView_Show.Rows[i].Cells["Class"].Value.ToString();
                string StaffName = dataGridView_Show.Rows[i].Cells["StaffName"].Value.ToString();
                string Kind = dataGridView_Show.Rows[i].Cells["Kind"].Value.ToString();
                string MachineNumber = dataGridView_Show.Rows[i].Cells["MachineNumber"].Value.ToString();
                string Output = dataGridView_Show.Rows[i].Cells["Output"].Value.ToString();
                string sql = "insert into Daily_Production" + "(Date,Class,StaffName,Kind,MachineNumber,Output) values ('"
                                                     + Date + "'" + "," + "'" + Class + "'" + "," + "'" + StaffName + "'" + "," + "'" + Kind + "'" + "," + "'" + MachineNumber + "'" + "," + "'" + Output + "'" + ")";
                MyDatabase db = new MyDatabase();
                db.executeSql(sql);
            }
            MessageBox.Show("添加数据成功");

        }

        private void 删除记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView_Show.Rows.Remove(dataGridView_Show.Rows[currentIndex]);
            for (int i = 0; i < dataGridView_Show.RowCount;i++ )
            {
                dataGridView_Show.Rows[i].Cells["Order"].Value = i;
            }
            
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            btn_Add.Enabled = false;
            btn_Save.Enabled = false;
            MyDatabase db = new MyDatabase();
            string sql = "select * from daily_production";
            DataSet ds = db.getDataSet(sql, "daily_production");

            dataGridView_Show.AutoGenerateColumns = false;
            dataGridView_Show.DataSource = ds.Tables[0].DefaultView;
            dataGridView_Show.Columns["Date"].DataPropertyName = ds.Tables[0].Columns["Date"].ToString(); //绑定数据列
            dataGridView_Show.Columns["Class"].DataPropertyName = ds.Tables[0].Columns["Class"].ToString();
            dataGridView_Show.Columns["StaffName"].DataPropertyName = ds.Tables[0].Columns["StaffName"].ToString();
            dataGridView_Show.Columns["Kind"].DataPropertyName = ds.Tables[0].Columns["Kind"].ToString();
            dataGridView_Show.Columns["MachineNumber"].DataPropertyName = ds.Tables[0].Columns["MachineNumber"].ToString();
            dataGridView_Show.Columns["Output"].DataPropertyName = ds.Tables[0].Columns["Output"].ToString();
            //dataGridView_Show.Columns["Column2"].DataPropertyName = ds.Tables[0].Columns["ID"].ToString(); //绑定数据列
            for (int i = 0; i < dataGridView_Show.RowCount; i++)
            {
                dataGridView_Show.Rows[i].Cells["Order"].Value = i;
            }
        }

        private void btn_DateStaffName_Click(object sender, EventArgs e)
        {
            btn_Add.Enabled = false;
            btn_Save.Enabled = false;
            MyDatabase db = new MyDatabase();
            string sql = "select * from daily_production where Date between "+"'"+dateTimePicker1.Text+"'"+" and "
                         +"'"+dateTimePicker2.Text+"'"+" and StaffName="+"'"+txtStaffName.Text+"'";
            DataSet ds = db.getDataSet(sql, "daily_production");

            dataGridView_Show.AutoGenerateColumns = false;
            dataGridView_Show.DataSource = ds.Tables[0].DefaultView;
            dataGridView_Show.Columns["Date"].DataPropertyName = ds.Tables[0].Columns["Date"].ToString(); //绑定数据列
            dataGridView_Show.Columns["Class"].DataPropertyName = ds.Tables[0].Columns["Class"].ToString();
            dataGridView_Show.Columns["StaffName"].DataPropertyName = ds.Tables[0].Columns["StaffName"].ToString();
            dataGridView_Show.Columns["Kind"].DataPropertyName = ds.Tables[0].Columns["Kind"].ToString();
            dataGridView_Show.Columns["MachineNumber"].DataPropertyName = ds.Tables[0].Columns["MachineNumber"].ToString();
            dataGridView_Show.Columns["Output"].DataPropertyName = ds.Tables[0].Columns["Output"].ToString();
            //dataGridView_Show.Columns["Column2"].DataPropertyName = ds.Tables[0].Columns["ID"].ToString(); //绑定数据列
            for (int i = 0; i < dataGridView_Show.RowCount; i++)
            {
                dataGridView_Show.Rows[i].Cells["Order"].Value = i;
            }
        }

        private void dataGridView_Show_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dataGridView_Show.RowCount; i++)
            {
                dataGridView_Show.Rows[i].Cells["Order"].Value = i;
            }
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
            CExportExcel.HVCenterAlign(worksheet, 1, 1, dataGridView_Show.Rows.Count + 1, dataGridView_Show.ColumnCount+1);
            //写入标题             
            for (int i = 0; i < dataGridView_Show.ColumnCount; i++)
            { worksheet.Cells[1, i + 1] = dataGridView_Show.Columns[i].HeaderText; }
            //写入数值
            for (int r = 0; r < dataGridView_Show.Rows.Count; r++)
            {
                for (int i = 0; i < dataGridView_Show.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = dataGridView_Show.Rows[r].Cells[i].Value;
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

        private void DailyProductionForm_Resize(object sender, EventArgs e)
        {
            float[] scale = (float[])Tag;
            int i = 2;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.Left = (int)(Size.Width * scale[i++]);
                ctrl.Top = (int)(Size.Height * scale[i++]);
                ctrl.Width = (int)(Size.Width / (float)scale[0] * ((Size)ctrl.Tag).Width);
                ctrl.Height = (int)(Size.Height / (float)scale[1] * ((Size)ctrl.Tag).Height);
            }

        }

       



        
    }
}
