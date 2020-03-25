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
namespace Overtech.ViewModels.Warehouse
{
    [OTDisplayName("Constraint Exception")]
    [DataContract]
    public class ConstraintException : ViewModelObject
    {
        private long _constraintExceptionId;
        private long _store;
        private DateTime _startDate;
        private DateTime _endDate;
        private Nullable<long> _category;
        private Nullable<long> _subGroup;
        private Nullable<long> _product;
        private decimal _coefficient;

        /*Section="Field-ConstraintExceptionId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Constraint Exception Id", null)]
        [OTDisplayName("Constraint Exception Id")]
        [DataMember]
        public long ConstraintExceptionId
        {
            get
            {
                return _constraintExceptionId;
            }
            set
            {
                _constraintExceptionId = value;
            }
        }

        /*Section="Field-Store"*/
        [UIHint("StoreList")]
        [OTRequired("Store", null)]
        [OTDisplayName("Store")]
        [DataMember]
        public long Store
        {
            get
            {
                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /*Section="Field-StartDate"*/
        [OTRequired("Start Date", null)]
        [OTDisplayName("Start Date")]
        [DataMember]
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }

        /*Section="Field-EndDate"*/
        [OTRequired("End Date", null)]
        [OTDisplayName("End Date")]
        [DataMember]
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
            }
        }

        /*Section="Field-Category"*/
        [UIHint("ProductCategoryList")]
        [OTDisplayName("Category")]
        [DataMember]
        public Nullable<long> Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        /*Section="Field-SubGroup"*/
        [UIHint("SubgroupList")]
        [OTDisplayName("SubGroup")]
        [DataMember]
        public Nullable<long> SubGroup
        {
            get
            {
                return _subGroup;
            }
            set
            {
                _subGroup = value;
            }
        }

        /*Section="Field-Product"*/
        [UIHint("ProductList")]
        [OTDisplayName("Product")]
        [DataMember]
        public Nullable<long> Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }

        /*Section="Field-Coefficient"*/
        [OTRequired("Coefficient", null)]
        [OTDisplayName("Coefficient")]
        [DataMember]
        public decimal Coefficient
        {
            get
            {
                return _coefficient;
            }
            set
            {
                _coefficient = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _constraintExceptionId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}