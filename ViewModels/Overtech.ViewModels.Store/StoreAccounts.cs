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
    [OTDisplayName("Store Accounts")]
    [DataContract]
    public class StoreAccounts : ViewModelObject
    {
        private long _storeAccountsId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _store;
        private long _accountType;
        private long _bank;
        private string _accountText;
        private string _accountDescription;

        /*Section="Field-StoreAccountsId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Store Accounts Id", null)]
        [OTDisplayName("Store Accounts Id")]
        [DataMember]
        public long StoreAccountsId
        {
            get
            {
                return _storeAccountsId;
            }
            set
            {
                _storeAccountsId = value;
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

        /*Section="Field-Store"*/
        [UIHint("StoreList")]
        [OTRequired("Store", null)]
        [OTDisplayName("Store")]
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

        /*Section="Field-AccountType"*/
        [UIHint("StoreAccountTypeList")]
        [OTRequired("Account Type", null)]
        [OTDisplayName("Account Type")]
        [DataMember]
        public long AccountType
        {
            get
            {
                return _accountType;
            }
            set
            {
                _accountType = value;
            }
        }

        /*Section="Field-Bank"*/
        [UIHint("BankList")]
        [OTRequired("Bank", null)]
        [OTDisplayName("Bank")]
        [DataMember]
        public long Bank
        {
            get
            {
                return _bank;
            }
            set
            {
                _bank = value;
            }
        }

        /*Section="Field-AccountText"*/
        [OTRequired("Account Text", null)]
        [OTDisplayName("Account Text")]
        [DataMember]
        public string AccountText
        {
            get
            {
                return _accountText;
            }
            set
            {
                _accountText = value;
            }
        }

        /*Section="Field-AccountDescription"*/
        [OTStringLength(1000)]
        [OTDisplayName("Account Description")]
        [DataMember]
        public string AccountDescription
        {
            get
            {
                return _accountDescription;
            }
            set
            {
                _accountDescription = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storeAccountsId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}