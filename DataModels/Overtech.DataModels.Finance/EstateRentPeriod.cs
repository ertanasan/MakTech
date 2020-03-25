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
    [OTDataObject(Module = "Finance", ModuleShortName = "FIN", Table = "ESTATERENTPERIOD", HasAutoIdentity = true, DisplayName = "Estate Rent Period", IdField = "EstateRentPeriodId", MasterField = "EstateRent")]
    [DataContract]
    public class EstateRentPeriod : DataModelObject
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
        [OTDataField("ESTATERENTPERIODID")]
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

        /*Section="Field-PeriodOrder"*/
        [OTDataField("PERIODORDER_NO")]
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
        [OTDataField("START_DT")]
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
        [OTDataField("END_DT")]
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
        [OTDataField("CONTRACTRENT_AMT", Nullable = true)]
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
        [OTDataField("CONTRACTRENTCURRENCY_TXT")]
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
        [OTDataField("ADDITIONALRENT_AMT", Nullable = true)]
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
        [OTDataField("ADDRENTCURRENCY_TXT")]
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
        [OTDataField("PLANNEDRENTRAISE_TXT")]
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
        [OTDataField("NEGOTIATION_DT", Nullable = true)]
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
            _estateRentPeriodId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

