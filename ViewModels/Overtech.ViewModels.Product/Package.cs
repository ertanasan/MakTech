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
    [OTDisplayName("Package")]
    [DataContract]
    public class Package : ViewModelObject
    {
        private long _packageId;
        private string _name;
        private Nullable<int> _parentPackage;
        private decimal _amount;
        private string _description;

        /*Section="Field-PackageId"*/
        [OTRequired("Package Id", null)]
        [OTDisplayName("Package Id")]
        [DataMember]
        public long PackageId
        {
            get
            {
                return _packageId;
            }
            set
            {
                _packageId = value;
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

        /*Section="Field-ParentPackage"*/
        [OTDisplayName("Parent Package")]
        [DataMember]
        public Nullable<int> ParentPackage
        {
            get
            {
                return _parentPackage;
            }
            set
            {
                _parentPackage = value;
            }
        }

        /*Section="Field-Amount"*/
        [OTRequired("Amount", null)]
        [OTDisplayName("Amount")]
        [DataMember]
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
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
            return _packageId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}