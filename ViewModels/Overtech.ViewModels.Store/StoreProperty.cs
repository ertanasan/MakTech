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
namespace Overtech.ViewModels.Store
{
    [OTDisplayName("Store Property")]
    [DataContract]
    public class StoreProperty : ViewModelObject
    {
        private long _store;
        private long _propertyType;
        private string _propertyValue;
        private long _propertyId;

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

        /*Section="Field-PropertyType"*/
        [UIHint("StorePropertyTypeList")]
        [OTRequired("Property Type", null)]
        [OTDisplayName("Property Type")]
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
        [OTRequired("Property Value", null)]
        [OTDisplayName("Property Value")]
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
        [ScaffoldColumn(false)]
        [OTRequired("Property Id", null)]
        [OTDisplayName("Property Id")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _propertyId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}