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
    [OTDisplayName("Scale Brand")]
    [DataContract]
    public class ScaleBrand : ViewModelObject
    {
        private long _scaleBrandId;
        private string _name;
        private string _description;

        /*Section="Field-ScaleBrandId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Scale Brand Id", null)]
        [OTDisplayName("Scale Brand Id")]
        [DataMember]
        public long ScaleBrandId
        {
            get
            {
                return _scaleBrandId;
            }
            set
            {
                _scaleBrandId = value;
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
            return _scaleBrandId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string PriceFilePath
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}