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
    [OTDataObject(Module = "Accounting", ModuleShortName = "ACC", Table = "EXCELFILECOLUMNS", HasAutoIdentity = true, DisplayName = "Excel File Columns", IdField = "ExcelFileColumnsId", MasterField = "ExcelFile")]
    [DataContract]
    public class ExcelFileColumns : DataModelObject
    {
        private long _excelFileColumnsId;
        private long _excelFile;
        private string _columnName;
        private int _columnIndex;
        private int _columnType;
        private string _columnFormat;

        /*Section="Field-ExcelFileColumnsId"*/
        [OTDataField("EXCELFILECOLUMNSID")]
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
        [OTDataField("EXCELFILE")]
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
        [OTDataField("COLUMN_NM")]
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
        [OTDataField("COLUMNINDEX_NO")]
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
        [OTDataField("COLUMNTYPE_CD")]
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
        [OTDataField("FORMAT_TXT")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _excelFileColumnsId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

