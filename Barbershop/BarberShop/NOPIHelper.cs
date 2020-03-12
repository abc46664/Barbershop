using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.XSSF.UserModel;


namespace BarberShop
{
    class NOPIHelper
    {
        IWorkbook _workBook = null;

        public IWorkbook WorkBook
        {
            get { return _workBook; }
            set { _workBook = value; }
        }
        public bool Create() 
        {
            //XSSFWorkbook tmp = new XSSFWorkbook();           
            
            _workBook = new HSSFWorkbook();
            return true;
        }
        public bool Open(String file)
        {
            if (!File.Exists(file))
                return false;
            string aLastName = file.Substring(file.LastIndexOf(".") + 1, (file.Length - file.LastIndexOf(".") - 1)); //扩展名
          
            FileStream fs = File.OpenRead(file);
            if (aLastName == "xlsx")
            {
                _workBook = new XSSFWorkbook(fs);
            }
            else
            {
                _workBook = new HSSFWorkbook(fs);
            }
            fs.Close();            
            return _workBook != null;
            //_workBook = 
        }
        public void Close()
        {
            _workBook.Close();
        }
        public ISheet CreateSheet(String sheetName)
        {
            if (null == _workBook)
                return null;
            return _workBook.CreateSheet(sheetName);
        }
        public IRow CreateRow(ISheet sheet)
        {
            return sheet.CreateRow(sheet.PhysicalNumberOfRows);
        }
        public IRow GetRow(ISheet sheet ,int index)
        {
            return sheet.GetRow(index);
        }
        public int GetRowCount(ISheet sheet)
        {
            return sheet.LastRowNum;
        }
        public ICell CreateCell(IRow row)
        {
            return row.CreateCell((row.LastCellNum < 0 )? 0 : row.LastCellNum);
        }
        public bool SetCellValue(IRow row,int cellIndex ,String val)
        {
            ICell ic = row.GetCell(cellIndex);
            if (ic == null) return false;
            ic.SetCellValue(val);
            return true;
        }
        public bool SetCellValue(ISheet sheet, int rowIndex,int cellIndex,String val)
        {
            IRow irow = sheet.GetRow(rowIndex); if (irow == null) return false;
            return (SetCellValue(irow, cellIndex, val));
        }
        public bool SetCellStyle(IRow row, int cellIndex, ICellStyle style)
        {
            ICell ic = row.GetCell(cellIndex);
            if (ic == null) return false;
            ic.CellStyle = (style);
            return true;
        }
        public bool SetCellStyle(ISheet sheet, int rowIndex, int cellIndex, ICellStyle style)
        {
            IRow irow = sheet.GetRow(rowIndex); if (irow == null) return false;
            return SetCellStyle(irow, cellIndex, style);
        }
        public bool SetCellValue(ICell cell,String value)
        {
            cell.SetCellValue(value);
            return true;
        }
        public bool Save(String fileName)
        {
            if (_workBook == null)
                return false;
            //using (var fs = File.OpenWrite(fileName))
            //{
            //    _workBook.Write(fs);
            //    fs.Close();
            //}
            //上述方法在保存xlsx时出错；
            FileStream sw = File.Create(fileName);
            _workBook.Write(sw);
            sw.Close();
            return true;
        }
    }
}
