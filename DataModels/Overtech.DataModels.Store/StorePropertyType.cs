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
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "PROPERTYTYPE", HasAutoIdentity = true, DisplayName = "Store Property Type", IdField = "StorePropertyId")]
    [DataContract]
    public class StorePropertyType : DataModelObject
    {
        private long _storePropertyId;
        private string _propertyName;

        /*Section="Field-StorePropertyId"*/
        [OTDataField("PROPERTYTYPEID")]
        [DataMember]
        public long StorePropertyId
        {
            get
            {
                return _storePropertyId;
            }
            set
            {
                _storePropertyId = value;
            }
        }

        /*Section="Field-PropertyName"*/
        [OTDataField("PROPERTYTYPE_NM")]
        [DataMember]
        public string PropertyName
        {
            get
            {
                return _propertyName;
            }
            set
            {
                _propertyName = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _storePropertyId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

