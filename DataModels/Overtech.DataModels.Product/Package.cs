// Created by OverGenerator
/*Section="Usings"*/
using Overtech.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

/*Section="ClassHeader"*/
namespace Overtech.DataModels.Product
{
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "PACKAGE", HasAutoIdentity = false, DisplayName = "Package", IdField = "PackageId")]
    [DataContract]
    public class Package : DataModelObject
    {
        private long _packageId;
        private string _name;
        private Nullable<int> _parentPackage;
        private decimal _amount;
        private string _description;

        /*Section="Field-PackageId"*/
        [OTDataField("PACKAGEID")]
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
        [OTDataField("PACKAGE_NM")]
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
        [OTDataField("PARENTPACKAGE", Nullable = true)]
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
        [OTDataField("AMOUNT_AMT")]
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
            _packageId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

