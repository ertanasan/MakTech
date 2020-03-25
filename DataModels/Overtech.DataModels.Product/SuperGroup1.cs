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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "SUPERGROUP1", HasAutoIdentity = false, DisplayName = "Super Group 1", IdField = "SuperGroup1Id")]
    [DataContract]
    public class SuperGroup1 : DataModelObject
    {
        private long _superGroup1Id;
        private string _superGroup1Name;
        private string _comment;

        /*Section="Field-SuperGroup1Id"*/
        [OTDataField("SUPERGROUP1ID")]
        [DataMember]
        public long SuperGroup1Id
        {
            get
            {
                return _superGroup1Id;
            }
            set
            {
                _superGroup1Id = value;
            }
        }

        /*Section="Field-SuperGroup1Name"*/
        [OTDataField("SUPERGROUP1_NM")]
        [DataMember]
        public string SuperGroup1Name
        {
            get
            {
                return _superGroup1Name;
            }
            set
            {
                _superGroup1Name = value;
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
            _superGroup1Id = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

