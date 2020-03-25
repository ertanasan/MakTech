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
    [OTDisplayName("Store Property Type")]
    [DataContract]
    public class StorePropertyType : ViewModelObject
    {
        private long _storePropertyId;
        private string _propertyName;

        /*Section="Field-StorePropertyId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Store Property Id", null)]
        [OTDisplayName("Store Property Id")]
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
        [OTRequired("Property Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Property Name")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storePropertyId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}