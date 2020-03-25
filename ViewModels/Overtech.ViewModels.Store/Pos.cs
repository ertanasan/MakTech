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
    [OTDisplayName("Pos")]
    [DataContract]
    public class Pos : ViewModelObject
    {
        private long _posId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _store;
        private string _posCode;
        private Nullable<long> _bank;
        private string _cashRegisterCode;
        private string _bankCode;
        private string _description;
        private bool _mobilFlag;
        private string _okcNumber;

        /*Section="Field-PosId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Pos Id", null)]
        [OTDisplayName("Pos Id")]
        [DataMember]
        public long PosId
        {
            get
            {
                return _posId;
            }
            set
            {
                _posId = value;
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

        /*Section="Field-PosCode"*/
        [OTRequired("Pos Code", null)]
        [OTDisplayName("Pos Code")]
        [DataMember]
        public string PosCode
        {
            get
            {
                return _posCode;
            }
            set
            {
                _posCode = value;
            }
        }

        /*Section="Field-Bank"*/
        [UIHint("BankList")]
        [OTDisplayName("Bank")]
        [DataMember]
        public Nullable<long> Bank
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

        /*Section="Field-CashRegisterCode"*/
        [OTDisplayName("Cash Register Code")]
        [DataMember]
        public string CashRegisterCode
        {
            get
            {
                return _cashRegisterCode;
            }
            set
            {
                _cashRegisterCode = value;
            }
        }

        /*Section="Field-BankCode"*/
        [OTDisplayName("Bank Code")]
        [DataMember]
        public string BankCode
        {
            get
            {
                return _bankCode;
            }
            set
            {
                _bankCode = value;
            }
        }

        /*Section="Field-Description"*/
        [OTDisplayName("Description")]
        [DataMember]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /*Section="Field-MobilFlag"*/
        [OTDisplayName("Mobil Flag")]
        [DataMember]
        public bool MobilFlag
        {
            get
            {
                return _mobilFlag;
            }
            set
            {
                _mobilFlag = value;
            }
        }

        /*Section="Field-OKCNumber"*/
        [OTDisplayName("OKC Number")]
        [DataMember]
        public string OKCNumber
        {
            get
            {
                return _okcNumber;
            }
            set
            {
                _okcNumber = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _posId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}