// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Price;
using Overtech.ServiceContracts.Price;

/*Section="ClassHeader"*/
namespace Overtech.Services.Price
{
    [OTInspectorBehavior]
    public class PriceLabelPrintService : CRUDLDataService<Overtech.DataModels.Price.PriceLabelPrint>, IPriceLabelPrintService
    {
        /*Section="Constructor-1"*/
        public PriceLabelPrintService()
        {
        }

        /*Section="Constructor-2"*/
        internal PriceLabelPrintService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public void InsertPrintedLabels(IEnumerable<Overtech.DataModels.Price.PriceLabelPrint> printedLabels)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    dal.BeginTransaction();
                   foreach (PriceLabelPrint label in printedLabels)
                    {
                        dal.Create<PriceLabelPrint>(label);
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

        public DataTable ListPrintedLabels()
        {
            using (IDAL dal = this.DAL)
            {
                //IUniParameter prmProductPriceId = dal.CreateParameter("ProductPriceId", productPriceId);

                return dal.ExecuteDataset("PRC_LST_PRINTEDLABES_SP").Tables[0];
            }
        }

        public DataTable ListPrintedLabelDetailsByStore(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("Store", storeId);
                return dal.ExecuteDataset("PRC_LST_PRINTEDLABELDETAILS_SP", prmStoreId).Tables[0];
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}