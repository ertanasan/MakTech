// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Price;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Price
{
    [ServiceContract]
    public interface IPromotionTypeService : ICRUDLServiceContract<Overtech.DataModels.Price.PromotionType>
    {
        /*Section="Method-CreatePackagePromotion"*/
        [OperationContract]
        void CreatePackagePromotion(PackagePromotion packagePromotion);

        /*Section="Method-ReadPackagePromotion"*/
        [OperationContract]
        PackagePromotion ReadPackagePromotion(long promotionType, long package);

        /*Section="Method-DeletePackagePromotion"*/
        [OperationContract]
        void DeletePackagePromotion(long promotionType, long package);

        /*Section="Method-ListPackagePromotions"*/
        [OperationContract]
        IEnumerable<PackagePromotion> ListPackagePromotions(long promotionTypeId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

