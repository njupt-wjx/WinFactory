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
    public partial class UpdateDailyProductionForm : Form
    {
        private string[] updatePara;
        public UpdateDailyProductionForm()
        {
            InitializeComponent();
            updatePara = new string[6];
        }

        private void UpdateInfo_Click(object sender, EventArgs e)
        {
            string Date = dateTimePicker1.Text;
            string Class = combClass.Text;
            string StaffName = txtStaffName.Text;
            string Kind = txtKind.Text;
            string MachineNumber = txtMachineNumber.Text;
            string Output = txtOutput.Text;
            if (Class == "" || StaffName == "" || Kind == "" || MachineNumber == "" || Output == "")
            {
                MessageBox.Show("不能为空");
            }
            else
            {
                updatePara[0] = Date;
                updatePara[1] = Class;
                updatePara[2] = StaffName;
                updatePara[3] = Kind;
                updatePara[4] = MachineNumber;
                updatePara[5] = Output;
                //int rowIndex = dataGridView_Show.Rows.Add();
                //dataGridView_Show.Rows[rowIndex].Cells["Order"].Value = rowIndex;
                //dataGridView_Show.Rows[rowIndex].Cells["Date"].Value = Date;
                //dataGridView_Show.Rows[rowIndex].Cells["Class"].Value = Class;
                //dataGridView_Show.Rows[rowIndex].Cells["StaffName"].Value = StaffName;
                //dataGridView_Show.Rows[rowIndex].Cells["Kind"].Value = Kind;
                //dataGridView_Show.Rows[rowIndex].Cells["MachineNumber"].Value = ManchineNumber;
                //dataGridView_Show.Rows[rowIndex].Cells["Output"].Value = Output;
                //string sql = "insert into Daily_Production" + "(Date,Class,StaffName,Kind,MachineNumber,Output) values ('"
                //                                     + Date + "'" + "," + "'" + Class + "'" + "," + "'" + StaffName + "'" + "," + "'" + Kind + "'" + "," + "'" + ManchineNumber + "'" + "," + "'" + Output + "'" + ")";
                //MyDatabase db = new MyDatabase();
                //db.executeSql(sql);
                //MessageBox.Show("添加数据成功");
            }
            this.DialogResult = DialogResult.OK;
        }

        public string[] getUpdatePara()
        {
            return updatePara;
        }

        private void UpdateDailyProductionForm_Load(object sender, EventArgs e)
        {
            DailyProductionForm dailyProdictionForm = new DailyProductionForm();
            string[] arr = dailyProdictionForm.getGoUpdatePara();
            dateTimePicker1.Text = arr[0];
            combClass.Text = arr[1];
            txtStaffName.Text = arr[2];
            txtKind.Text = arr[3];
            txtMachineNumber.Text = arr[4];
            txtOutput.Text = arr[5];
        }
    }
}
