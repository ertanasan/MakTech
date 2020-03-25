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
namespace Overtech.ViewModels.Store
{
    [OTDisplayName("Prohibited Hours")]
    [DataContract]
    public class ProhibitedHours : ViewModelObject
    {
        private long _prohibitedHoursId;
        private long _action;
        private Nullable<int> _storeCode;
        private int _startHour;
        private int _endHour;

        /*Section="Field-ProhibitedHoursId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Prohibited Hours Id", null)]
        [OTDisplayName("Prohibited Hours Id")]
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
        [UIHint("StoreActionList")]
        [OTRequired("Action", null)]
        [OTDisplayName("Action")]
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
        [OTDisplayName("Store Code")]
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
        [OTRequired("Start Hour", null)]
        [OTDisplayName("Start Hour")]
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
        [OTRequired("End Hour", null)]
        [OTDisplayName("End Hour")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _prohibitedHoursId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}