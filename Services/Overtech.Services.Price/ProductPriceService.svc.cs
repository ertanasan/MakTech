// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Price;
using Overtech.ServiceContracts.Price;
using Overtech.Core.Logger;
using Overtech.Core.Application;
using Overtech.DataModels.Organization;
using System.Data;


/*Section="ClassHeader"*/
namespace Overtech.Services.Price
{
    [OTInspectorBehavior]
    public class ProductPriceService : CRUDLDataService<Overtech.DataModels.Price.ProductPrice>, IProductPriceService
    {
        /*Section="Constructor-1"*/
        private ILogger _logger;
        public ProductPriceService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(typeof(ProductPriceService));
        }

        /*Section="Constructor-2"*/
        internal ProductPriceService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Price.ProductPrice Find(string productPriceId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmProductPriceId = dal.CreateParameter("ProductPriceId", productPriceId);
                return dal.Read<Overtech.DataModels.Price.ProductPrice>("PRC_SEL_FINDPRODUCT_SP", prmProductPriceId);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<Overtech.DataModels.Price.ProductPrice> GetPackagePrices(int packageId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmPackageId = dal.CreateParameter("PackageId", packageId);
                return dal.List<Overtech.DataModels.Price.ProductPrice>("PRC_LST_PACKAGEPRICES_SP", prmPackageId).ToList();
            }
        }

        private long getLastPackageVersion(long packageId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmPackageId = dal.CreateParameter("PackageId", packageId);
                DataTable dt = dal.ExecuteDataset("PRC_SEL_LASTPACKAGEVERSION_SP", prmPackageId).Tables[0];
                var isNumeric = int.TryParse(dt.Rows[0][0].ToString(), out int n);
                if (isNumeric)
                {
                    return long.Parse(dt.Rows[0][0].ToString());
                }
                else
                    return -1;
            }
        }

        public void updatePackagePrices(IEnumerable<ProductPrice> productPrices )
        {
            // paket altındaki son versiyonu al
            var firstItem = productPrices.First();
            long packageId = firstItem.Package;
            long versionId = -1;
            long lastversionId = getLastPackageVersion(packageId);

            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    PackageVersion pv = null;
                    // versiyon varsa değerleri oku 
                    if (lastversionId != -1)
                    {
                        pv = dal.Read<PackageVersion>(lastversionId);
                        versionId = pv.PackageVersionId;
                    }
                    // son versiyon aktifse veya versiyon yoksa yeni bir versiyon create et
                    if ((pv != null && pv.ActiveFlag) || lastversionId == -1)
                    {
                        pv = new PackageVersion
                        {
                            Package = packageId,
                            VersionDate = DateTime.Now,
                            ActiveFlag = false
                        };
                        versionId = dal.Create(pv);
                    }
                        
                    // fiyatları güncelle.
                    foreach(ProductPrice p in productPrices)
                    {
                        p.PackageVersion = versionId;
                        IUniParameter prmProductPriceId = dal.CreateParameter("ProductPriceId", p.ProductPriceId);
                        IUniParameter prmPriceAmount = dal.CreateParameter("PriceAmount", p.PriceAmount);
                        IUniParameter prmProduct = dal.CreateParameter("Product", p.Product);
                        IUniParameter prmPackage = dal.CreateParameter("Package", p.Package);
                        IUniParameter prmTopPriceAmount = dal.CreateParameter("TopPriceAmount", p.TopPriceAmount);
                        IUniParameter prmPrintTopPriceFlag = dal.CreateParameter("PrintTopPriceFlag", p.PrintTopPriceFlag);
                        IUniParameter prmPackageVersion = dal.CreateParameter("PackageVersion", p.PackageVersion);
                        IUniParameter prmCurrentPriceAmount = dal.CreateParameter("CurrentPriceAmount", p.CurrentPriceAmount);
                        IUniParameter prmPackageProduct = dal.CreateParameter("PackageProduct", p.PackageProduct);
                        dal.ExecuteNonQuery("PRC_UPD_PRODUCTPRICES_SP", prmProductPriceId, prmPriceAmount
                            , prmProduct, prmPackage, prmTopPriceAmount, prmPrintTopPriceFlag, prmPackageVersion
                            , prmCurrentPriceAmount, prmPackageProduct);
                        
                    }

                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($"updatePackagePrices Error : {ex.ToString()}");
                    dal.RollbackTransaction();
                    throw ex;
                }

            }
        }
        
        /// <summary>
        /// Kasa ve terazilere gönderilecek fiyatları getirir.
        /// </summary>
        /// <param name="groupCode">1 ise kasa, 2 ise terazi</param>
        /// <param name="storeId">hangi mağaza için olduğu wincor kasalar için -1 gönderilir.</param>
        /// <param name="wincor">wincor kasalar için 1 gönderilir, bu durumda diğer parametrelerin önemi olmaz</param>
        /// <returns></returns>
        public IEnumerable<ProductPrice> getNewPrices(int groupCode, int storeId, int wincor)
        {
            IEnumerable<ProductPrice> pp;

            using (IDAL dal = this.DAL)
            {
                try
                {
                    dal.BeginTransaction();
                    IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                    IUniParameter prmGroupCode = dal.CreateParameter("GroupCode", groupCode);
                    IUniParameter prmWincor = dal.CreateParameter("Wincor", wincor);

                    pp = dal.List<ProductPrice>("PRC_LST_NEWPRICES_SP", prmGroupCode, prmStoreId, prmWincor).ToList();
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($"getNewPrices Error : {ex.ToString()}");
                    // dal.RollbackTransaction();
                    throw ex;
                }
            }

            return pp;
        }

        public DataTable PriceLoadStatus()
        {
            using (IDAL dal = this.DAL)
            {
                DataTable dt = dal.ExecuteDataset("PRC_LST_PRICELOADSTATUS_SP").Tables[0];
                return dt;
            }
        }

        public DataTable GetDeListProducts()
        {
            using (IDAL dal = this.DAL)
            {
                DataTable dt = dal.ExecuteDataset("PRC_LST_DELISTPRODUCTS_SP").Tables[0];
                return dt;
            }
        }

        public IEnumerable<Tuple<int, string>> ListPriceVersions()
        {
            using (IDAL dal = this.DAL)
            {
                long branchId = OTApplication.Context.Branch.Id;
                Branch branch = dal.Read<Branch>(branchId);

                IUniParameter prmStore = dal.CreateParameter("Store", branch.Name);
                var result = dal.RetrieveAll<Tuple<int, string>>("PRC_LST_PRICEVERSIONS_SP", prmStore).ToList();
                return result;
            }
        }

        public DataTable ListSalesByPriceGroups(long storeId, long productId, DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("Store", storeId);
                IUniParameter prmProductId = dal.CreateParameter("Product", productId);
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);

                return dal.ExecuteDataset("PRC_LST_PRICESALEBYPRICEGROUPS_SP", prmStoreId, prmProductId, prmStartDate, prmEndDate).Tables[0];
            }
        }

        public DataTable ListSalesTrendWithPriceChanges(long? storeId, long productId, DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("Store", storeId);
                IUniParameter prmProductId = dal.CreateParameter("Product", productId);
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);

                return dal.ExecuteDataset("PRC_LST_PRICESALESTREND_SP", prmStoreId, prmProductId, prmStartDate, prmEndDate).Tables[0];
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}