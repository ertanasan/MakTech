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
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "CASHIER", HasAutoIdentity = false, DisplayName = "Cashier", IdField = "CashierId")]
    [DataContract]
    public class Cashier : DataModelObject
    {
        private long _cashierId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _store;
        private string _cashierName;
        private long _cashierTemplateNumber;
        private long _cashierTitleNumber;
        private int _password;
        private bool _cashierFlag;
        private bool _isActive;
        private bool _salesman;
        private Nullable<int> _workingType;
        private string _note;

        /*Section="Field-CashierId"*/
        [OTDataField("CASHIERID")]
        [DataMember]
        public long CashierId
        {
            get
            {
                return _cashierId;
            }
            set
            {
                _cashierId = value;
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

        /*Section="Field-Store"*/
        [OTDataField("STORE")]
        [DataMember]
        public long Store
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

        /*Section="Field-CashierName"*/
        [OTDataField("CASHIER_NM")]
        [DataMember]
        public string CashierName
        {
            get
            {
                return _cashierName;
            }
            set
            {
                _cashierName = value;
            }
        }

        /*Section="Field-CashierTemplateNumber"*/
        [OTDataField("CASHIERTEMPLATE")]
        [DataMember]
        public long CashierTemplateNumber
        {
            get
            {
                return _cashierTemplateNumber;
            }
            set
            {
                _cashierTemplateNumber = value;
            }
        }

        /*Section="Field-CashierTitleNumber"*/
        [OTDataField("CASHIERTITLE")]
        [DataMember]
        public long CashierTitleNumber
        {
            get
            {
                return _cashierTitleNumber;
            }
            set
            {
                _cashierTitleNumber = value;
            }
        }

        /*Section="Field-Password"*/
        [OTDataField("PASSWORD_NO")]
        [DataMember]
        public int Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        /*Section="Field-CashierFlag"*/
        [OTDataField("ISCASHIER_FL")]
        [DataMember]
        public bool CashierFlag
        {
            get
            {
                return _cashierFlag;
            }
            set
            {
                _cashierFlag = value;
            }
        }

        /*Section="Field-IsActive"*/
        [OTDataField("ISACTIVE_FL")]
        [DataMember]
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }

        /*Section="Field-Salesman"*/
        [OTDataField("ISSALESMAN_FL")]
        [DataMember]
        public bool Salesman
        {
            get
            {
                return _salesman;
            }
            set
            {
                _salesman = value;
            }
        }

        /*Section="Field-WorkingType"*/
        [OTDataField("WORKINGTYPE_CD", Nullable = true)]
        [DataMember]
        public Nullable<int> WorkingType
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

        /*Section="Field-Note"*/
        [OTDataField("NOTE_TXT")]
        [DataMember]
        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _cashierId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

