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
    [OTDataObject(Module = "Accounting", ModuleShortName = "ACC", Table = "EXPENSECENTER", HasAutoIdentity = true, DisplayName = "Expense Center", IdField = "ExpenseCenterId")]
    [DataContract]
    public class ExpenseCenter : DataModelObject
    {
        private long _expenseCenterId;
        private string _expenseCenterName;
        private string _expenseCenterCode;
        private int _expenseCenterGroup;
        private Nullable<long> _regionManager;
        private Nullable<long> _store;
        private bool _activeFlag;

        /*Section="Field-ExpenseCenterId"*/
        [OTDataField("EXPENSECENTERID")]
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
        [OTDataField("EXPENSECENTER_NM")]
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
        [OTDataField("EXPENSECENTERCODE_TXT")]
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
        [OTDataField("CENTERGROUP_NO")]
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
        [OTDataField("REGIONMANAGER", Nullable = true)]
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
        [OTDataField("STORE", Nullable = true)]
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
        [OTDataField("ACTIVE_FL")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _expenseCenterId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

