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
namespace Overtech.DataModels.Warehouse
{
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "CONSTRAINTEXCEPTION", HasAutoIdentity = true, DisplayName = "Constraint Exception", IdField = "ConstraintExceptionId")]
    [DataContract]
    public class ConstraintException : DataModelObject
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
        [OTDataField("CONSTRAINTEXCEPTIONID")]
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
        [OTDataField("STORE")]
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
        [OTDataField("STARTDATE_DT")]
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
        [OTDataField("ENDDATE_DT")]
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
        [OTDataField("CATEGORY", Nullable = true)]
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
        [OTDataField("SUBGROUP", Nullable = true)]
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
        [OTDataField("PRODUCT", Nullable = true)]
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
        [OTDataField("COEFFICIENT_RT")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _constraintExceptionId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

