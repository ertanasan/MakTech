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
namespace Overtech.DataModels.Store
{
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "ACCOUNTTYPE", HasAutoIdentity = true, DisplayName = "Store Account Type", IdField = "StoreAccountTypeId")]
    [DataContract]
    public class StoreAccountType : DataModelObject
    {
        private long _storeAccountTypeId;
        private string _accountTypeName;

        /*Section="Field-StoreAccountTypeId"*/
        [OTDataField("ACCOUNTTYPEID")]
        [DataMember]
        public long StoreAccountTypeId
        {
            get
            {
                return _storeAccountTypeId;
            }
            set
            {
                _storeAccountTypeId = value;
            }
        }

        /*Section="Field-AccountTypeName"*/
        [OTDataField("ACCOUNTTYPE_NM")]
        [DataMember]
        public string AccountTypeName
        {
            get
            {
                return _accountTypeName;
            }
            set
            {
                _accountTypeName = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _storeAccountTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

