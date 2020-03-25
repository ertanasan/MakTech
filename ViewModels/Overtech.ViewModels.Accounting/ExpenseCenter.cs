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
    [OTDisplayName("Expense Center")]
    [DataContract]
    public class ExpenseCenter : ViewModelObject
    {
        private long _expenseCenterId;
        private string _expenseCenterName;
        private string _expenseCenterCode;
        private int _expenseCenterGroup;
        private Nullable<long> _regionManager;
        private Nullable<long> _store;
        private bool _activeFlag;

        /*Section="Field-ExpenseCenterId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Expense Center Id", null)]
        [OTDisplayName("Expense Center Id")]
        [DataMember]
        public long ExpenseCenterId
        {
            get
            {
                return _expenseCenterId;
            }
            set
            {
                _expenseCenterId = value;
            }
        }

        /*Section="Field-ExpenseCenterName"*/
        [OTRequired("Expense Center Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Expense Center Name")]
        [DataMember]
        public string ExpenseCenterName
        {
            get
            {
                return _expenseCenterName;
            }
            set
            {
                _expenseCenterName = value;
            }
        }

        /*Section="Field-ExpenseCenterCode"*/
        [OTRequired("Expense Center Code", null)]
        [OTDisplayName("Expense Center Code")]
        [DataMember]
        public string ExpenseCenterCode
        {
            get
            {
                return _expenseCenterCode;
            }
            set
            {
                _expenseCenterCode = value;
            }
        }

        /*Section="Field-ExpenseCenterGroup"*/
        [OTRequired("Expense Center Group", null)]
        [OTDisplayName("Expense Center Group")]
        [DataMember]
        public int ExpenseCenterGroup
        {
            get
            {
                return _expenseCenterGroup;
            }
            set
            {
                _expenseCenterGroup = value;
            }
        }

        /*Section="Field-RegionManager"*/
        [UIHint("RegionManagersList")]
        [OTDisplayName("Region Manager")]
        [DataMember]
        public Nullable<long> RegionManager
        {
            get
            {
                return _regionManager;
            }
            set
            {
                _regionManager = value;
            }
        }

        /*Section="Field-Store"*/
        [UIHint("StoreList")]
        [OTDisplayName("Store")]
        [DataMember]
        public Nullable<long> Store
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

        /*Section="Field-ActiveFlag"*/
        [OTRequired("Active Flag", null)]
        [OTDisplayName("Active Flag")]
        [DataMember]
        public bool ActiveFlag
        {
            get
            {
                return _activeFlag;
            }
            set
            {
                _activeFlag = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _expenseCenterId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}