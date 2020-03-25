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
namespace Overtech.ViewModels.Warehouse
{
    [OTDisplayName("Material Info")]
    [DataContract]
    public class MaterialInfo : ViewModelObject
    {
        private long _materialInfoId;
        private long _material;
        private string _shortName;
        private string _infoName;

        /*Section="Field-MaterialInfoId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Material Info Id", null)]
        [OTDisplayName("Material Info Id")]
        [DataMember]
        public long MaterialInfoId
        {
            get
            {
                return _materialInfoId;
            }
            set
            {
                _materialInfoId = value;
            }
        }

        /*Section="Field-Material"*/
        [UIHint("MaterialList")]
        [OTRequired("Material", null)]
        [OTDisplayName("Material")]
        [DataMember]
        public long Material
        {
            get
            {
                return _material;
            }
            set
            {
                _material = value;
            }
        }

        /*Section="Field-ShortName"*/
        [OTRequired("Short Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Short Name")]
        [DataMember]
        public string ShortName
        {
            get
            {
                return _shortName;
            }
            set
            {
                _shortName = value;
            }
        }

        /*Section="Field-InfoName"*/
        [OTRequired("Info Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Info Name")]
        [DataMember]
        public string InfoName
        {
            get
            {
                return _infoName;
            }
            set
            {
                _infoName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _materialInfoId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}