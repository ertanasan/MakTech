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
    [OTDisplayName("Process Definition")]
    [DataContract]
    public class HelpdeskProcess : ViewModelObject
    {
        private long _processDefinitionId;
        private string _processDefinitionName;
        private int _processNo;

        /*Section="Field-ProcessDefinitionId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Process Definition Id", null)]
        [OTDisplayName("Process Definition Id")]
        [DataMember]
        public long ProcessDefinitionId
        {
            get
            {
                return _processDefinitionId;
            }
            set
            {
                _processDefinitionId = value;
            }
        }

        /*Section="Field-ProcessDefinitionName"*/
        [OTRequired("Process Definition Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Process Definition Name")]
        [DataMember]
        public string ProcessDefinitionName
        {
            get
            {
                return _processDefinitionName;
            }
            set
            {
                _processDefinitionName = value;
            }
        }

        /*Section="Field-ProcessNo"*/
        [OTRequired("Process No", null)]
        [OTDisplayName("Process No")]
        [DataMember]
        public int ProcessNo
        {
            get
            {
                return _processNo;
            }
            set
            {
                _processNo = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _processDefinitionId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}