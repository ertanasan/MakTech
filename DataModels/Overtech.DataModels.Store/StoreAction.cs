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
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "ACTION", HasAutoIdentity = false, DisplayName = "Store Action", IdField = "StoreActionId")]
    [DataContract]
    public class StoreAction : DataModelObject
    {
        private long _storeActionId;
        private string _actionName;

        /*Section="Field-StoreActionId"*/
        [OTDataField("ACTIONID")]
        [DataMember]
        public long StoreActionId
        {
            get
            {
                return _storeActionId;
            }
            set
            {
                _storeActionId = value;
            }
        }

        /*Section="Field-ActionName"*/
        [OTDataField("ACTION_NM")]
        [DataMember]
        public string ActionName
        {
            get
            {
                return _actionName;
            }
            set
            {
                _actionName = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _storeActionId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

