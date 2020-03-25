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
namespace Overtech.DataModels.Helpdesk
{
    [OTDataObject(Module = "Helpdesk", ModuleShortName = "HDK", Table = "REQUESTGROUP", HasAutoIdentity = true, DisplayName = "Request Group", IdField = "RequestGroupId")]
    [DataContract]
    public class RequestGroup : DataModelObject
    {
        private long _requestGroupId;
        private string _requestGroupName;
        private Nullable<int> _displayOrder;
        private bool _activeFlag;

        /*Section="Field-RequestGroupId"*/
        [OTDataField("REQUESTGROUPID")]
        [DataMember]
        public long RequestGroupId
        {
            get
            {
                return _requestGroupId;
            }
            set
            {
                _requestGroupId = value;
            }
        }

        /*Section="Field-RequestGroupName"*/
        [OTDataField("REQUESTGROUP_NM")]
        [DataMember]
        public string RequestGroupName
        {
            get
            {
                return _requestGroupName;
            }
            set
            {
                _requestGroupName = value;
            }
        }

        /*Section="Field-DisplayOrder"*/
        [OTDataField("DISPLAYORDER_NO", Nullable = true)]
        [DataMember]
        public Nullable<int> DisplayOrder
        {
            get
            {
                return _displayOrder;
            }
            set
            {
                _displayOrder = value;
            }
        }

        /*Section="Field-ActiveFlag"*/
        [OTDataField("ACTIVE_FL")]
        [DataMember]
        public bool ActiveFlag
        {
            get
            {
                return _activeFlag;
            }
            set
            {
                _activeFlag = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _requestGroupId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

