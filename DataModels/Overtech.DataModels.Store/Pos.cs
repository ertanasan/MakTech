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
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "POS", HasAutoIdentity = true, DisplayName = "Pos", IdField = "PosId")]
    [DataContract]
    public class Pos : DataModelObject
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
        [OTDataField("POSID")]
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

        /*Section="Field-PosCode"*/
        [OTDataField("POSCODE_TXT")]
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
        [OTDataField("BANK", Nullable = true)]
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
        [OTDataField("CASHREGISTERCODE_TXT")]
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
        [OTDataField("BANKCODE_TXT")]
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
        [OTDataField("DESCRIPTION_TXT")]
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
        [OTDataField("MOBIL_FL")]
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
        [OTDataField("OKC_TXT")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _posId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

