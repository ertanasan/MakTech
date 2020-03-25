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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "WARNING", HasAutoIdentity = false, DisplayName = "Warning", IdField = "WarningId")]
    [DataContract]
    public class Warning : DataModelObject
    {
        private long _warningId;
        private string _warningText;
        private string _comment;

        /*Section="Field-WarningId"*/
        [OTDataField("WARNINGID")]
        [DataMember]
        public long WarningId
        {
            get
            {
                return _warningId;
            }
            set
            {
                _warningId = value;
            }
        }

        /*Section="Field-WarningText"*/
        [OTDataField("WARNING_TXT")]
        [DataMember]
        public string WarningText
        {
            get
            {
                return _warningText;
            }
            set
            {
                _warningText = value;
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
            _warningId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

