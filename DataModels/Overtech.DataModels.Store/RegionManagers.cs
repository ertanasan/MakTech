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
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "REGIONMANAGERS", HasAutoIdentity = true, DisplayName = "Region Managers", IdField = "RegionManagersId")]
    [DataContract]
    public class RegionManagers : DataModelObject
    {
        private long _regionManagersId;
        private string _regionManagerName;
        private string _telNo;
        private string _email;
        private Nullable<long> _regionUser;
        private string _expenseAccountCode;
        private string _mikroProjectCode;

        /*Section="Field-RegionManagersId"*/
        [OTDataField("REGIONMANAGERSID")]
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
        [OTDataField("MANAGER_NM")]
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
        [OTDataField("TELNO_TXT")]
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
        [OTDataField("EMAIL_TXT")]
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
        [OTDataField("USERID", Nullable = true)]
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
        [OTDataField("EXPENSEACCCODE_TXT")]
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
        [OTDataField("MIKROPROJECTCODE_TXT")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _regionManagersId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized


        [OTDataField("USERACTIVE_FL", IsExtended = true)]
        [DataMember]
        public Boolean UserActive { get; set; }

        [OTDataField("REGION_NM", IsExtended = true)]
        [DataMember]
        public string RegionName { get; set; }
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

