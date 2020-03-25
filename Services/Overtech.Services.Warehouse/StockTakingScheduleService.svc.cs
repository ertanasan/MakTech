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
using Overtech.DataModels.Store;
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class StockTakingScheduleService : CRUDLDataService<Overtech.DataModels.Warehouse.StockTakingSchedule>, IStockTakingScheduleService
    {
        /*Section="Constructor-1"*/
        public StockTakingScheduleService()
        {
        }

        /*Section="Constructor-2"*/
        internal StockTakingScheduleService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<StockTakingSchedule> ActiveSchedules()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<StockTakingSchedule>("WHS_LST_SCHEDULES_SP").ToList();
            }
        }

        public IEnumerable<StockTakingSchedule> ActiveStoreSchedules(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                return dal.List<StockTakingSchedule>("WHS_LST_STORESCHEDULES_SP", prmStoreId).ToList();
            }
        }

        public IEnumerable<Store> CountedStores()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<Store>("WHS_LST_COUNTEDSTORES_SP").ToList();
            }
        }

        public DataTable DrillCountPerformance()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("WHS_RPT_DRILLCOUNTPERF_SP").Tables[0];
            }
        }

        public DataTable DrillCountPerformanceDetail(int StoreId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", StoreId);
                return dal.ExecuteDataset("WHS_RPT_DRILLCOUNTPERFDETAIL_SP", prmStoreId).Tables[0];
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}