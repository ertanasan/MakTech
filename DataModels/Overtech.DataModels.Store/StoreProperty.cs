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
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "PROPERTY", HasAutoIdentity = true, DisplayName = "Store Property", IdField = "PropertyId")]
    [DataContract]
    public class StoreProperty : DataModelObject
    {
        private long _store;
        private long _propertyType;
        private string _propertyValue;
        private long _propertyId;

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

        /*Section="Field-PropertyType"*/
        [OTDataField("PROPERTYTYPE")]
        [DataMember]
        public long PropertyType
        {
            get
            {
                return _propertyType;
            }
            set
            {
                _propertyType = value;
            }
        }

        /*Section="Field-PropertyValue"*/
        [OTDataField("VALUE_TXT")]
        [DataMember]
        public string PropertyValue
        {
            get
            {
                return _propertyValue;
            }
            set
            {
                _propertyValue = value;
            }
        }

        /*Section="Field-PropertyId"*/
        [OTDataField("PROPERTYID")]
        [DataMember]
        public long PropertyId
        {
            get
            {
                return _propertyId;
            }
            set
            {
                _propertyId = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _propertyId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

