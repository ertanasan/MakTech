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
    [OTDisplayName("Warning")]
    [DataContract]
    public class Warning : ViewModelObject
    {
        private long _warningId;
        private string _warningText;
        private string _comment;

        /*Section="Field-WarningId"*/
        [OTRequired("Warning Id", null)]
        [OTDisplayName("Warning Id")]
        [DataMember]
        public long WarningId
        {
            get
            {
                return _warningId;
            }
            set
            {
                _warningId = value;
            }
        }

        /*Section="Field-WarningText"*/
        [OTRequired("Warning Text", null)]
        [OTDisplayName("Warning Text")]
        [DataMember]
        public string WarningText
        {
            get
            {
                return _warningText;
            }
            set
            {
                _warningText = value;
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
            return _warningId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}