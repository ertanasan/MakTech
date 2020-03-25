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
    [OTDisplayName("Redirection Group")]
    [DataContract]
    public class RedirectionGroup : ViewModelObject
    {
        private long _redirectionGroupId;
        private string _groupName;
        private long _requestDefinition;

        /*Section="Field-RedirectionGroupId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Redirection Group Id", null)]
        [OTDisplayName("Redirection Group Id")]
        [DataMember]
        public long RedirectionGroupId
        {
            get
            {
                return _redirectionGroupId;
            }
            set
            {
                _redirectionGroupId = value;
            }
        }

        /*Section="Field-GroupName"*/
        [OTRequired("Group Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Group Name")]
        [DataMember]
        public string GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
            }
        }

        /*Section="Field-RequestDefinition"*/
        [UIHint("RequestDefinitionList")]
        [OTRequired("Request Definition", null)]
        [OTDisplayName("Request Definition")]
        [DataMember]
        public long RequestDefinition
        {
            get
            {
                return _requestDefinition;
            }
            set
            {
                _requestDefinition = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _redirectionGroupId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}