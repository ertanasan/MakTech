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
    [OTDisplayName("Store Action")]
    [DataContract]
    public class StoreAction : ViewModelObject
    {
        private long _storeActionId;
        private string _actionName;

        /*Section="Field-StoreActionId"*/
        [OTRequired("Store Action Id", null)]
        [OTDisplayName("Store Action Id")]
        [DataMember]
        public long StoreActionId
        {
            get
            {
                return _storeActionId;
            }
            set
            {
                _storeActionId = value;
            }
        }

        /*Section="Field-ActionName"*/
        [OTRequired("Action Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Action Name")]
        [DataMember]
        public string ActionName
        {
            get
            {
                return _actionName;
            }
            set
            {
                _actionName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storeActionId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}