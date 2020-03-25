// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Core.Logger;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Warehouse;
using Overtech.ServiceContracts.Warehouse;
using System.Data;
using Overtech.Core.Application;
using Overtech.Mutual.Warehouse;
using Overtech.DataModels.Store;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class StoreOrderService : CRUDLDataService<Overtech.DataModels.Warehouse.StoreOrder>, IStoreOrderService
    {
        private ILogger _logger;
        IGatheringService _gatheringService;

        /*Section="Constructor-1", IsCustomized=true*/
        public StoreOrderService(ILoggerFactory loggerFactory, IGatheringService gatheringService)
        {
            _logger = loggerFactory.GetLogger(typeof(StoreOrderService));
            this._gatheringService = gatheringService;
        }

        /*Section="Constructor-2"*/
        internal StoreOrderService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public override StoreOrder Create(StoreOrder dataObject)
        {
            dataObject.Organization = OTApplication.Context.Organization.Id;
            return base.Create(dataObject);
        }

        public DateTime getShipmentDay(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                DataSet ds = dal.ExecuteDataset("WHS_SEL_SHIPMENTDAY_SP", prmStoreId);
                return (DateTime)ds.Tables[0].Rows[0][0];
            }
        }

        public void Dispatch(StoreOrder dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    dal.Update(dataObject);
                    IUniParameter prmStoreOrderId = dal.CreateParameter("StoreOrderId", dataObject.StoreOrderId);
                    dal.ExecuteNonQuery("WHS_INS_WAYBILL_SP", prmStoreOrderId);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public StoreOrder getOrderofDay(long storeId, DateTime shipmentDay)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmShipmentDay = dal.CreateParameter("Day", shipmentDay);
                IEnumerable<StoreOrder> orders = dal.List<StoreOrder>("WHS_SEL_ORDEROFDAY_SP", prmStoreId, prmShipmentDay).ToList();
                if (orders.Count() > 0)
                    return orders.First<StoreOrder>();
                else
                    return null;
            }
        }

        public DataTable ListOrderSaleProductDetails(long storeId, DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);

                return dal.ExecuteDataset("WHS_LST_ORDERSALEPRODUCTDET_SP", prmStoreId, prmStartDate, prmEndDate).Tables[0];
            }
        }

        public DataTable ListOrderSaleDateDetails(long storeId, long productId, DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmProductId = dal.CreateParameter("ProductId", productId);
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);

                return dal.ExecuteDataset("WHS_LST_ORDERSALEDATEDET_SP", prmStoreId, prmProductId, prmStartDate, prmEndDate).Tables[0];
            }
        }

        public DataTable ListOrderSaleStoreDetails(long productId, DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmProductId = dal.CreateParameter("ProductId", productId);
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);

                return dal.ExecuteDataset("WHS_LST_ORDERSALESTOREDET_SP", prmProductId, prmStartDate, prmEndDate).Tables[0];
            }
        }

        public DataSet ConstraintTheory(long storeId, long productId, DateTime startDate, DateTime endDate, decimal startBuffer, decimal shipmenUnit,
                int greenCycle, decimal bufferBandwith, bool ceiling)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmProductId = dal.CreateParameter("ProductId", productId);
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                IUniParameter prmStartBuffer = dal.CreateParameter("StartBuffer", startBuffer);
                IUniParameter prmUnit = dal.CreateParameter("Unit", shipmenUnit);
                IUniParameter prmGreenCycle = dal.CreateParameter("GreenCycleLength", greenCycle);
                IUniParameter prmBufferBandwith = dal.CreateParameter("BufferBandwith", bufferBandwith);
                IUniParameter prmCeiling = dal.CreateParameter("Ceiling", ceiling ? 1 : 0);

                return dal.ExecuteDataset("WHS_LST_CONSTRAINTSTHEORY_SP", prmStoreId, prmProductId, prmStartDate, prmEndDate,
                    prmStartBuffer, prmUnit, prmGreenCycle, prmBufferBandwith, prmCeiling);
            }
        }

        public DataTable TopSaleDayGroup(long storeId, long productId, DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmProductId = dal.CreateParameter("ProductId", productId);
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);

                return dal.ExecuteDataset("WHS_LST_TOPSALEDAYGROUP_SP", prmStoreId, prmProductId, prmStartDate, prmEndDate).Tables[0];
            }
        }

        public IEnumerable<StoreOrder> ListOrders(string includeCompletedOrders, DateTime baseDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmAllRecords = dal.CreateParameter("AllRecords", includeCompletedOrders);
                IUniParameter prmBaseDate = dal.CreateParameter("BaseDate", baseDate);

                return dal.List<StoreOrder>("WHS_LST_STOREORDER_SP", prmAllRecords, prmBaseDate).ToList();
            }
        }

        public IEnumerable<StoreOrderDetail> MikroShipmentControl(long storeOrderId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreOrderId = dal.CreateParameter("StoreOrderId", storeOrderId);
                return dal.List<StoreOrderDetail>("WHS_LST_MIKROSHIPMENTCONTROL_SP", prmStoreOrderId).ToList();
            }
        }

        public void AddProductsFromExcel(byte[] formData, long storeOrderId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    OrderOperations Oop = new OrderOperations(dal);
                    Oop.AddProductsFromExcel(formData, storeOrderId);
                    dal.CommitTransaction();
                } catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public override void Update(StoreOrder dataObject)
        {
            if (dataObject.Status == 3)
            {
                using (IDAL dal = this.DAL)
                {
                    dal.BeginTransaction();
                    try
                    {
                        dal.Update<StoreOrder>(dataObject);
                        IUniParameter prmStoreOrderId = dal.CreateParameter("StoreOrderId", dataObject.StoreOrderId);
                        dal.ExecuteNonQuery("WHS_INS_GATHERINGFROMORDER_SP", prmStoreOrderId);
                        dal.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        dal.RollbackTransaction();
                        _logger.Error($" ServiceName : StoreOrderService, MethodName : Update, Input : ({Newtonsoft.Json.JsonConvert.SerializeObject(dataObject)}, Exception : {ex.Message}");
                        throw;
                    }
                }
            }
            else
            {
                base.Update(dataObject);
            }
        }

        private void createGatheringForStoreOrder(long storeOrderId, IDAL dal)
        {
            try
            {
                // SEARCHING EXISTING RECORDS FOR THE STOREORDERID
                IUniParameter prmStoreOrderId = dal.CreateParameter("StoreOrderId", storeOrderId);
                IEnumerable<Gathering> existingGatherings = dal.List<Gathering>("WHS_LST_GATHERING_SP", prmStoreOrderId).ToList();
                if (existingGatherings.Count() > 0)
                {
                    try
                    {
                        foreach (Gathering g in existingGatherings)
                        {
                            dal.Delete<Gathering>(g.GatheringId);
                        }
                    }
                    catch
                    {
                        _logger.Error($" ServiceName : StoreOrderService, MethodName : createGatheringForStoreOrder, Input : ({storeOrderId.ToString()}, Exception : Gathering Deletion Transaction Failed");
                        throw new Exception("Gathering Deletion Transaction Failed");
                    }
                }

                // GET PRODUCTS OF THE STOREORDER AND DIVIDE IT INTO HEAVY/LIGHT GROUPS
                IEnumerable<StoreOrderDetail> orderDetails = dal.List<StoreOrderDetail>("WHS_LST_STOREORDERDETAIL_SP", prmStoreOrderId).Where(od => (od.StoreOrderDetailId != 0) && (od.RevisedQuantity > 0)).ToList();
                IEnumerable<StoreOrderDetail> heavyProducts = orderDetails.Where(od => od.LoadOrder != null && od.LoadOrder.StartsWith("A"));
                //_logger.Debug($" ServiceName : StoreOrderService, MethodName : createGatheringForStoreOrder, Input : {storeOrderId} heavyProducts Output : {Newtonsoft.Json.JsonConvert.SerializeObject(heavyProducts)}");
                IEnumerable<StoreOrderDetail> lightProducts = orderDetails.Where(od => od.LoadOrder == null || !od.LoadOrder.StartsWith("A"));
                //_logger.Debug($" ServiceName : StoreOrderService, MethodName : createGatheringForStoreOrder, Input : {storeOrderId} lightProducts Output : {Newtonsoft.Json.JsonConvert.SerializeObject(lightProducts)}");

                // PREPARE GATHERING MODEL
                Gathering newGathering = new Gathering();
                newGathering.Event = 1047;
                newGathering.Organization = 1;
                newGathering.StoreOrder = storeOrderId;
                newGathering.GatheringStatus = 1;
                newGathering.Priority = 0;

                GatheringDetail gatheringDetail = new GatheringDetail();
                gatheringDetail.Event = 1047;
                gatheringDetail.Organization = 1;
                gatheringDetail.PalletNo = 1;

                // CREATE GATHERING AND DETAIL RECORDS FOR HEAVY PRODUCTS

                if (heavyProducts.Count() > 0)
                {
                    try
                    {
                        newGathering.GatheringType = 1;
                        long gatheringId = dal.Create<Gathering>(newGathering);
                        gatheringDetail.Gathering = gatheringId;

                        foreach (StoreOrderDetail hp in heavyProducts)
                        {
                            gatheringDetail.StoreOrderDetail = hp.StoreOrderDetailId;
                            dal.Create<GatheringDetail>(gatheringDetail);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($" ServiceName : StoreOrderService, MethodName : createGatheringForStoreOrder, Input : ({storeOrderId.ToString()}, Exception : Gathering For HeavyProducts Creation Failed, {ex.ToString()}");
                        new Exception("Gathering For HeavyProducts Creation Failed");
                    }
                }

                // CREATE GATHERING AND DETAIL RECORDS FOR LIGHT PRODUCTS
                if (lightProducts.Count() > 0)
                {
                    try
                    {
                        newGathering.GatheringType = 2;
                        long gatheringId = dal.Create<Gathering>(newGathering);
                        gatheringDetail.Gathering = gatheringId;

                        foreach (StoreOrderDetail lp in lightProducts)
                        {
                            gatheringDetail.StoreOrderDetail = lp.StoreOrderDetailId;
                            dal.Create<GatheringDetail>(gatheringDetail);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($" ServiceName : StoreOrderService, MethodName : createGatheringForStoreOrder, Input : ({storeOrderId.ToString()}, Exception : Gathering For LightProducts Creation Failed, {ex.ToString()}");
                        new Exception("Gathering For LightProducts Creation Failed");
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.Error($" ServiceName : StoreOrderService, MethodName : createGatheringForStoreOrder, Input : ({storeOrderId.ToString()}, Exception : {ex.ToString()}");
                throw ex;
            }
        }

        public IEnumerable<Store> NoOrderStoreList()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<Store>("WHS_LST_NOORDERSTORES_SP").ToList();
            }
        }

        public DataTable GetWaybillInfo(long StoreOrderId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreOrderId = dal.CreateParameter("StoreOrderId", StoreOrderId);
                return dal.ExecuteDataset("WHS_LST_WAYBILL_SP", prmStoreOrderId).Tables[0];
            }
        }

        public DataSet StockDashboard()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("INV_LST_STOCKDASHBOARD_SP");
            }
        }

        public DataSet StockDashboardTrend(string categoryName, string productName, string storeName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmCategoryName = dal.CreateParameter("CategoryName", categoryName);
                IUniParameter prmProductName = dal.CreateParameter("ProductName", productName);
                IUniParameter prmStoreName = dal.CreateParameter("StoreName", storeName);
                return dal.ExecuteDataset("INV_LST_STOCKDASHBOARDTREND_SP", prmCategoryName, prmProductName, prmStoreName);
            }
        }
        
        #endregion Customized
        /*Section="ClassFooter"*/
    }           
}