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
    [OTDisplayName("Season Type")]
    [DataContract]
    public class SeasonType : ViewModelObject
    {
        private long _seasonTypeId;
        private string _seasonTypeName;
        private string _comment;

        /*Section="Field-SeasonTypeId"*/
        [OTRequired("Season Type Id", null)]
        [OTDisplayName("Season Type Id")]
        [DataMember]
        public long SeasonTypeId
        {
            get
            {
                return _seasonTypeId;
            }
            set
            {
                _seasonTypeId = value;
            }
        }

        /*Section="Field-SeasonTypeName"*/
        [OTRequired("Season Type Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Season Type Name")]
        [DataMember]
        public string SeasonTypeName
        {
            get
            {
                return _seasonTypeName;
            }
            set
            {
                _seasonTypeName = value;
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
            return _seasonTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}