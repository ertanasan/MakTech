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
namespace Overtech.ViewModels.Accounting
{
    [OTDisplayName("Firm Type")]
    [DataContract]
    public class FirmType : ViewModelObject
    {
        private long _firmTypeId;
        private string _name;

        /*Section="Field-FirmTypeId"*/
        [OTRequired("Firm Type Id", null)]
        [OTDisplayName("Firm Type Id")]
        [DataMember]
        public long FirmTypeId
        {
            get
            {
                return _firmTypeId;
            }
            set
            {
                _firmTypeId = value;
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _firmTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}