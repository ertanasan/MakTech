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
namespace Overtech.DataModels.Warehouse
{
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "MATERIALINFO", HasAutoIdentity = true, DisplayName = "Material Info", IdField = "MaterialInfoId", MasterField = "Material")]
    [DataContract]
    public class MaterialInfo : DataModelObject
    {
        private long _materialInfoId;
        private long _material;
        private string _shortName;
        private string _infoName;

        /*Section="Field-MaterialInfoId"*/
        [OTDataField("MATERIALINFOID")]
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
        [OTDataField("MATERIAL")]
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
        [OTDataField("INFOSHORT_NM")]
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
        [OTDataField("INFO_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _materialInfoId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}