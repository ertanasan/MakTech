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
    [OTDisplayName("Excel File Columns")]
    [DataContract]
    public class ExcelFileColumns : ViewModelObject
    {
        private long _excelFileColumnsId;
        private long _excelFile;
        private string _columnName;
        private int _columnIndex;
        private int _columnType;
        private string _columnFormat;

        /*Section="Field-ExcelFileColumnsId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Excel File Columns Id", null)]
        [OTDisplayName("Excel File Columns Id")]
        [DataMember]
        public long ExcelFileColumnsId
        {
            get
            {
                return _excelFileColumnsId;
            }
            set
            {
                _excelFileColumnsId = value;
            }
        }

        /*Section="Field-ExcelFile"*/
        [UIHint("ExcelFileList")]
        [OTRequired("Excel File", null)]
        [OTDisplayName("Excel File")]
        [DataMember]
        public long ExcelFile
        {
            get
            {
                return _excelFile;
            }
            set
            {
                _excelFile = value;
            }
        }

        /*Section="Field-ColumnName"*/
        [OTRequired("Column Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Column Name")]
        [DataMember]
        public string ColumnName
        {
            get
            {
                return _columnName;
            }
            set
            {
                _columnName = value;
            }
        }

        /*Section="Field-ColumnIndex"*/
        [OTRequired("Column Index", null)]
        [OTDisplayName("Column Index")]
        [DataMember]
        public int ColumnIndex
        {
            get
            {
                return _columnIndex;
            }
            set
            {
                _columnIndex = value;
            }
        }

        /*Section="Field-ColumnType"*/
        [OTRequired("Column Type", null)]
        [OTDisplayName("Column Type")]
        [DefaultValue(1)]
        [DataMember]
        public int ColumnType
        {
            get
            {
                return _columnType;
            }
            set
            {
                _columnType = value;
            }
        }

        /*Section="Field-ColumnFormat"*/
        [OTDisplayName("Column Format")]
        [DataMember]
        public string ColumnFormat
        {
            get
            {
                return _columnFormat;
            }
            set
            {
                _columnFormat = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _excelFileColumnsId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}