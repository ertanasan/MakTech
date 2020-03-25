// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Overtech.Core.Data;
using Overtech.UI.Data.Annotations;

/*Section="ClassHeader"*/
namespace Overtech.ViewModels.Accounting
{
    [OTDisplayName("Excel File")]
    [DataContract]
    public class ExcelFile : ViewModelObject
    {
        private long _excelFileId;
        private string _transferName;
        private int _sheetNo;
        private int _rowStartNo;
        private int _columnStartNo;
        private int _numberOfColumns;

        /*Section="Field-ExcelFileId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Excel File Id", null)]
        [OTDisplayName("Excel File Id")]
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
        [OTRequired("Transfer Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Transfer Name")]
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
        [OTRequired("Sheet No", null)]
        [OTDisplayName("Sheet No")]
        [DefaultValue(1)]
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
        [OTRequired("Row Start No", null)]
        [OTDisplayName("Row Start No")]
        [DefaultValue(2)]
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
        [OTRequired("Column Start No", null)]
        [OTDisplayName("Column Start No")]
        [DefaultValue(1)]
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
        [OTRequired("Number Of Columns", null)]
        [OTDisplayName("Number Of Columns")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _excelFileId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}