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
namespace Overtech.DataModels.Finance
{
    [OTDataObject(Module = "Finance", ModuleShortName = "FIN", Table = "ESTATELANDLORD", HasAutoIdentity = false, DisplayName = "Estate Landlord", LeftIdField = "EstateRent", RightIdField = "Landlord")]
    [DataContract]
    public class EstateLandlord : DataModelObject
    {
        private long _estateRent;
        private long _landlord;
        private DateTime _createDate;
        private long _createUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private Nullable<decimal> _ownershipRate;
        private Nullable<decimal> _paymentRate;
        private string _iban;
        private long _estateRentEstateRentId;
        private string _landlordLandlordName;

        /*Section="Field-EstateRent"*/
        [OTDataField("ESTATERENT")]
        [DataMember]
        public long EstateRent
        {
            get
            {
                return _estateRent;
            }
            set
            {
                _estateRent = value;
            }
        }

        /*Section="Field-Landlord"*/
        [OTDataField("LANDLORD")]
        [DataMember]
        public long Landlord
        {
            get
            {
                return _landlord;
            }
            set
            {
                _landlord = value;
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

        /*Section="Field-CreateChannel"*/
        [OTDataField("CREATECHANNEL")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateChannel
        {
            get
            {
                return _createChannel;
            }
            set
            {
                _createChannel = value;
            }
        }

        /*Section="Field-CreateBranch"*/
        [OTDataField("CREATEBRANCH")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateBranch
        {
            get
            {
                return _createBranch;
            }
            set
            {
                _createBranch = value;
            }
        }

        /*Section="Field-CreateScreen"*/
        [OTDataField("CREATESCREEN")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateScreen
        {
            get
            {
                return _createScreen;
            }
            set
            {
                _createScreen = value;
            }
        }

        /*Section="Field-OwnershipRate"*/
        [OTDataField("OWNERSHIP_RT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> OwnershipRate
        {
            get
            {
                return _ownershipRate;
            }
            set
            {
                _ownershipRate = value;
            }
        }

        /*Section="Field-PaymentRate"*/
        [OTDataField("PAYMENT_RT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> PaymentRate
        {
            get
            {
                return _paymentRate;
            }
            set
            {
                _paymentRate = value;
            }
        }

        /*Section="Field-IBAN"*/
        [OTDataField("IBAN_TXT")]
        [DataMember]
        public string IBAN
        {
            get
            {
                return _iban;
            }
            set
            {
                _iban = value;
            }
        }

        #region Parent Name Fields
        /*Section="Field-LeftParentName"*/
        [OTDataField("ESTATERENT.ESTATERENTID")]
        [ReadOnly(true)]
        [DataMember]
        public long EstateRentEstateRentId
        {
            get
            {
                return _estateRentEstateRentId;
            }
            set
            {
                _estateRentEstateRentId = value;
            }
        }

        /*Section="Field-RightParentName"*/
        [OTDataField("LANDLORD.LANDLOARD_NM")]
        [ReadOnly(true)]
        [DataMember]
        public string LandlordLandlordName
        {
            get
            {
                return _landlordLandlordName;
            }
            set
            {
                _landlordLandlordName = value;
            }
        }
        #endregion Parent Name Fields

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

