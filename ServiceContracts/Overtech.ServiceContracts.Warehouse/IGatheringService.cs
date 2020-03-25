// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Warehouse
{
    [ServiceContract]
    public interface IGatheringService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.Gathering>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        Overtech.DataModels.Warehouse.Gathering GetPendingGathering(int productGroup);

        [OperationContract]
        GatheringStats GetGatheringPoolStats(string purpose);

        [OperationContract]
        int StartGathering(long gatheringId, bool allowReGather);

        [OperationContract]
        void CompleteGathering(long gatheringId);

        [OperationContract]
        void AbortGathering(long gatheringId);

        [OperationContract]
        IEnumerable<Gathering> GetGatheringByStoreOrder(long storeOrderId);

        [OperationContract]
        IEnumerable<Gathering> ListByShipmentDate(DateTime startDate, DateTime endDate);

        [OperationContract]
        IEnumerable<Gathering> ListActiveGatherings(int productGroup, int gatheringStatus);

        [OperationContract]
        IEnumerable<GatheringControlList> GetGatheringControlList(DateTime ShipmentDate);


        [OperationContract]
        IEnumerable<OrderGathering> ListOrderGathering(long storeOrderId);

        [OperationContract]
        void TransferGathering(long storeOrderId);

        [OperationContract]
        WHDashboard GetDashboardInfo();

        [OperationContract]
        DataTable DashboardHourGathering();

        [OperationContract]
        WDashboardOrder GetWDashboardOrderInfo();

        [OperationContract]
        IEnumerable<OrderTrend> WDOrderTrendData(string trendDataType, int dayCount);

        [OperationContract]
        WDashboardGathering GetWDashboardGatheringInfo(int gatheringType);

        [OperationContract]
        IEnumerable<WDGatheringTrend> WDGatheringTrendData(int gatheringType, int trendDataType, int dayCount, int gatheringUserId);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

