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
namespace Overtech.ViewModels.Product
{
    [OTDisplayName("Storage Condition")]
    [DataContract]
    public class StorageCondition : ViewModelObject
    {
        private long _storageConditionId;
        private string _condition;
        private string _comment;

        /*Section="Field-StorageConditionId"*/
        [OTRequired("Storage Condition Id", null)]
        [OTDisplayName("Storage Condition Id")]
        [DataMember]
        public long StorageConditionId
        {
            get
            {
                return _storageConditionId;
            }
            set
            {
                _storageConditionId = value;
            }
        }

        /*Section="Field-Condition"*/
        [OTRequired("Condition", null)]
        [OTDisplayName("Condition")]
        [DataMember]
        public string Condition
        {
            get
            {
                return _condition;
            }
            set
            {
                _condition = value;
            }
        }

        /*Section="Field-Comment"*/
        [OTStringLength(1000)]
        [OTDisplayName("Comment")]
        [DataMember]
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storageConditionId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}