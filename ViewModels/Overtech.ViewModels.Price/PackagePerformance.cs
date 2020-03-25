// Created by OverGenerator
/*Section="Usings"*/
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Data;

using Overtech.Core.Data;
using Overtech.UI.Data.Annotations;

/*Section="ClassHeader"*/
namespace Overtech.ViewModels.Price
{
    [OTDisplayName("Package Performance")]
    [DataContract]
    public class PackagePerformance : ViewModelObject
    {
        private long _packageId;
        private float _priceChangePercentage;
        private float _saleChangePercentage;
        private int _productCount;
        private DataTable _performanceDetailsGrid;

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
        
        [OTDisplayName("Sale Change Percentage")]
        [DataMember]
        public float SaleChangePercentage
        {
            get
            {
                return _saleChangePercentage;
            }
            set
            {
                _saleChangePercentage = value;
            }
        }

        [OTDisplayName("Price Change Percentage")]
        [DataMember]
        public float PriceChangePercentage
        {
            get
            {
                return _priceChangePercentage;
            }
            set
            {
                _priceChangePercentage = value;
            }
        }

        [OTDisplayName("Product Count")]
        [DataMember]
        public int ProductCount
        {
            get
            {
                return _productCount;
            }
            set
            {
                _productCount = value;
            }
        }

        [OTDisplayName("Performance Detail DataTable")]
        [DataMember]
        public DataTable PerformanceDetailsGrid
        {
            get
            {
                return _performanceDetailsGrid;
            }
            set
            {
                _performanceDetailsGrid = value;
            }
        }

        public override long GetId()
        {
            return _packageId;
        }
    }
}