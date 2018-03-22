using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace TCPClient
{
    class CExportExcel
    {
        /// <summary> 
        /// 导出到excel
        ///  <param name="fileName">默认文件名</param> 
        ///  <param name="listView">数据源，一个页面上的ListView控件</param> 
        ///  <param name="titleRowCount">标题占据的行数，为0表示无标题</param> 
        public static void ExportExcel()
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":")<0 ) return;//点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application(); 
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
            //string date = DateTime.Now.ToString("yyyy-MM-dd");
            MergeCells(worksheet, 1, 1, 1, 7, " 生产情况");
            MergeCells(worksheet, 2, 1, 22, 1, "白班");
            MergeCells(worksheet, 23, 1, 42, 1, "晚班");
            worksheet.Cells[2, 2] = "机器号";
            worksheet.Cells[2, 3] = "开机时间";
            worksheet.Cells[2, 4] = "停机时间";
            worksheet.Cells[2, 5] = "效率";
            worksheet.Cells[2, 6] = "产量";
            for (int i = 1; i <= 20;i++ )
            {
                worksheet.Cells[i + 2, 2] = "M" + i.ToString();
                worksheet.Cells[i + 22, 2] = "M" + i.ToString();
            }
            HVCenterAlign(worksheet, 2, 2, 42, 6);

            System.Windows.Forms.Application.DoEvents();    
                
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应 
            //if (Microsoft.Office.Interop.cmbxType.Text != "Notification")    
            //{    
            // Excel.Range rg = worksheet.get_Range(worksheet.Cells[2, 2], worksheet.Cells[ds.Tables[0].Rows.Count + 1, 2]);    
            // rg.NumberFormat = "00000000";    
            //} 
            if (saveFileName != null)
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("导出文件可能出错" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("导出Excel成功","提示",MessageBoxButtons.OK);
        }


        /// <summary> 
        /// 导出到excel
        ///  <param name="fileName">默认文件名</param> 
        ///  <param name="listView">数据源，一个页面上的ListView控件</param> 
        ///  <param name="titleRowCount">标题占据的行数，为0表示无标题</param> 
        public static void ExportExcel(string filename, System.Windows.Forms.ListView listView, int titleRowCount)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            //saveDialog.FileName = filename;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return;//点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
            //写Title    
            if (titleRowCount != 0)
                MergeCells(worksheet, 1, 1, titleRowCount, listView.Columns.Count, listView.Tag.ToString());
            //写入列标题    
            for (int i = 0; i <= listView.Columns.Count - 1; i++)
            {
                worksheet.Cells[titleRowCount + 1, i + 1] = listView.Columns[i].Text;
            }
            //写入数值    
            for (int r = 0; r <= listView.Items.Count - 1; r++)
            {
                for (int i = 0; i <= listView.Columns.Count - 1; i++)
                {
                    worksheet.Cells[r + titleRowCount + 2, i + 1] = listView.Items[r].SubItems[i].Text;
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应 
            if (saveFileName != null)
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("导出文件可能出错" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show(filename + "导出Excel成功", "提示", MessageBoxButtons.OK);
        }

        /// <summary>    
        /// 合并单元格，并赋值，对指定WorkSheet操作    
        /// </summary>    
        /// <param name="sheetIndex">WorkSheet索引</param>    
        /// <param name="beginRowIndex">开始行索引</param>    
        /// <param name="beginColumnIndex">开始列索引</param>    
        /// <param name="endRowIndex">结束行索引</param>    
        /// <param name="endColumnIndex">结束列索引</param>    
        /// <param name="text">合并后Range的值</param>  
        public static void MergeCells(Microsoft.Office.Interop.Excel.Worksheet workSheet, int beginRowIndex, int beginColumnIndex, 
                                                                                          int endRowIndex, int endColumnIndex, string text) 
        {
            Microsoft.Office.Interop.Excel.Range range = workSheet.get_Range(workSheet.Cells[beginRowIndex, beginColumnIndex], workSheet.Cells[endRowIndex, endColumnIndex]); 
            range.ClearContents(); //先把Range内容清除，合并才不会出错  
            range.MergeCells = true;
            range.Value2 = text;
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter; 
            
        }

        public static void HVCenterAlign(Microsoft.Office.Interop.Excel.Worksheet workSheet, int beginRowIndex, int beginColumnIndex,
                                                                                          int endRowIndex, int endColumnIndex) 
        {
            Microsoft.Office.Interop.Excel.Range range = workSheet.get_Range(workSheet.Cells[beginRowIndex, beginColumnIndex], workSheet.Cells[endRowIndex, endColumnIndex]);
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter; 
        }
    }
}
