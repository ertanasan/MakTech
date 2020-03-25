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
namespace Overtech.ViewModels.StoreUpload
{
    [OTDisplayName("Upload Type")]
    [DataContract]
    public class UploadType : ViewModelObject
    {
        private long _uploadTypeId;
        private string _name;
        private string _description;

        /*Section="Field-UploadTypeId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Upload Type Id", null)]
        [OTDisplayName("Upload Type Id")]
        [DataMember]
        public long UploadTypeId
        {
            get
            {
                return _uploadTypeId;
            }
            set
            {
                _uploadTypeId = value;
            }
        }

        /*Section="Field-Name"*/
        [OTRequired("Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Name")]
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

        /*Section="Field-Description"*/
        [OTStringLength(1000)]
        [OTDisplayName("Description")]
        [DataMember]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _uploadTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}