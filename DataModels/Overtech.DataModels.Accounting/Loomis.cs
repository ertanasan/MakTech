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
namespace Overtech.DataModels.Accounting
{
    [OTDataObject(Module = "Accounting", ModuleShortName = "ACC", Table = "LOOMIS", HasAutoIdentity = true, DisplayName = "Loomis", IdField = "LoomisId")]
    [DataContract]
    public class Loomis : DataModelObject
    {
        private long _loomisId;
        private long _event;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private DateTime _saleDate;
        private long _store;
        private string _sealNo;
        private Nullable<decimal> _declaredAmount;
        private decimal _actualAmount;
        private Nullable<decimal> _fakeAmount;
        private string _explanation;
        private Nullable<DateTime> _mikroTime;
        private int _mikroStatusCode;
        private string _mikroTransactionCode;
        private Nullable<DateTime> _loomisDate;

        /*Section="Field-LoomisId"*/
        [OTDataField("LOOMISID")]
        [DataMember]
        public long LoomisId
        {
            get
            {
                return _loomisId;
            }
            set
            {
                _loomisId = value;
            }
        }

        /*Section="Field-Event"*/
        [OTDataField("EVENT")]
        [DataMember]
        public long Event
        {
            get
            {
                return _event;
            }
            set
            {
                _event = value;
            }
        }

        /*Section="Field-Organization"*/
        [OTDataField("ORGANIZATION")]
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

        /*Section="Field-SaleDate"*/
        [OTDataField("SALE_DT")]
        [DataMember]
        public DateTime SaleDate
        {
            get
            {
                return _saleDate;
            }
            set
            {
                _saleDate = value;
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

        /*Section="Field-SealNo"*/
        [OTDataField("SEAL_TXT")]
        [DataMember]
        public string SealNo
        {
            get
            {
                return _sealNo;
            }
            set
            {
                _sealNo = value;
            }
        }

        /*Section="Field-DeclaredAmount"*/
        [OTDataField("DECLARED_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> DeclaredAmount
        {
            get
            {
                return _declaredAmount;
            }
            set
            {
                _declaredAmount = value;
            }
        }

        /*Section="Field-ActualAmount"*/
        [OTDataField("ACTUAL_AMT")]
        [DataMember]
        public decimal ActualAmount
        {
            get
            {
                return _actualAmount;
            }
            set
            {
                _actualAmount = value;
            }
        }

        /*Section="Field-FakeAmount"*/
        [OTDataField("FAKE_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> FakeAmount
        {
            get
            {
                return _fakeAmount;
            }
            set
            {
                _fakeAmount = value;
            }
        }

        /*Section="Field-Explanation"*/
        [OTDataField("EXPLANATION_TXT")]
        [DataMember]
        public string Explanation
        {
            get
            {
                return _explanation;
            }
            set
            {
                _explanation = value;
            }
        }

        /*Section="Field-MikroTime"*/
        [OTDataField("MIKRO_TM", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> MikroTime
        {
            get
            {
                return _mikroTime;
            }
            set
            {
                _mikroTime = value;
            }
        }

        /*Section="Field-MikroStatusCode"*/
        [OTDataField("MIKROSTATUS_CD")]
        [DataMember]
        public int MikroStatusCode
        {
            get
            {
                return _mikroStatusCode;
            }
            set
            {
                _mikroStatusCode = value;
            }
        }

        /*Section="Field-MikroTransactionCode"*/
        [OTDataField("MIKROTRANCODE_TXT")]
        [DataMember]
        public string MikroTransactionCode
        {
            get
            {
                return _mikroTransactionCode;
            }
            set
            {
                _mikroTransactionCode = value;
            }
        }

        /*Section="Field-LoomisDate"*/
        [OTDataField("LOOMIS_DT", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> LoomisDate
        {
            get
            {
                return _loomisDate;
            }
            set
            {
                _loomisDate = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _loomisId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("BANK_AMT", IsExtended = true)]
        [DataMember]
        public decimal ReconciliationBankAmount { get; set; }

        [OTDataField("ACTUALDIFF_AMT", IsExtended = true)]
        [DataMember]
        public decimal ActualDiff { get; set; }

        [OTDataField("CONTROL_CD", IsExtended = true)]
        [DataMember]
        public int ControlCode { get; set; }

        [OTDataField("RCLDIFF_AMT", IsExtended = true)]
        [DataMember]
        public decimal ReconciliationDiff { get; set; }

        [OTDataField("RCLDECLAREDDIFF_AMT", IsExtended = true)]
        [DataMember]
        public decimal ReconDeclaredDiff { get; set; }

        // Yılbaşından bugüne kadar loomis'e teslim edilen mutabakatta belirlenen tutar arasındaki farkın kümüle değeri
        [OTDataField("CUMULATIVEDIFF_AMT", IsExtended = true)]
        [DataMember]
        public decimal CumulativeDiff { get; set; }

        // Yılbaşından bugüne kadar loomis'e teslim edilen mutabakatta belirlenen tutar arasında negatif çıkan farkların kümüle değeri
        [OTDataField("CUMNEGATIVEDIFF_AMT", IsExtended = true)]
        [DataMember]
        public decimal CumulativeNegativeDiff { get; set; }

        // Yılbaşından bugüne kadar loomis'e teslim edilen tutar ile mutabakatın tutarlı olduğu gün sayısı
        [OTDataField("CONSISTENTDAY_CNT", IsExtended = true)]
        [DataMember]
        public int ConsistentDayCount { get; set; }

        // Yılbaşından bugüne kadar toplam gün sayısı
        [OTDataField("DAY_CNT", IsExtended = true)]
        [DataMember]
        public int DayCount { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

