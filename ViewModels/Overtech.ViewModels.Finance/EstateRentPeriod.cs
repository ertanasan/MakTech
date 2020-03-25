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
    [OTDisplayName("Estate Rent Period")]
    [DataContract]
    public class EstateRentPeriod : ViewModelObject
    {
        private long _estateRentPeriodId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _estateRent;
        private int _periodOrder;
        private DateTime _periodStartDate;
        private DateTime _periodEndDate;
        private Nullable<decimal> _contractRentAmount;
        private string _contractRentCurrency;
        private Nullable<decimal> _additionalRentAmount;
        private string _additionalRentCurrency;
        private string _plannedRentRaise;
        private Nullable<DateTime> _negotiationDate;
        private string _comment;

        /*Section="Field-EstateRentPeriodId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Estate Rent Period Id", null)]
        [OTDisplayName("Estate Rent Period Id")]
        [DataMember]
        public long EstateRentPeriodId
        {
            get
            {
                return _estateRentPeriodId;
            }
            set
            {
                _estateRentPeriodId = value;
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

        /*Section="Field-PeriodOrder"*/
        [OTRequired("Period Order", null)]
        [OTDisplayName("Period Order")]
        [DataMember]
        public int PeriodOrder
        {
            get
            {
                return _periodOrder;
            }
            set
            {
                _periodOrder = value;
            }
        }

        /*Section="Field-PeriodStartDate"*/
        [OTRequired("Period Start Date", null)]
        [OTDisplayName("Period Start Date")]
        [DataMember]
        public DateTime PeriodStartDate
        {
            get
            {
                return _periodStartDate;
            }
            set
            {
                _periodStartDate = value;
            }
        }

        /*Section="Field-PeriodEndDate"*/
        [OTRequired("Period End Date", null)]
        [OTDisplayName("Period End Date")]
        [DataMember]
        public DateTime PeriodEndDate
        {
            get
            {
                return _periodEndDate;
            }
            set
            {
                _periodEndDate = value;
            }
        }

        /*Section="Field-ContractRentAmount"*/
        [OTDisplayName("Contract Rent Amount")]
        [DataMember]
        public Nullable<decimal> ContractRentAmount
        {
            get
            {
                return _contractRentAmount;
            }
            set
            {
                _contractRentAmount = value;
            }
        }

        /*Section="Field-ContractRentCurrency"*/
        [OTDisplayName("Contract Rent Currency")]
        [DataMember]
        public string ContractRentCurrency
        {
            get
            {
                return _contractRentCurrency;
            }
            set
            {
                _contractRentCurrency = value;
            }
        }

        /*Section="Field-AdditionalRentAmount"*/
        [OTDisplayName("Additional Rent Amount")]
        [DataMember]
        public Nullable<decimal> AdditionalRentAmount
        {
            get
            {
                return _additionalRentAmount;
            }
            set
            {
                _additionalRentAmount = value;
            }
        }

        /*Section="Field-AdditionalRentCurrency"*/
        [OTDisplayName("Additional Rent Currency")]
        [DataMember]
        public string AdditionalRentCurrency
        {
            get
            {
                return _additionalRentCurrency;
            }
            set
            {
                _additionalRentCurrency = value;
            }
        }

        /*Section="Field-PlannedRentRaise"*/
        [OTDisplayName("Planned Rent Raise")]
        [DataMember]
        public string PlannedRentRaise
        {
            get
            {
                return _plannedRentRaise;
            }
            set
            {
                _plannedRentRaise = value;
            }
        }

        /*Section="Field-NegotiationDate"*/
        [OTDisplayName("Negotiation Date")]
        [DataMember]
        public Nullable<DateTime> NegotiationDate
        {
            get
            {
                return _negotiationDate;
            }
            set
            {
                _negotiationDate = value;
            }
        }

        /*Section="Field-Comment"*/
        [OTStringLength(1000)]
        [OTDisplayName("Comment")]
        [DataMember]
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _estateRentPeriodId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}