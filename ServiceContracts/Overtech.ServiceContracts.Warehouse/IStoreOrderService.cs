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
    public interface IStoreOrderService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.StoreOrder>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        DateTime getShipmentDay(long storeId);

        [OperationContract]
        void Dispatch(StoreOrder dataObject);

        [OperationContract]
        StoreOrder getOrderofDay(long storeId, DateTime shipmentDay);

        [OperationContract]
        DataTable ListOrderSaleProductDetails(long storeId, DateTime startDate, DateTime endDate);

        [OperationContract]
        DataTable ListOrderSaleDateDetails(long storeId, long productId, DateTime startDate, DateTime endDate);

        [OperationContract]
        DataTable ListOrderSaleStoreDetails(long productId, DateTime startDate, DateTime endDate);

        [OperationContract]
        DataSet ConstraintTheory(long storeId, long productId, DateTime startDate, DateTime endDate, decimal startBuffer, decimal shipmenUnit,
                int greenCycle, decimal bufferBandwith, bool ceiling);

        [OperationContract]
        DataTable TopSaleDayGroup(long storeId, long productId, DateTime startDate, DateTime endDate);

        [OperationContract]
        IEnumerable<StoreOrder> ListOrders(string includeCompletedOrders, DateTime baseDate);

        [OperationContract]
        IEnumerable<StoreOrderDetail> MikroShipmentControl(long storeOrderId);

        [OperationContract]
        void AddProductsFromExcel(byte[] formData, long storeOrderId);

        [OperationContract]
        IEnumerable<Store> NoOrderStoreList();

        [OperationContract]
        DataTable GetWaybillInfo(long StoreOrderId);

        [OperationContract]
        DataSet StockDashboard();

        [OperationContract]
        DataSet StockDashboardTrend(string categoryName, string productName, string storeName);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

