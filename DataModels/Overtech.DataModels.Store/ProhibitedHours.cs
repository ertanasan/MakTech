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
namespace Overtech.DataModels.Store
{
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "PROHIBITEDHOURS", HasAutoIdentity = true, DisplayName = "Prohibited Hours", IdField = "ProhibitedHoursId")]
    [DataContract]
    public class ProhibitedHours : DataModelObject
    {
        private long _prohibitedHoursId;
        private long _action;
        private Nullable<int> _storeCode;
        private int _startHour;
        private int _endHour;

        /*Section="Field-ProhibitedHoursId"*/
        [OTDataField("PROHIBITEDHOURSID")]
        [DataMember]
        public long ProhibitedHoursId
        {
            get
            {
                return _prohibitedHoursId;
            }
            set
            {
                _prohibitedHoursId = value;
            }
        }

        /*Section="Field-Action"*/
        [OTDataField("ACTION")]
        [DataMember]
        public long Action
        {
            get
            {
                return _action;
            }
            set
            {
                _action = value;
            }
        }

        /*Section="Field-StoreCode"*/
        [OTDataField("STORE_CD", Nullable = true)]
        [DataMember]
        public Nullable<int> StoreCode
        {
            get
            {
                return _storeCode;
            }
            set
            {
                _storeCode = value;
            }
        }

        /*Section="Field-StartHour"*/
        [OTDataField("STARTHOUR_NO")]
        [DataMember]
        public int StartHour
        {
            get
            {
                return _startHour;
            }
            set
            {
                _startHour = value;
            }
        }

        /*Section="Field-EndHour"*/
        [OTDataField("ENDHOUR_NO")]
        [DataMember]
        public int EndHour
        {
            get
            {
                return _endHour;
            }
            set
            {
                _endHour = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _prohibitedHoursId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

