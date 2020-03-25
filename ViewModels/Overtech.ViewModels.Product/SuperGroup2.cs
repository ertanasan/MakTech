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
    [OTDisplayName("Super Group 2")]
    [DataContract]
    public class SuperGroup2 : ViewModelObject
    {
        private long _superGroup2Id;
        private string _superGroup2Name;
        private string _comment;

        /*Section="Field-SuperGroup2Id"*/
        [OTRequired("Super Group 2 Id", null)]
        [OTDisplayName("Super Group 2 Id")]
        [DataMember]
        public long SuperGroup2Id
        {
            get
            {
                return _superGroup2Id;
            }
            set
            {
                _superGroup2Id = value;
            }
        }

        /*Section="Field-SuperGroup2Name"*/
        [OTRequired("Super Group 2 Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Super Group 2 Name")]
        [DataMember]
        public string SuperGroup2Name
        {
            get
            {
                return _superGroup2Name;
            }
            set
            {
                _superGroup2Name = value;
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
            return _superGroup2Id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}