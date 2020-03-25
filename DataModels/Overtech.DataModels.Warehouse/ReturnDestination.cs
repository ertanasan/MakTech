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
namespace Overtech.DataModels.Warehouse
{
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "RETURNDESTINATION", HasAutoIdentity = true, DisplayName = "Return Destination", IdField = "ReturnDestinationId")]
    [DataContract]
    public class ReturnDestination : DataModelObject
    {
        private long _returnDestinationId;
        private string _destinationName;

        /*Section="Field-ReturnDestinationId"*/
        [OTDataField("RETURNDESTINATIONID")]
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
        [OTDataField("DESTINATION_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _returnDestinationId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

