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
    [OTDataObject(Module = "Finance", ModuleShortName = "FIN", Table = "RENTPAYMENTPLAN", HasAutoIdentity = true, DisplayName = "Rent Payment Plan", IdField = "RentPaymentPlanId", MasterField = "RentPeriod")]
    [DataContract]
    public class RentPaymentPlan : DataModelObject
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
        [OTDataField("RENTPAYMENTPLANID")]
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

        /*Section="Field-RentPeriod"*/
        [OTDataField("ESTATERENTPERIOD")]
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
        [OTDataField("PAYMENTORDER_NO")]
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
        [OTDataField("DUE_DT")]
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
        [OTDataField("PAYMENT_AMT")]
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
        [OTDataField("CURRENCY_TXT")]
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
        [OTDataField("ADDITIONALPAYMENT_AMT", Nullable = true)]
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
        [OTDataField("ADDPAYMENTCURRENCY_TXT")]
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
        [OTDataField("COMMENT_DSC")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _rentPaymentPlanId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

