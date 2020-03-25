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
    [OTDisplayName("Super Group 3")]
    [DataContract]
    public class SuperGroup3 : ViewModelObject
    {
        private long _superGroup3Id;
        private string _superGroup3Name;
        private string _comment;

        /*Section="Field-SuperGroup3Id"*/
        [OTRequired("Super Group 3 Id", null)]
        [OTDisplayName("Super Group 3 Id")]
        [DataMember]
        public long SuperGroup3Id
        {
            get
            {
                return _superGroup3Id;
            }
            set
            {
                _superGroup3Id = value;
            }
        }

        /*Section="Field-SuperGroup3Name"*/
        [OTRequired("Super Group 3 Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Super Group 3 Name")]
        [DataMember]
        public string SuperGroup3Name
        {
            get
            {
                return _superGroup3Name;
            }
            set
            {
                _superGroup3Name = value;
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
            return _superGroup3Id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}