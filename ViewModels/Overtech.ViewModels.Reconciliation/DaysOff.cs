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
namespace Overtech.ViewModels.Reconciliation
{
    [OTDisplayName("Days Off")]
    [DataContract]
    public class DaysOff : ViewModelObject
    {
        private long _daysOffId;
        private long _store;
        private DateTime _offDay;

        /*Section="Field-DaysOffId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Days Off Id", null)]
        [OTDisplayName("Days Off Id")]
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
        [UIHint("StoreList")]
        [OTRequired("Store", null)]
        [OTDisplayName("Store")]
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
        [OTRequired("Off Day", null)]
        [OTDisplayName("Off Day")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _daysOffId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}