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
namespace Overtech.ViewModels.Warehouse
{
    [OTDisplayName("Return Destination")]
    [DataContract]
    public class ReturnDestination : ViewModelObject
    {
        private long _returnDestinationId;
        private string _destinationName;

        /*Section="Field-ReturnDestinationId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Return Destination Id", null)]
        [OTDisplayName("Return Destination Id")]
        [DataMember]
        public long ReturnDestinationId
        {
            get
            {
                return _returnDestinationId;
            }
            set
            {
                _returnDestinationId = value;
            }
        }

        /*Section="Field-DestinationName"*/
        [OTRequired("Destination Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Destination Name")]
        [DataMember]
        public string DestinationName
        {
            get
            {
                return _destinationName;
            }
            set
            {
                _destinationName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _returnDestinationId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}