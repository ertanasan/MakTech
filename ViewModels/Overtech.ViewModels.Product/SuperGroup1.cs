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
    [OTDisplayName("Super Group 1")]
    [DataContract]
    public class SuperGroup1 : ViewModelObject
    {
        private long _superGroup1Id;
        private string _superGroup1Name;
        private string _comment;

        /*Section="Field-SuperGroup1Id"*/
        [OTRequired("Super Group 1 Id", null)]
        [OTDisplayName("Super Group 1 Id")]
        [DataMember]
        public long SuperGroup1Id
        {
            get
            {
                return _superGroup1Id;
            }
            set
            {
                _superGroup1Id = value;
            }
        }

        /*Section="Field-SuperGroup1Name"*/
        [OTRequired("Super Group 1 Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Super Group 1 Name")]
        [DataMember]
        public string SuperGroup1Name
        {
            get
            {
                return _superGroup1Name;
            }
            set
            {
                _superGroup1Name = value;
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
            return _superGroup1Id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}