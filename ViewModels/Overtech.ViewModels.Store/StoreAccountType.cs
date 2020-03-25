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
    [OTDisplayName("Store Account Type")]
    [DataContract]
    public class StoreAccountType : ViewModelObject
    {
        private long _storeAccountTypeId;
        private string _accountTypeName;

        /*Section="Field-StoreAccountTypeId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Store Account Type Id", null)]
        [OTDisplayName("Store Account Type Id")]
        [DataMember]
        public long StoreAccountTypeId
        {
            get
            {
                return _storeAccountTypeId;
            }
            set
            {
                _storeAccountTypeId = value;
            }
        }

        /*Section="Field-AccountTypeName"*/
        [OTRequired("Account Type Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Account Type Name")]
        [DataMember]
        public string AccountTypeName
        {
            get
            {
                return _accountTypeName;
            }
            set
            {
                _accountTypeName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storeAccountTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}