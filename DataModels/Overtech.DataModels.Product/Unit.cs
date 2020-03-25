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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "UNIT", HasAutoIdentity = false, DisplayName = "Unit", IdField = "UnitId")]
    [DataContract]
    public class Unit : DataModelObject
    {
        private long _unitId;
        private string _name;
        private string _comment;

        /*Section="Field-UnitId"*/
        [OTDataField("UNITID")]
        [DataMember]
        public long UnitId
        {
            get
            {
                return _unitId;
            }
            set
            {
                _unitId = value;
            }
        }

        /*Section="Field-Name"*/
        [OTDataField("UNIT_NM")]
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
            _unitId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

