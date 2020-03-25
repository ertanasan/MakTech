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
    [OTDisplayName("Region Managers")]
    [DataContract]
    public class RegionManagers : ViewModelObject
    {
        private long _regionManagersId;
        private string _regionManagerName;
        private string _telNo;
        private string _email;
        private Nullable<long> _regionUser;
        private string _expenseAccountCode;
        private string _mikroProjectCode;

        /*Section="Field-RegionManagersId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Region Managers Id", null)]
        [OTDisplayName("Region Managers Id")]
        [DataMember]
        public long RegionManagersId
        {
            get
            {
                return _regionManagersId;
            }
            set
            {
                _regionManagersId = value;
            }
        }

        /*Section="Field-RegionManagerName"*/
        [OTRequired("Region Manager Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Region Manager Name")]
        [DataMember]
        public string RegionManagerName
        {
            get
            {
                return _regionManagerName;
            }
            set
            {
                _regionManagerName = value;
            }
        }

        /*Section="Field-TelNo"*/
        [OTDisplayName("TelNo")]
        [DataMember]
        public string TelNo
        {
            get
            {
                return _telNo;
            }
            set
            {
                _telNo = value;
            }
        }

        /*Section="Field-Email"*/
        [OTDisplayName("Email")]
        [DataMember]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        /*Section="Field-RegionUser"*/
        [UIHint("UserList")]
        [OTDisplayName("Region User")]
        [DataMember]
        public Nullable<long> RegionUser
        {
            get
            {
                return _regionUser;
            }
            set
            {
                _regionUser = value;
            }
        }

        /*Section="Field-ExpenseAccountCode"*/
        [OTDisplayName("Expense Account Code")]
        [DataMember]
        public string ExpenseAccountCode
        {
            get
            {
                return _expenseAccountCode;
            }
            set
            {
                _expenseAccountCode = value;
            }
        }

        /*Section="Field-MikroProjectCode"*/
        [OTDisplayName("Mikro Project Code")]
        [DataMember]
        public string MikroProjectCode
        {
            get
            {
                return _mikroProjectCode;
            }
            set
            {
                _mikroProjectCode = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _regionManagersId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public Boolean UserActive { get; set; }

        [DataMember]
        public string RegionName { get; set; }
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}