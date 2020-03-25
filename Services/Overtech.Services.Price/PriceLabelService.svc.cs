// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;
using Overtech.Mutual.Store;
using Overtech.DataModels.Store;
using Overtech.Core.Data;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Price;
using Overtech.ServiceContracts.Price;
using Overtech.Core.Application;
using Overtech.Core.Logger;
using System.Data;




/*Section="ClassHeader"*/
namespace Overtech.Services.Price
{
    [OTInspectorBehavior]
    public class PriceLabelService : CRUDLDataService<Overtech.DataModels.Price.LabelPrice>, IPriceLabelService
    {
        private ILogger _logger;
        public PriceLabelService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(typeof(ProductPriceService));
        }

        /*Section="Constructor-1"*/
        public PriceLabelService()
        {
        }

        /*Section="Constructor-2"*/
        internal PriceLabelService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        //public IEnumerable<PriceVersion> ListPriceVersions()
        //{
        //    using (IDAL dal = this.DAL)
        //    {
        //        StoreOperations storeOperations = new StoreOperations(dal);
        //        Store store = storeOperations.getBranch(OTApplication.Context.Branch.Id);

        //        IUniParameter prmStore = dal.CreateParameter("StoreID", store.StoreId);
        //        var result = dal.List<PriceVersion>("PRC_LST_PRICEVERSIONS_SP", prmStore).ToList();
        //        return result;
        //    }
        //}
        public IEnumerable<LabelPrice> ListPriceLabel()
        {
            using (IDAL dal = this.DAL)
            {
                StoreOperations storeOperations = new StoreOperations(dal);
                Store store = storeOperations.getStore(OTApplication.Context.Branch.Id);
                IUniParameter prmStore = dal.CreateParameter("StoreID", store.StoreId);

                var result = dal.List<LabelPrice>("PRC_LST_PRICELABEL_SP", prmStore/*, prmPackageVersionID*/).ToList();
                return result;
            }
        }
        public IEnumerable<int> ListPriceLabelChecked(string pS)
        {
            using (IDAL dal = this.DAL)
            {
                StoreOperations storeOperations = new StoreOperations(dal);
                Store store = storeOperations.getStore(OTApplication.Context.Branch.Id);
                IUniParameter prmStore = dal.CreateParameter("StoreID", store.StoreId);
                IUniParameter prmSize = dal.CreateParameter("PSIZE", pS);
                return dal.RetrieveAll<int>("PRC_LST_PRICECHECKEDLABEL_SP", prmStore, prmSize).ToList();
                
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}