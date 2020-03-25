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
namespace Overtech.DataModels.Price
{
    [OTDataObject(Module = "Price", ModuleShortName = "PRC", Table = "PACKAGETYPE", HasAutoIdentity = true, DisplayName = "Package Type", IdField = "PackageTypeId")]
    [DataContract]
    public class PackageType : DataModelObject
    {
        private long _packageTypeId;
        private string _packageTypeName;
        private string _comment;

        /*Section="Field-PackageTypeId"*/
        [OTDataField("PACKAGETYPEID")]
        [DataMember]
        public long PackageTypeId
        {
            get
            {
                return _packageTypeId;
            }
            set
            {
                _packageTypeId = value;
            }
        }

        /*Section="Field-PackageTypeName"*/
        [OTDataField("PACKAGETYPE_NM")]
        [DataMember]
        public string PackageTypeName
        {
            get
            {
                return _packageTypeName;
            }
            set
            {
                _packageTypeName = value;
            }
        }

        /*Section="Field-Comment"*/
        [OTDataField("COMMENT_DSC")]
        [DataMember]
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _packageTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

