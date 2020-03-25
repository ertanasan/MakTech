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
namespace Overtech.ViewModels.Finance
{
    [OTDisplayName("Estate Landlord")]
    [DataContract]
    public class EstateLandlord : RelationViewModelObject
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
        [UIHint("EstateRentList")]
        [OTRequired("Estate Rent", null)]
        [OTDisplayName("Estate Rent")]
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
        [UIHint("LandlordList")]
        [OTRequired("Landlord", null)]
        [OTDisplayName("Landlord")]
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

        /*Section="Field-CreateChannel"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Channel")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Branch")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Screen")]
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
        [OTDisplayName("Ownership Rate")]
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
        [OTDisplayName("Payment Rate")]
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
        [OTDisplayName("IBAN")]
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
        [OTDisplayName("EstateRent EstateRentId")]
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
        [OTDisplayName("Landlord LandlordName")]
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

        /*Section="Method-SetLeftId"*/
        public override void SetLeftId(long leftId)
        {
            _estateRent = leftId;
        }

        /*Section="Method-SetRightId"*/
        public override void SetRightId(long rightId)
        {
            _landlord = rightId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}