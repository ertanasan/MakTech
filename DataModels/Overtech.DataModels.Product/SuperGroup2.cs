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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "SUPERGROUP2", HasAutoIdentity = false, DisplayName = "Super Group 2", IdField = "SuperGroup2Id")]
    [DataContract]
    public class SuperGroup2 : DataModelObject
    {
        private long _superGroup2Id;
        private string _superGroup2Name;
        private string _comment;

        /*Section="Field-SuperGroup2Id"*/
        [OTDataField("SUPERGROUP2ID")]
        [DataMember]
        public long SuperGroup2Id
        {
            get
            {
                return _superGroup2Id;
            }
            set
            {
                _superGroup2Id = value;
            }
        }

        /*Section="Field-SuperGroup2Name"*/
        [OTDataField("SUPERGROUP2_NM")]
        [DataMember]
        public string SuperGroup2Name
        {
            get
            {
                return _superGroup2Name;
            }
            set
            {
                _superGroup2Name = value;
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
            _superGroup2Id = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

