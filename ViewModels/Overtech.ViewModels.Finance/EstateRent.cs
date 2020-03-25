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
using Overtech.ViewModels.Document;

/*Section="ClassHeader"*/
namespace Overtech.ViewModels.Finance
{
    [OTDisplayName("Estate Rent")]
    [DataContract]
    public class EstateRent : ViewModelObject
    {
        /*Section="Constructor"*/
        public EstateRent()
        {
            this.FolderReference = Guid.NewGuid().ToString();
        }

        public string FolderReference { get; set; }

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

        /*Section="Field-EstateRentId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Estate Rent Id", null)]
        [OTDisplayName("Estate Rent Id")]
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

        /*Section="Field-ContractDraftVersion"*/
        [UIHint("ContractDraftVersionList")]
        [OTDisplayName("Contract Draft Version")]
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
        [UIHint("FolderList")]
        [OTDisplayName("Contract Folder")]
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
        [OTStringLength(1000)]
        [OTDisplayName("Estate Address")]
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
        [OTDisplayName("Rent Purpose")]
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
        [OTRequired("Contract Start Date", null)]
        [OTDisplayName("Contract Start Date")]
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
        [OTRequired("Contract End Date", null)]
        [OTDisplayName("Contract End Date")]
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
        [OTStringLength(100)]
        [OTDisplayName("Estate Name")]
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

        /*Section="Field-Branch"*/
        [UIHint("BranchList")]
        [OTDisplayName("Branch")]
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
        [OTDisplayName("Deposit")]
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
        [OTDisplayName("Deposit Currency")]
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
        [OTDisplayName("Deposit Details")]
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
        [OTDisplayName("Additional Deposit")]
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
        [OTDisplayName("Additional Deposit Currency")]
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
        [OTDisplayName("Agent Fee")]
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
        [OTDisplayName("Agent Fee Currency")]
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
        [OTDisplayName("Agent Fee Detail")]
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
        [OTDisplayName("Key Money")]
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
        [OTRequired("Key Money Currency", null)]
        [OTDisplayName("Key Money Currency")]
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
        [OTDisplayName("Key Money Detail")]
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
        [OTDisplayName("Nonrefundable Cost")]
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
        [OTDisplayName("Nonrefundable Currency")]
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
        [OTDisplayName("Nonrefundable Cost Detail")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _estateRentId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public FolderHandle RentFolderHandle = new FolderHandle();
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}