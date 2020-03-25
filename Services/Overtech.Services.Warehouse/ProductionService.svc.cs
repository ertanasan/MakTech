// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Warehouse;
using Overtech.ServiceContracts.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class ProductionService : CRUDLDataService<Overtech.DataModels.Warehouse.Production>, IProductionService
    {
        /*Section="Constructor-1"*/
        public ProductionService()
        {
        }

        /*Section="Constructor-2"*/
        internal ProductionService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<ProductionContent> ListProductionContents(long productionId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmProduction = dal.CreateParameter("Production", productionId);
                return dal.List<ProductionContent>("WHS_LST_PRODUCTIONCONTENT_SP", prmProduction).ToList();
            }
        }

        public IEnumerable<ProductionContent> ListProductionContentswithStocks(long productionId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmProduction = dal.CreateParameter("ProductionId", productionId);
                return dal.List<ProductionContent>("WHS_LST_PRODUCTIONCONTENTSTOCK_SP", prmProduction).ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}