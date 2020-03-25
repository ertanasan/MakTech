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
    public class PromotionTypeService : CRUDLDataService<Overtech.DataModels.Price.PromotionType>, IPromotionTypeService
    {
        /*Section="Constructor-1"*/
        public PromotionTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal PromotionTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-CreatePackagePromotion"*/
        public void CreatePackagePromotion(PackagePromotion packagePromotion)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmPackage = dal.CreateParameter("Package", packagePromotion.Package);
                    IUniParameter prmPromotionType = dal.CreateParameter("PromotionType", packagePromotion.PromotionType);
                    dal.ExecuteNonQuery("PRC_INS_PACKAGEPROMOTION_SP", prmPackage, prmPromotionType);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-ReadPackagePromotion"*/
        public PackagePromotion ReadPackagePromotion(long promotionType, long package)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmPromotionType = dal.CreateParameter("PromotionType", promotionType);
                IUniParameter prmPackage = dal.CreateParameter("Package", package);
                return dal.Read<PackagePromotion>("PRC_SEL_PACKAGEPROMOTION_SP", prmPromotionType, prmPackage);
            }
        }

        /*Section="Method-DeletePackagePromotion"*/
        public void DeletePackagePromotion(long promotionType, long package)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmPromotionType = dal.CreateParameter("PromotionType", promotionType);
                    IUniParameter prmPackage = dal.CreateParameter("Package", package);
                    dal.ExecuteNonQuery("PRC_DEL_PACKAGEPROMOTION_SP", prmPromotionType, prmPackage);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-ListPackagePromotions"*/
        public IEnumerable<PackagePromotion> ListPackagePromotions(long promotionTypeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmPromotionType = dal.CreateParameter("PromotionType", promotionTypeId);
                IUniParameter prmPackage = dal.CreateParameter("Package", null);
                return dal.List<PackagePromotion>("PRC_LST_PACKAGEPROMOTION_SP", prmPromotionType, prmPackage).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}