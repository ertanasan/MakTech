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
namespace Overtech.ViewModels.Reconciliation
{
    [OTDisplayName("Expense Type")]
    [DataContract]
    public class ExpenseType : ViewModelObject
    {
        private long _expenseTypeId;
        private string _expenseTypeName;
        private string _accountCode;

        /*Section="Field-ExpenseTypeId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Expense Type Id", null)]
        [OTDisplayName("Expense Type Id")]
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
        [OTRequired("Expense Type Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Expense Type Name")]
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
        [OTDisplayName("Account Code")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _expenseTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}