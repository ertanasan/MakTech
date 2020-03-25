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
    [OTDisplayName("Accounting Department")]
    [DataContract]
    public class AccountingDepartment : ViewModelObject
    {
        private long _accountingDepartmentId;
        private string _departmentName;
        private Nullable<long> _store;
        private string _expenseCenter;

        /*Section="Field-AccountingDepartmentId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Accounting Department Id", null)]
        [OTDisplayName("Accounting Department Id")]
        [DataMember]
        public long AccountingDepartmentId
        {
            get
            {
                return _accountingDepartmentId;
            }
            set
            {
                _accountingDepartmentId = value;
            }
        }

        /*Section="Field-DepartmentName"*/
        [OTRequired("Department Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Department Name")]
        [DataMember]
        public string DepartmentName
        {
            get
            {
                return _departmentName;
            }
            set
            {
                _departmentName = value;
            }
        }

        /*Section="Field-Store"*/
        [UIHint("StoreList")]
        [OTDisplayName("Store")]
        [DataMember]
        public Nullable<long> Store
        {
            get
            {
                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /*Section="Field-ExpenseCenter"*/
        [OTDisplayName("Expense Center")]
        [DataMember]
        public string ExpenseCenter
        {
            get
            {
                return _expenseCenter;
            }
            set
            {
                _expenseCenter = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _accountingDepartmentId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}