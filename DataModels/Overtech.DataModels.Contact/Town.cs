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
namespace Overtech.DataModels.Contact
{
    [OTDataObject(Module = "Contact", ModuleShortName = "CNT", Table = "TOWN", HasAutoIdentity = true, DisplayName = "Town", IdField = "TownId")]
    [DataContract]
    public class Town : DataModelObject
    {
        private long _townId;
        private long _city;
        private string _townName;

        /*Section="Field-TownId"*/
        [OTDataField("TOWNID")]
        [DataMember]
        public long TownId
        {
            get
            {
                return _townId;
            }
            set
            {
                _townId = value;
            }
        }

        /*Section="Field-City"*/
        [OTDataField("CITY")]
        [DataMember]
        public long City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        /*Section="Field-TownName"*/
        [OTDataField("TOWN_NM")]
        [DataMember]
        public string TownName
        {
            get
            {
                return _townName;
            }
            set
            {
                _townName = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _townId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

