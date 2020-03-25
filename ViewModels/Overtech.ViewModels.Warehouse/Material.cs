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
    [OTDisplayName("Material")]
    [DataContract]
    public class Material : ViewModelObject
    {
        private long _materialId;
        private string _materialName;
        private string _mikroCode;
        private int _unitCode;
        private Nullable<long> _category;

        /*Section="Field-MaterialId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Material Id", null)]
        [OTDisplayName("Material Id")]
        [DataMember]
        public long MaterialId
        {
            get
            {
                return _materialId;
            }
            set
            {
                _materialId = value;
            }
        }

        /*Section="Field-MaterialName"*/
        [OTRequired("Material Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Material Name")]
        [DataMember]
        public string MaterialName
        {
            get
            {
                return _materialName;
            }
            set
            {
                _materialName = value;
            }
        }

        /*Section="Field-MikroCode"*/
        [OTStringLength(100)]
        [OTDisplayName("Mikro Code")]
        [DataMember]
        public string MikroCode
        {
            get
            {
                return _mikroCode;
            }
            set
            {
                _mikroCode = value;
            }
        }

        /*Section="Field-UnitCode"*/
        [OTRequired("Unit Code", null)]
        [OTDisplayName("Unit Code")]
        [DataMember]
        public int UnitCode
        {
            get
            {
                return _unitCode;
            }
            set
            {
                _unitCode = value;
            }
        }

        /*Section="Field-Category"*/
        [UIHint("MaterialCategoryList")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _materialId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}