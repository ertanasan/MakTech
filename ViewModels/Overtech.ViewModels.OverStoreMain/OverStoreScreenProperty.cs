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
namespace Overtech.ViewModels.OverStoreMain
{
    [OTDisplayName("OverStore Screen Property")]
    [DataContract]
    public class OverStoreScreenProperty : ViewModelObject
    {
        private long _overStoreScreenPropertyId;
        private long _screen;
        private string _propertyName;
        private string _propertyValue;

        /*Section="Field-OverStoreScreenPropertyId"*/
        [ScaffoldColumn(false)]
        [OTRequired("OverStore Screen Property Id", null)]
        [OTDisplayName("OverStore Screen Property Id")]
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
        [UIHint("ScreenList")]
        [OTRequired("Screen", null)]
        [OTDisplayName("Screen")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _overStoreScreenPropertyId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}