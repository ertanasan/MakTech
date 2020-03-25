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
namespace Overtech.DataModels.Reconciliation
{
    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL", Table = "EXPENSETYPE", HasAutoIdentity = true, DisplayName = "Expense Type", IdField = "ExpenseTypeId")]
    [DataContract]
    public class ExpenseType : DataModelObject
    {
        private long _expenseTypeId;
        private string _expenseTypeName;
        private string _accountCode;

        /*Section="Field-ExpenseTypeId"*/
        [OTDataField("EXPENSETYPEID")]
        [DataMember]
        public long ExpenseTypeId
        {
            get
            {
                return _expenseTypeId;
            }
            set
            {
                _expenseTypeId = value;
            }
        }

        /*Section="Field-ExpenseTypeName"*/
        [OTDataField("EXPENSETYPE_NM")]
        [DataMember]
        public string ExpenseTypeName
        {
            get
            {
                return _expenseTypeName;
            }
            set
            {
                _expenseTypeName = value;
            }
        }

        /*Section="Field-AccountCode"*/
        [OTDataField("ACCOUNTCODE_TXT")]
        [DataMember]
        public string AccountCode
        {
            get
            {
                return _accountCode;
            }
            set
            {
                _accountCode = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _expenseTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

