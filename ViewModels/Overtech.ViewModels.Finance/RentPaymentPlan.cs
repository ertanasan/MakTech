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
    [OTDisplayName("Rent Payment Plan")]
    [DataContract]
    public class RentPaymentPlan : ViewModelObject
    {
        private long _rentPaymentPlanId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _rentPeriod;
        private int _paymentOrder;
        private DateTime _dueDate;
        private decimal _paymentAmount;
        private string _currency;
        private Nullable<decimal> _additionalPaymentAmount;
        private string _additionalPaymentCurrency;
        private string _comment;

        /*Section="Field-RentPaymentPlanId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Rent Payment Plan Id", null)]
        [OTDisplayName("Rent Payment Plan Id")]
        [DataMember]
        public long RentPaymentPlanId
        {
            get
            {
                return _rentPaymentPlanId;
            }
            set
            {
                _rentPaymentPlanId = value;
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

        /*Section="Field-RentPeriod"*/
        [UIHint("EstateRentPeriodList")]
        [OTRequired("Rent Period", null)]
        [OTDisplayName("Rent Period")]
        [DataMember]
        public long RentPeriod
        {
            get
            {
                return _rentPeriod;
            }
            set
            {
                _rentPeriod = value;
            }
        }

        /*Section="Field-PaymentOrder"*/
        [OTRequired("Payment Order", null)]
        [OTDisplayName("Payment Order")]
        [DataMember]
        public int PaymentOrder
        {
            get
            {
                return _paymentOrder;
            }
            set
            {
                _paymentOrder = value;
            }
        }

        /*Section="Field-DueDate"*/
        [OTRequired("Due Date", null)]
        [OTDisplayName("Due Date")]
        [DataMember]
        public DateTime DueDate
        {
            get
            {
                return _dueDate;
            }
            set
            {
                _dueDate = value;
            }
        }

        /*Section="Field-PaymentAmount"*/
        [OTRequired("Payment Amount", null)]
        [OTDisplayName("Payment Amount")]
        [DataMember]
        public decimal PaymentAmount
        {
            get
            {
                return _paymentAmount;
            }
            set
            {
                _paymentAmount = value;
            }
        }

        /*Section="Field-Currency"*/
        [OTRequired("Currency", null)]
        [OTDisplayName("Currency")]
        [DataMember]
        public string Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                _currency = value;
            }
        }

        /*Section="Field-AdditionalPaymentAmount"*/
        [OTDisplayName("Additional Payment Amount")]
        [DataMember]
        public Nullable<decimal> AdditionalPaymentAmount
        {
            get
            {
                return _additionalPaymentAmount;
            }
            set
            {
                _additionalPaymentAmount = value;
            }
        }

        /*Section="Field-AdditionalPaymentCurrency"*/
        [OTDisplayName("Additional Payment Currency")]
        [DataMember]
        public string AdditionalPaymentCurrency
        {
            get
            {
                return _additionalPaymentCurrency;
            }
            set
            {
                _additionalPaymentCurrency = value;
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
            return _rentPaymentPlanId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}