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
namespace Overtech.DataModels.Store
{
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "EMPLOYEE", HasAutoIdentity = false, DisplayName = "Employee", IdField = "EmployeeId")]
    [DataContract]
    public class Employee : DataModelObject
    {
        private long _employeeId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private string _employeeName;
        private Nullable<int> _departmentCode;
        private string _departmentName;
        private Nullable<int> _incentiveActCode;
        private Nullable<DateTime> _startDate;
        private Nullable<DateTime> _quitDate;
        private string _workingType;

        /*Section="Field-EmployeeId"*/
        [OTDataField("EMPLOYEEID")]
        [DataMember]
        public long EmployeeId
        {
            get
            {
                return _employeeId;
            }
            set
            {
                _employeeId = value;
            }
        }

        /*Section="Field-Organization"*/
        [OTDataField("ORGANIZATION")]
        [ReadOnly(true)]
        [DataMember]
        public long Organization
        {
            get
            {
                return _organization;
            }
            set
            {
                _organization = value;
            }
        }

        /*Section="Field-Deleted"*/
        [OTDataField("DELETED_FL")]
        [ReadOnly(true)]
        [DataMember]
        public bool Deleted
        {
            get
            {
                return _deleted;
            }
            set
            {
                _deleted = value;
            }
        }

        /*Section="Field-CreateDate"*/
        [OTDataField("CREATE_DT")]
        [ReadOnly(true)]
        [DataMember]
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
            }
        }

        /*Section="Field-UpdateDate"*/
        [OTDataField("UPDATE_DT", Nullable = true)]
        [ReadOnly(true)]
        [DataMember]
        public Nullable<DateTime> UpdateDate
        {
            get
            {
                return _updateDate;
            }
            set
            {
                _updateDate = value;
            }
        }

        /*Section="Field-CreateUser"*/
        [OTDataField("CREATEUSER")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateUser
        {
            get
            {
                return _createUser;
            }
            set
            {
                _createUser = value;
            }
        }

        /*Section="Field-UpdateUser"*/
        [OTDataField("UPDATEUSER", Nullable = true)]
        [ReadOnly(true)]
        [DataMember]
        public Nullable<long> UpdateUser
        {
            get
            {
                return _updateUser;
            }
            set
            {
                _updateUser = value;
            }
        }

        /*Section="Field-EmployeeName"*/
        [OTDataField("EMPLOYEE_NM")]
        [DataMember]
        public string EmployeeName
        {
            get
            {
                return _employeeName;
            }
            set
            {
                _employeeName = value;
            }
        }

        /*Section="Field-DepartmentCode"*/
        [OTDataField("DEPARTMENT_CD", Nullable = true)]
        [DataMember]
        public Nullable<int> DepartmentCode
        {
            get
            {
                return _departmentCode;
            }
            set
            {
                _departmentCode = value;
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

        /*Section="Field-IncentiveActCode"*/
        [OTDataField("INCENTIVEACT_CD", Nullable = true)]
        [DataMember]
        public Nullable<int> IncentiveActCode
        {
            get
            {
                return _incentiveActCode;
            }
            set
            {
                _incentiveActCode = value;
            }
        }

        /*Section="Field-StartDate"*/
        [OTDataField("START_DT", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }

        /*Section="Field-QuitDate"*/
        [OTDataField("QUIT_DT", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> QuitDate
        {
            get
            {
                return _quitDate;
            }
            set
            {
                _quitDate = value;
            }
        }

        /*Section="Field-WorkingType"*/
        [OTDataField("WORKINGTYPE_DSC")]
        [DataMember]
        public string WorkingType
        {
            get
            {
                return _workingType;
            }
            set
            {
                _workingType = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _employeeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

