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
    [OTDisplayName("Request Definition")]
    [DataContract]
    public class RequestDefinition : ViewModelObject
    {
        private long _requestDefinitionId;
        private string _requestDefinitionName;
        private long _requestGroup;
        private long _process;
        private string _microCode;
        private Nullable<int> _displayOrder;
        private bool _activeFlag;

        /*Section="Field-RequestDefinitionId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Request Definition Id", null)]
        [OTDisplayName("Request Definition Id")]
        [DataMember]
        public long RequestDefinitionId
        {
            get
            {
                return _requestDefinitionId;
            }
            set
            {
                _requestDefinitionId = value;
            }
        }

        /*Section="Field-RequestDefinitionName"*/
        [OTRequired("Request Definition Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Request Definition Name")]
        [DataMember]
        public string RequestDefinitionName
        {
            get
            {
                return _requestDefinitionName;
            }
            set
            {
                _requestDefinitionName = value;
            }
        }

        /*Section="Field-RequestGroup"*/
        [UIHint("RequestGroupList")]
        [OTRequired("Request Group", null)]
        [OTDisplayName("Request Group")]
        [DataMember]
        public long RequestGroup
        {
            get
            {
                return _requestGroup;
            }
            set
            {
                _requestGroup = value;
            }
        }

        /*Section="Field-Process"*/
        [UIHint("ProcessDefinitionList")]
        [OTRequired("Process", null)]
        [OTDisplayName("Process")]
        [DataMember]
        public long Process
        {
            get
            {
                return _process;
            }
            set
            {
                _process = value;
            }
        }

        /*Section="Field-MicroCode"*/
        [OTDisplayName("Micro Code")]
        [DataMember]
        public string MicroCode
        {
            get
            {
                return _microCode;
            }
            set
            {
                _microCode = value;
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
            return _requestDefinitionId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}