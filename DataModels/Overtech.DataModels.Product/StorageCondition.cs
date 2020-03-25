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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "STORAGECONDITION", HasAutoIdentity = false, DisplayName = "Storage Condition", IdField = "StorageConditionId")]
    [DataContract]
    public class StorageCondition : DataModelObject
    {
        private long _storageConditionId;
        private string _condition;
        private string _comment;

        /*Section="Field-StorageConditionId"*/
        [OTDataField("STORAGECONDITIONID")]
        [DataMember]
        public long StorageConditionId
        {
            get
            {
                return _storageConditionId;
            }
            set
            {
                _storageConditionId = value;
            }
        }

        /*Section="Field-Condition"*/
        [OTDataField("CONDITION_TXT")]
        [DataMember]
        public string Condition
        {
            get
            {
                return _condition;
            }
            set
            {
                _condition = value;
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
            _storageConditionId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

