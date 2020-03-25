// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Store;
using Overtech.DataModels.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Warehouse
{
    [ServiceContract]
    public interface IStockTakingScheduleService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.StockTakingSchedule>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized

        [OperationContract]
        IEnumerable<StockTakingSchedule> ActiveSchedules();

        [OperationContract]
        IEnumerable<StockTakingSchedule> ActiveStoreSchedules(long storeId);

        [OperationContract]
        IEnumerable<Store> CountedStores();

        [OperationContract]
        DataTable DrillCountPerformance();

        [OperationContract]
        DataTable DrillCountPerformanceDetail(int StoreId);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

