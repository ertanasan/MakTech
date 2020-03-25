using Microsoft.VisualBasic.FileIO;
using OfficeOpenXml;
using Overtech.DataModels.Accounting;
using Overtech.Service.Data.Uni;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Overtech.Mutual.Accounting
{
    public class ExcelOperations
    {
        private IDAL _dal;
        public DataTable ExcelTable;

        public ExcelOperations(IDAL dal)
        {
            _dal = dal;
        }

        private decimal convertStringtoDecimal (string s, string format)
        {
            CultureInfo cultures = new CultureInfo("en-US");
            try
            {
                string numbersOnly = Regex.Replace(s, @"[^\d.,-]", String.Empty);
                if (format != "#.#")
                {
                    numbersOnly = numbersOnly.Replace(".", "");
                    numbersOnly = numbersOnly.Replace(",", ".");
                }
                if (numbersOnly.Trim().Length > 0)
                {
                    return Convert.ToDecimal(numbersOnly, cultures);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Değer : {s}, Exception : {ex.Message}");
            }
        }

        private DateTime convertStringtoDateTime (string s, string format)
        {
            CultureInfo provider = CultureInfo.GetCultureInfo("en-US");
            try
            {
                return DateTime.ParseExact(s, format, provider);
            }
            catch (Exception ex)
            {
                throw new Exception($"Değer : {s}, Exception : {ex.Message}");
            }
        }

        private string readXlsx(Stream stream, ExcelFile ef)
        {
            string valueErrors = "";
            IEnumerable<ExcelFileColumns> efl = _dal.List<ExcelFileColumns>(ef.ExcelFileId).ToList();

            using (var excel = new ExcelPackage(stream))
            {
                // istenilen sheet yoksa hata dönüşü yap.
                ExcelWorksheet ws;
                if (excel.Workbook.Worksheets.Count >= ef.SheetNo)
                {
                    ws = excel.Workbook.Worksheets[ef.SheetNo];
                }
                else
                {
                    return "Excel dosya tanımındaki sayfa numarası bulunamadı.";
                }

                // kolon sayısı tutmuyorsa hata dönüşü yap.
                if (ws.Dimension == null || (ws.Dimension.End.Column - ef.ColumnStartNo + 1) != ef.NumberOfColumns)
                {
                    return "Excel dosya tanımındaki kolon sayısı gönderdiğiniz dosya ile tutmuyor.";
                }

                foreach (ExcelFileColumns ec in efl)
                {
                    switch (ec.ColumnType)
                    {
                        case 1: ExcelTable.Columns.Add(ec.ColumnName, Type.GetType("System.String")); break;
                        case 2: ExcelTable.Columns.Add(ec.ColumnName, Type.GetType("System.Decimal")); break;
                        case 3: ExcelTable.Columns.Add(ec.ColumnName, Type.GetType("System.DateTime")); break;
                        default: return "Excel dosya tanımında tanımsız bir veri tipi var.";
                    }

                }

                int startRow = ef.RowStartNo;

                // findendrow
                int lastRow = 0;
                bool goOn = true;
                int currentRow = startRow;
                int maxEmptyRowCount = 3;
                int emptyRowCount = 0;
                while (goOn)
                {
                    var wsRow = ws.Cells[currentRow, ef.ColumnStartNo, currentRow, ws.Dimension.End.Column];
                    bool emptyrow = true;
                    foreach (ExcelFileColumns ec in efl)
                    {
                        if (wsRow[currentRow, ec.ColumnIndex].Text.Trim().Length > 0) emptyrow = false;
                    }
                    if (emptyrow)
                    {
                        emptyRowCount++;
                        if (emptyRowCount > maxEmptyRowCount) goOn = false;
                    }
                    else
                    {
                        lastRow = currentRow;
                    }
                    currentRow++;
                }

                // add DataRows to DataTable
                for (int rowNum = startRow; rowNum <= lastRow; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, ef.ColumnStartNo, rowNum, ws.Dimension.End.Column];
                    DataRow row = ExcelTable.NewRow();
                    foreach (ExcelFileColumns ec in efl)
                    {
                        try
                        {
                            string value = wsRow[rowNum, ec.ColumnIndex].Text;
                            bool emptyvalue = (value.Length == 0);
                            if (emptyvalue)
                            {
                                row[ec.ColumnName] = DBNull.Value;
                            }
                            else
                            {
                                switch (ec.ColumnType)
                                {
                                    case 1: row[ec.ColumnName] = value; break;
                                    case 2: row[ec.ColumnName] = convertStringtoDecimal(value, ec.ColumnFormat); break;
                                    case 3: row[ec.ColumnName] = convertStringtoDateTime(value, ec.ColumnFormat); break;
                                }
                            }
                        }
                        catch
                        {
                            valueErrors += $"({ec.ColumnName}, {rowNum}) = {wsRow[rowNum, ec.ColumnIndex].Text}; ";
                            if (valueErrors.Length > 0) return $"Hatalı veri : {valueErrors}";
                        }
                    }
                    ExcelTable.Rows.Add(row);
                }
            }
            if (valueErrors.Length > 0)
            {
                return $"Hatalı veri : {valueErrors}";
            }
            else
            {
                return "";
            }
        }

        private string readCsv(Stream stream, ExcelFile ef)
        {
            using (TextFieldParser parser = new TextFieldParser(stream))
            {
                string valueErrors = "";
                IEnumerable<ExcelFileColumns> efl = _dal.List<ExcelFileColumns>(ef.ExcelFileId).ToList();
                parser.TextFieldType = FieldType.Delimited;
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                int rowCount = 1;

                foreach (ExcelFileColumns ec in efl)
                {
                    switch (ec.ColumnType)
                    {
                        case 1: ExcelTable.Columns.Add(ec.ColumnName, Type.GetType("System.String")); break;
                        case 2: ExcelTable.Columns.Add(ec.ColumnName, Type.GetType("System.Decimal")); break;
                        case 3: ExcelTable.Columns.Add(ec.ColumnName, Type.GetType("System.DateTime")); break;
                        default: return "Excel dosya tanımında tanımsız bir veri tipi var.";
                    }

                }

                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] row = parser.ReadFields();
                    if (rowCount > 1) //Skip header row
                    {

                        DataRow drow = ExcelTable.NewRow();
                        foreach (ExcelFileColumns ec in efl)
                        {
                            try
                            {
                                string value = row[ec.ColumnIndex-1];
                                bool emptyvalue = (value.Length == 0);
                                if (emptyvalue)
                                {
                                    drow[ec.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    switch (ec.ColumnType)
                                    {
                                        case 1: drow[ec.ColumnName] = value; break;
                                        case 2: drow[ec.ColumnName] = convertStringtoDecimal(value, ec.ColumnFormat); break;
                                        case 3: drow[ec.ColumnName] = convertStringtoDateTime(value, ec.ColumnFormat); break;
                                    }
                                }
                            }
                            catch
                            {
                                valueErrors += $"({ec.ColumnName}, {rowCount}) = {row[ec.ColumnIndex - 1]}; ";
                                if (valueErrors.Length > 0) return $"Hatalı veri : {valueErrors}";
                            }
                        }
                        ExcelTable.Rows.Add(drow);

                    }

                    rowCount++;
                }
            }
            return "";
        }

        public string ReadExceltoDataTable(byte[] formData, string transferName, int filetype)
        {
            IUniParameter prmTransferName = _dal.CreateParameter("TransferName", transferName);
            ExcelFile ef = _dal.Read<ExcelFile>("ACC_SEL_EXCELFILEFROMNAME_SP", prmTransferName);
            

            Stream stream = new MemoryStream(formData);
            ExcelTable = new DataTable();

            string returnMessage = "";
            switch (filetype)
            {
                case 1: returnMessage = readXlsx(stream, ef); break;
                case 2: returnMessage = readCsv(stream, ef); break;
            }

            return returnMessage;

        }

        public string GetSpesificCellContent(byte[] formData, string transferName, int rowNo, int columnNo)
        {
            string cellContent = "";
            
            IUniParameter prmTransferName = _dal.CreateParameter("TransferName", transferName);
            ExcelFile ef = _dal.Read<ExcelFile>("ACC_SEL_EXCELFILEFROMNAME_SP", prmTransferName);

            Stream stream = new MemoryStream(formData);
            using (var excel = new ExcelPackage(stream))
            {
                ExcelWorksheet ws = excel.Workbook.Worksheets[ef.SheetNo];
                cellContent = ws.Cells[rowNo, columnNo].Value.ToString();
            }

            return cellContent;
        }

    }
}
