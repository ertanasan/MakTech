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
namespace Overtech.DataModels.StoreUpload
{
    [OTDataObject(Module = "StoreUpload", ModuleShortName = "SUP", Table = "UPLOADTYPE", HasAutoIdentity = true, DisplayName = "Upload Type", IdField = "UploadTypeId")]
    [DataContract]
    public class UploadType : DataModelObject
    {
        private long _uploadTypeId;
        private string _name;
        private string _description;

        /*Section="Field-UploadTypeId"*/
        [OTDataField("UPLOADTYPEID")]
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
        [OTDataField("UPLOADTYPE_NM")]
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
        [OTDataField("COMMENT_DSC")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _uploadTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

