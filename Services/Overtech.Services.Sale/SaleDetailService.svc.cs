// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Sale;
using Overtech.ServiceContracts.Sale;
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.Services.Sale
{
    [OTInspectorBehavior]
    public class SaleDetailService : CRUDLDataService<Overtech.DataModels.Sale.SaleDetail>, ISaleDetailService
    {
        /*Section="Constructor-1"*/
        public SaleDetailService()
        {
        }

        /*Section="Constructor-2"*/
        internal SaleDetailService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<SaleDetail> ListSaleDetail(long saleId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmSaleId = dal.CreateParameter("SaleId", saleId);
                IEnumerable<SaleDetail> sale = dal.List<SaleDetail>("SLS_LST_SALEDETAIL_SP", prmSaleId).ToList();
                return sale;
            }
        }

        public DataTable GetCancelDetailData(DateTime prm_start,DateTime prm_end)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter start = dal.CreateParameter("StartDate", prm_start);
                IUniParameter end = dal.CreateParameter("EndDate", prm_end);
                return dal.ExecuteDataset("SLS_LST_STORECANCELRATE_SP", start, end).Tables[0];
            }
        }

        public DataTable GetCancelData(DateTime prm_start, DateTime prm_end, int prm_storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter start = dal.CreateParameter("StartDate", prm_start);
                IUniParameter end = dal.CreateParameter("EndDate", prm_end);
                IUniParameter storeId = dal.CreateParameter("StoreId", prm_storeId);
                return dal.ExecuteDataset("SLS_LST_STORECANCELDETAIL_SP", start, end, storeId).Tables[0];
            }
        }

        public DataTable WeeklyCancels(DateTime prm_start, DateTime prm_end)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter start = dal.CreateParameter("StartDate", prm_start);
                IUniParameter end = dal.CreateParameter("EndDate", prm_end);
                return dal.ExecuteDataset("SLS_LST_WEEKLYCANCEL_SP", start, end).Tables[0];
            }

        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}