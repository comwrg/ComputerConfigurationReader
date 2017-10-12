using System;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;

namespace Server
{
    public class ToExcel
    {
        public static void ListView2Excel(ListView lv, string savePath)
        {
            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("Sheet1");
                int column = 1;
                int row = 1;
                foreach (ColumnHeader header in lv.Columns)
                {
                    ws.Cells[row, column].Value = header.Text;
                    column++;
                }
                foreach (ListViewItem item in lv.Items)
                {
                    column = 1;
                    row++;
                    foreach (ListViewItem.ListViewSubItem itemSubItem in item.SubItems)
                    {
                        ws.Cells[row, column].Value = itemSubItem.Text;
                        column++;
                    }
                }
                p.SaveAs(new FileInfo(savePath));
            }
        }
    }
}