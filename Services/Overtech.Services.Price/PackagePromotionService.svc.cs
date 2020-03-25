// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Price;
using Overtech.ServiceContracts.Price;

/*Section="ClassHeader"*/
namespace Overtech.Services.Price
{
    [OTInspectorBehavior]
    public class PackagePromotionService : CRUDRDataService<Overtech.DataModels.Price.PackagePromotion>, IPackagePromotionService
    {
        /*Section="Constructor-1"*/
        public PackagePromotionService()
        {
        }

        /*Section="Constructor-2"*/
        internal PackagePromotionService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}