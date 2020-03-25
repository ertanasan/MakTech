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
using Overtech.DataModels.Document;

/*Section="ClassHeader"*/
namespace Overtech.DataModels.Finance
{
    [OTDataObject(Module = "Finance", ModuleShortName = "FIN", Table = "ESTATERENT", HasAutoIdentity = true, DisplayName = "Estate Rent", IdField = "EstateRentId")]
    [DataContract]
    public class EstateRent : DataModelObject
    {
        private long _estateRentId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private Nullable<long> _contractDraftVersion;
        private Nullable<long> _contractFolder;
        private string _estateAddress;
        private string _rentPurpose;
        private DateTime _contractStartDate;
        private DateTime _contractEndDate;
        private string _estateName;
        private string _comment;
        private Nullable<long> _branch;
        private Nullable<decimal> _deposit;
        private string _depositCurrency;
        private string _depositDetails;
        private Nullable<decimal> _additionalDeposit;
        private string _additionalDepositCurrency;
        private Nullable<decimal> _agentFee;
        private string _agentFeeCurrency;
        private string _agentFeeDetail;
        private Nullable<decimal> _keyMoney;
        private string _keyMoneyCurrency;
        private string _keyMoneyDetail;
        private Nullable<decimal> _nonrefundableCost;
        private string _nonrefundableCurrency;
        private string _nonrefundableCostDetail;

        private IEnumerable<Overtech.DataModels.Document.Document> _documentList = new List<Overtech.DataModels.Document.Document>();

