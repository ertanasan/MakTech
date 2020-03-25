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
namespace Overtech.ViewModels.Store
{
    [OTDisplayName("Employee")]
    [DataContract]
    public class Employee : ViewModelObject
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
        [OTRequired("Employee Id", null)]
        [OTDisplayName("Employee Id")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Organization")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Deleted")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Date")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Update Date")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Create User")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Update User")]
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
        [OTRequired("Employee Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Employee Name")]
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
        [OTDisplayName("Department Code")]
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

        /*Section="Field-IncentiveActCode"*/
        [OTDisplayName("Incentive Act Code")]
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
        [OTDisplayName("Start Date")]
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
        [OTDisplayName("Quit Date")]
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
        [OTStringLength(100)]
        [OTDisplayName("Working Type")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _employeeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}