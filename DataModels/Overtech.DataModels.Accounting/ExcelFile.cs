// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Overtech.Core.Data;

/*Section="ClassHeader"*/
namespace Overtech.DataModels.Accounting
{
    [OTDataObject(Module = "Accounting", ModuleShortName = "ACC", Table = "EXCELFILE", HasAutoIdentity = true, DisplayName = "Excel File", IdField = "ExcelFileId")]
    [DataContract]
    public class ExcelFile : DataModelObject
    {
        private long _excelFileId;
        private string _transferName;
        private int _sheetNo;
        private int _rowStartNo;
        private int _columnStartNo;
        private int _numberOfColumns;

        /*Section="Field-ExcelFileId"*/
        [OTDataField("EXCELFILEID")]
        [DataMember]
        public long ExcelFileId
        {
            get
            {
                return _excelFileId;
            }
            set
            {
                _excelFileId = value;
            }
        }

        /*Section="Field-TransferName"*/
        [OTDataField("TRANSFER_NM")]
        [DataMember]
        public string TransferName
        {
            get
            {
                return _transferName;
            }
            set
            {
                _transferName = value;
            }
        }

        /*Section="Field-SheetNo"*/
        [OTDataField("SHEET_NO")]
        [DataMember]
        public int SheetNo
        {
            get
            {
                return _sheetNo;
            }
            set
            {
                _sheetNo = value;
            }
        }

        /*Section="Field-RowStartNo"*/
        [OTDataField("ROWSTART_NO")]
        [DataMember]
        public int RowStartNo
        {
            get
            {
                return _rowStartNo;
            }
            set
            {
                _rowStartNo = value;
            }
        }

        /*Section="Field-ColumnStartNo"*/
        [OTDataField("COLUMNSTART_NO")]
        [DataMember]
        public int ColumnStartNo
        {
            get
            {
                return _columnStartNo;
            }
            set
            {
                _columnStartNo = value;
            }
        }

        /*Section="Field-NumberOfColumns"*/
        [OTDataField("NUMBEROFCOLUMNS_QTY")]
        [DataMember]
        public int NumberOfColumns
        {
            get
            {
                return _numberOfColumns;
            }
            set
            {
                _numberOfColumns = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _excelFileId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

