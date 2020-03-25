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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "MATERIAL", HasAutoIdentity = true, DisplayName = "Material", IdField = "MaterialId")]
    [DataContract]
    public class Material : DataModelObject
    {
        private long _materialId;
        private string _materialName;
        private string _mikroCode;
        private int _unitCode;
        private Nullable<long> _category;

        /*Section="Field-MaterialId"*/
        [OTDataField("MATERIALID")]
        [DataMember]
        public long MaterialId
        {
            get
            {
                return _materialId;
            }
            set
            {
                _materialId = value;
            }
        }

        /*Section="Field-MaterialName"*/
        [OTDataField("MATERIAL_NM")]
        [DataMember]
        public string MaterialName
        {
            get
            {
                return _materialName;
            }
            set
            {
                _materialName = value;
            }
        }

        /*Section="Field-MikroCode"*/
        [OTDataField("MIKRO_DSC")]
        [DataMember]
        public string MikroCode
        {
            get
            {
                return _mikroCode;
            }
            set
            {
                _mikroCode = value;
            }
        }

        /*Section="Field-UnitCode"*/
        [OTDataField("UNIT_CD")]
        [DataMember]
        public int UnitCode
        {
            get
            {
                return _unitCode;
            }
            set
            {
                _unitCode = value;
            }
        }

        /*Section="Field-Category"*/
        [OTDataField("MATERIALCATEGORY", Nullable = true)]
        [DataMember]
        public Nullable<long> Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _materialId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

