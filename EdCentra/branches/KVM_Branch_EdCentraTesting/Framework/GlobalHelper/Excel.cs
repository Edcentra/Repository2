using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    public class Excel
    {
        string path = @"C:\PerformanceData";
        Workbook wb;
        Worksheet worksheet;

        _Application excel = new _Excel.Application();
        public Excel()
        {

        }
        //public Excel(string path, int Sheet)
        //{
        //    this.path = path;
        //    wb = excel.Workbooks.Open(path);
        //    ws = wb.Worksheets[Sheet];
        //}

        public void CreateNewFile()
        {
            this.wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
           
        }

        public void WriteToCell(int i, int j, string Sheet, string s)
        {
            i++;
            j++;
            this.worksheet = wb.Worksheets[Sheet];
            worksheet.Cells[i, j].Value2 = s;
        }

        public void Save()
        {
            wb.Save();
        }

        public void SaveAs(string path)
        {
            wb.SaveAs(path);
        }
    }
}
