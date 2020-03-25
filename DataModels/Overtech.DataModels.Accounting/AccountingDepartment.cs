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
    [OTDataObject(Module = "Accounting", ModuleShortName = "ACC", Table = "DEPARTMENT", HasAutoIdentity = true, DisplayName = "Accounting Department", IdField = "AccountingDepartmentId")]
    [DataContract]
    public class AccountingDepartment : DataModelObject
    {
        private long _accountingDepartmentId;
        private string _departmentName;
        private Nullable<long> _store;
        private string _expenseCenter;

        /*Section="Field-AccountingDepartmentId"*/
        [OTDataField("DEPARTMENTID")]
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
        [OTDataField("DEPARTMENT_NM")]
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
        [OTDataField("STORE", Nullable = true)]
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
        [OTDataField("EXPENSECENTER_TXT")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _accountingDepartmentId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

