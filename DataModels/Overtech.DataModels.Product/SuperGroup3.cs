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
namespace Overtech.DataModels.Product
{
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "SUPERGROUP3", HasAutoIdentity = false, DisplayName = "Super Group 3", IdField = "SuperGroup3Id")]
    [DataContract]
    public class SuperGroup3 : DataModelObject
    {
        private long _superGroup3Id;
        private string _superGroup3Name;
        private string _comment;

        /*Section="Field-SuperGroup3Id"*/
        [OTDataField("SUPERGROUP3ID")]
        [DataMember]
        public long SuperGroup3Id
        {
            get
            {
                return _superGroup3Id;
            }
            set
            {
                _superGroup3Id = value;
            }
        }

        /*Section="Field-SuperGroup3Name"*/
        [OTDataField("SUPERGROUP3_NM")]
        [DataMember]
        public string SuperGroup3Name
        {
            get
            {
                return _superGroup3Name;
            }
            set
            {
                _superGroup3Name = value;
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
            _superGroup3Id = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

