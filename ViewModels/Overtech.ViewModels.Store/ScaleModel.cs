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
    [OTDisplayName("Scale Model")]
    [DataContract]
    public class ScaleModel : ViewModelObject
    {
        private long _scaleModelId;
        private long _brand;
        private string _name;
        private string _description;

        /*Section="Field-ScaleModelId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Scale Model Id", null)]
        [OTDisplayName("Scale Model Id")]
        [DataMember]
        public long ScaleModelId
        {
            get
            {
                return _scaleModelId;
            }
            set
            {
                _scaleModelId = value;
            }
        }

        /*Section="Field-Brand"*/
        [UIHint("ScaleBrandList")]
        [OTRequired("Brand", null)]
        [OTDisplayName("Brand")]
        [DataMember]
        public long Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
            }
        }

        /*Section="Field-Name"*/
        [OTRequired("Name", null)]
        [OTStringLength(1)]
        [OTDisplayName("Name")]
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /*Section="Field-Description"*/
        [OTStringLength(1000)]
        [OTDisplayName("Description")]
        [DataMember]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _scaleModelId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}