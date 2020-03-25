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
namespace Overtech.DataModels.OverStoreMain
{
    [OTDataObject(Module = "OverStoreMain", ModuleShortName = "OSM", Table = "SCREENPROPERTY", HasAutoIdentity = true, DisplayName = "OverStore Screen Property", IdField = "OverStoreScreenPropertyId")]
    [DataContract]
    public class OverStoreScreenProperty : DataModelObject
    {
        private long _overStoreScreenPropertyId;
        private long _screen;
        private string _propertyName;
        private string _propertyValue;

        /*Section="Field-OverStoreScreenPropertyId"*/
        [OTDataField("SCREENPROPERTYID")]
        [DataMember]
        public long OverStoreScreenPropertyId
        {
            get
            {
                return _overStoreScreenPropertyId;
            }
            set
            {
                _overStoreScreenPropertyId = value;
            }
        }

        /*Section="Field-Screen"*/
        [OTDataField("SCREEN")]
        [DataMember]
        public long Screen
        {
            get
            {
                return _screen;
            }
            set
            {
                _screen = value;
            }
        }

        /*Section="Field-PropertyName"*/
        [OTDataField("PROPERTY_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _overStoreScreenPropertyId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

