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
namespace Overtech.ViewModels.Accounting
{
    [OTDisplayName("Loomis")]
    [DataContract]
    public class Loomis : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Loomis Id", null)]
        [OTDisplayName("Loomis Id")]
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
        [ScaffoldColumn(false)]
        [OTRequired("Event", null)]
        [OTDisplayName("Event")]
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
        [ScaffoldColumn(false)]
        [OTRequired("Organization", null)]
        [OTDisplayName("Organization")]
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

        /*Section="Field-SaleDate"*/
        [OTRequired("Sale Date", null)]
        [OTDisplayName("Sale Date")]
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
        [UIHint("StoreList")]
        [OTRequired("Store", null)]
        [OTDisplayName("Store")]
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
        [OTRequired("Seal No", null)]
        [OTDisplayName("Seal No")]
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
        [OTDisplayName("Declared Amount")]
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
        [OTRequired("Actual Amount", null)]
        [OTDisplayName("Actual Amount")]
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
        [OTDisplayName("Fake Amount")]
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
        [OTDisplayName("Explanation")]
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
        [OTDisplayName("Mikro Time")]
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
        [OTRequired("Mikro Status Code", null)]
        [OTDisplayName("Mikro Status Code")]
        [DefaultValue(0)]
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
        [OTDisplayName("Mikro Transaction Code")]
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
        [OTDisplayName("Loomis Date")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _loomisId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public decimal ReconciliationBankAmount { get; set; }

        [DataMember]
        public decimal ActualDiff { get; set; }

        [DataMember]
        public int ControlCode { get; set; }

        [DataMember]
        public decimal ReconciliationDiff { get; set; }

        [DataMember]
        public decimal ReconDeclaredDiff { get; set; }

        // Yılbaşından bugüne kadar loomis'e teslim edilen mutabakatta belirlenen tutar arasındaki farkın kümüle değeri
        [DataMember]
        public decimal CumulativeDiff { get; set; }

        // Yılbaşından bugüne kadar loomis'e teslim edilen mutabakatta belirlenen tutar arasında negatif çıkan farkların kümüle değeri
        [DataMember]
        public decimal CumulativeNegativeDiff { get; set; }

        // Yılbaşından bugüne kadar loomis'e teslim edilen tutar ile mutabakatın tutarlı olduğu gün sayısı
        [DataMember]
        public int ConsistentDayCount { get; set; }

        // Yılbaşından bugüne kadar toplam gün sayısı
        [DataMember]
        public int DayCount { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}