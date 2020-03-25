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
namespace Overtech.DataModels.Accounting
{
    [OTDataObject(Module = "Accounting", ModuleShortName = "ACC", Table = "FIRMTYPE", HasAutoIdentity = false, DisplayName = "Firm Type", IdField = "FirmTypeId")]
    [DataContract]
    public class FirmType : DataModelObject
    {
        private long _firmTypeId;
        private string _name;

        /*Section="Field-FirmTypeId"*/
        [OTDataField("FIRMTYPEID")]
        [DataMember]
        public long FirmTypeId
        {
            get
            {
                return _firmTypeId;
            }
            set
            {
                _firmTypeId = value;
            }
        }

        /*Section="Field-Name"*/
        [OTDataField("FIRMTYPE_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _firmTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

