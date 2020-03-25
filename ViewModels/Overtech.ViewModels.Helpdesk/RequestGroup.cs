// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Overtech.Core.Data;
using Overtech.UI.Data.Annotations;

/*Section="ClassHeader"*/
namespace Overtech.ViewModels.Helpdesk
{
    [OTDisplayName("Request Group")]
    [DataContract]
    public class RequestGroup : ViewModelObject
    {
        private long _requestGroupId;
        private string _requestGroupName;
        private Nullable<int> _displayOrder;
        private bool _activeFlag;

        /*Section="Field-RequestGroupId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Request Group Id", null)]
        [OTDisplayName("Request Group Id")]
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
        [OTRequired("Request Group Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Request Group Name")]
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
        [OTDisplayName("Display Order")]
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
        [OTDisplayName("Active Flag")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _requestGroupId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}