        /*Section="Field-EstateRentId"*/
        [OTDataField("ESTATERENTID")]
        [DataMember]
        public long EstateRentId
        {
            get
            {
                return _estateRentId;
            }
            set
            {
                _estateRentId = value;
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

        /*Section="Field-ContractDraftVersion"*/
        [OTDataField("CONTRACTDRAFTVERSION", Nullable = true)]
        [DataMember]
        public Nullable<long> ContractDraftVersion
        {
            get
            {
                return _contractDraftVersion;
            }
            set
            {
                _contractDraftVersion = value;
            }
        }

        /*Section="Field-ContractFolder"*/
        [OTDataField("CONTRACTFOLDER", Nullable = true)]
        [DataMember]
        public Nullable<long> ContractFolder
        {
            get
            {
                return _contractFolder;
            }
            set
            {
                _contractFolder = value;
            }
        }

        /*Section="Field-EstateAddress"*/
        [OTDataField("ESTATE_ADR")]
        [DataMember]
        public string EstateAddress
        {
            get
            {
                return _estateAddress;
            }
            set
            {
                _estateAddress = value;
            }
        }

        /*Section="Field-RentPurpose"*/
        [OTDataField("RENTPURPOSE_TXT")]
        [DataMember]
        public string RentPurpose
        {
            get
            {
                return _rentPurpose;
            }
            set
            {
                _rentPurpose = value;
            }
        }

        /*Section="Field-ContractStartDate"*/
        [OTDataField("START_DT")]
        [DataMember]
        public DateTime ContractStartDate
        {
            get
            {
                return _contractStartDate;
            }
            set
            {
                _contractStartDate = value;
            }
        }

        /*Section="Field-ContractEndDate"*/
        [OTDataField("END_DT")]
        [DataMember]
        public DateTime ContractEndDate
        {
            get
            {
                return _contractEndDate;
            }
            set
            {
                _contractEndDate = value;
            }
        }

        /*Section="Field-EstateName"*/
        [OTDataField("ESTATE_NM")]
        [DataMember]
        public string EstateName
        {
            get
            {
                return _estateName;
            }
            set
            {
                _estateName = value;
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

        /*Section="Field-Branch"*/
        [OTDataField("BRANCH", Nullable = true)]
        [DataMember]
        public Nullable<long> Branch
        {
            get
            {
                return _branch;
            }
            set
            {
                _branch = value;
            }
        }

        /*Section="Field-Deposit"*/
        [OTDataField("DEPOSIT_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> Deposit
        {
            get
            {
                return _deposit;
            }
            set
            {
                _deposit = value;
            }
        }

        /*Section="Field-DepositCurrency"*/
        [OTDataField("DEPOSITCURRENCY_TXT")]
        [DataMember]
        public string DepositCurrency
        {
            get
            {
                return _depositCurrency;
            }
            set
            {
                _depositCurrency = value;
            }
        }

        /*Section="Field-DepositDetails"*/
        [OTDataField("DEPOSITDETAIL_TXT")]
        [DataMember]
        public string DepositDetails
        {
            get
            {
                return _depositDetails;
            }
            set
            {
                _depositDetails = value;
            }
        }

        /*Section="Field-AdditionalDeposit"*/
        [OTDataField("ADDDEPOSIT_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> AdditionalDeposit
        {
            get
            {
                return _additionalDeposit;
            }
            set
            {
                _additionalDeposit = value;
            }
        }

        /*Section="Field-AdditionalDepositCurrency"*/
        [OTDataField("ADDDEPOSITCURRENCY_TXT")]
        [DataMember]
        public string AdditionalDepositCurrency
        {
            get
            {
                return _additionalDepositCurrency;
            }
            set
            {
                _additionalDepositCurrency = value;
            }
        }

        /*Section="Field-AgentFee"*/
        [OTDataField("AGENTFEE_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> AgentFee
        {
            get
            {
                return _agentFee;
            }
            set
            {
                _agentFee = value;
            }
        }

        /*Section="Field-AgentFeeCurrency"*/
        [OTDataField("AGENTFEECURRENCY_TXT")]
        [DataMember]
        public string AgentFeeCurrency
        {
            get
            {
                return _agentFeeCurrency;
            }
            set
            {
                _agentFeeCurrency = value;
            }
        }

        /*Section="Field-AgentFeeDetail"*/
        [OTDataField("AGENTFEEDETAIL_TXT")]
        [DataMember]
        public string AgentFeeDetail
        {
            get
            {
                return _agentFeeDetail;
            }
            set
            {
                _agentFeeDetail = value;
            }
        }

        /*Section="Field-KeyMoney"*/
        [OTDataField("KEYMONEY_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> KeyMoney
        {
            get
            {
                return _keyMoney;
            }
            set
            {
                _keyMoney = value;
            }
        }

        /*Section="Field-KeyMoneyCurrency"*/
        [OTDataField("KEYMONEYCURRENCY_TXT")]
        [DataMember]
        public string KeyMoneyCurrency
        {
            get
            {
                return _keyMoneyCurrency;
            }
            set
            {
                _keyMoneyCurrency = value;
            }
        }

        /*Section="Field-KeyMoneyDetail"*/
        [OTDataField("KEYMONEYDETAIL_TXT")]
        [DataMember]
        public string KeyMoneyDetail
        {
            get
            {
                return _keyMoneyDetail;
            }
            set
            {
                _keyMoneyDetail = value;
            }
        }

        /*Section="Field-NonrefundableCost"*/
        [OTDataField("NONREFUNDABLECOST_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> NonrefundableCost
        {
            get
            {
                return _nonrefundableCost;
            }
            set
            {
                _nonrefundableCost = value;
            }
        }

        /*Section="Field-NonrefundableCurrency"*/
        [OTDataField("NONREFUNDABLECOSTCURRENCY_TXT")]
        [DataMember]
        public string NonrefundableCurrency
        {
            get
            {
                return _nonrefundableCurrency;
            }
            set
            {
                _nonrefundableCurrency = value;
            }
        }

        /*Section="Field-NonrefundableCostDetail"*/
        [OTDataField("NONREFUNDABLECOSTDETAIL_TXT")]
        [DataMember]
        public string NonrefundableCostDetail
        {
            get
            {
                return _nonrefundableCostDetail;
            }
            set
            {
                _nonrefundableCostDetail = value;
            }
        }

        /*Section="Field-DocumentList"*/
        [ReadOnly(true)]
        [DataMember]
        public IEnumerable<DataModels.Document.Document> DocumentList
        {
            get
            {
                return _documentList;
            }
            set
            {
                _documentList = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _estateRentId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

