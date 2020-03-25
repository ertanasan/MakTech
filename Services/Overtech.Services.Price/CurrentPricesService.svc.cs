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
    public class CurrentPricesService : CRUDLDataService<Overtech.DataModels.Price.CurrentPrices>, ICurrentPricesService
    {
        /*Section="Constructor-1"*/
        public CurrentPricesService()
        {
        }

        /*Section="Constructor-2"*/
        internal CurrentPricesService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<CurrentPrices> ListStoreCurrentPrices(int storeId, int groupCode)
        {
            IEnumerable<CurrentPrices> pp;

            using (IDAL dal = this.DAL)
            {
                try
                {
                    IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                    IUniParameter prmGroupCode = dal.CreateParameter("GroupCode", groupCode);

                    pp = dal.List<CurrentPrices>("PRC_LST_STORECURRENTPRICE_SP", prmGroupCode, prmStoreId).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return pp;
        }

        public IEnumerable<PriceChangeHistory> ListPriceChanges()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<PriceChangeHistory>("PRC_LST_PRICECHANGE_SP").ToList();
            }
        }

        public void CheckedPricesChangesAsNotified(IEnumerable<PriceChangeHistory> priceChangesForStore)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    foreach (PriceChangeHistory p in priceChangesForStore)
                    {
                        IUniParameter prmId = dal.CreateParameter("PriceChangeHistoryId", p.PriceChangeHistoryId);
                        dal.ExecuteNonQuery("PRC_UPD_PRICECHANGE_SP", prmId);
                    }
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public CurrentPrices GetCurrentPriceByProductCode(string productCode)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmCode = dal.CreateParameter("ProductCode", productCode);
                return dal.Read<CurrentPrices>("PRC_SEL_CURRENTPRICEBYCODE_SP", prmCode);
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}