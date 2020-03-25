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
namespace Overtech.DataModels.Reconciliation
{
    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL", Table = "DAYSOFF", HasAutoIdentity = true, DisplayName = "Days Off", IdField = "DaysOffId")]
    [DataContract]
    public class DaysOff : DataModelObject
    {
        private long _daysOffId;
        private long _store;
        private DateTime _offDay;

        /*Section="Field-DaysOffId"*/
        [OTDataField("DAYSOFFID")]
        [DataMember]
        public long DaysOffId
        {
            get
            {
                return _daysOffId;
            }
            set
            {
                _daysOffId = value;
            }
        }

        /*Section="Field-Store"*/
        [OTDataField("STORE")]
        [DataMember]
        public long Store
        {
            get
            {
                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /*Section="Field-OffDay"*/
        [OTDataField("OFFDAY_DT")]
        [DataMember]
        public DateTime OffDay
        {
            get
            {
                return _offDay;
            }
            set
            {
                _offDay = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _daysOffId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

