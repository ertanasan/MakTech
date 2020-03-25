// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Core.Application;
using Overtech.Core.Logger;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Warehouse;
using Overtech.ServiceContracts.Warehouse;
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class GatheringService : CRUDLDataService<Overtech.DataModels.Warehouse.Gathering>, IGatheringService
    {
        private ILogger _logger;

        /*Section="Constructor-1"*/
        public GatheringService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(typeof(GatheringService));
        }

        /*Section="Constructor-2"*/
        internal GatheringService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public Overtech.DataModels.Warehouse.Gathering GetPendingGathering(int productGroup)
        {
            try
            {
                using (IDAL dal = this.DAL)
                {
                    Gathering selectedGathering;
                    IUniParameter prmIncomplete = dal.CreateParameter("OnlyIncompleteFlag", "Y");
                    IUniParameter prmGatheringType = dal.CreateParameter("GatheringType", productGroup);
                    IUniParameter prmUser = dal.CreateParameter("User", OTApplication.Context.User.Id);
                    List<Gathering> alreadyAssignedGatherings = dal.List<Gathering>("WHS_LST_GATHERING_SP", prmIncomplete, prmGatheringType, prmUser).ToList();
                    if (alreadyAssignedGatherings.Count() > 0)
                    {
                        selectedGathering = alreadyAssignedGatherings[0];
                    }
                    else
                    {
                        IUniParameter prmGatheringStatus = dal.CreateParameter("GatheringStatus", 1); ;
                        List<Gathering> newGatherings = dal.List<Gathering>("WHS_LST_GATHERING_SP", prmGatheringStatus, prmGatheringType).ToList();
                        if (newGatherings.Count() > 0)
                        {
                            selectedGathering = newGatherings[0];
                        }
                        else
                        {
                            return null;
                        }
                    }
                    return signGatheringAsProcessing(dal, selectedGathering);
                }
            }
            catch (Exception ex)
            {
                _logger.Error($" ServiceName : GatheringService, MethodName : GetPendingGathering, Input : ({productGroup.ToString()}), Exception : {ex.Message}");
                throw;
            }
        }

        private Overtech.DataModels.Warehouse.Gathering signGatheringAsProcessing(IDAL dal, Gathering selectedGathering)
        {
            try
            {
                selectedGathering.GatheringUser = OTApplication.Context.User.Id;
                selectedGathering.GatheringStartTime = DateTime.Now;
                selectedGathering.GatheringStatus = 2;

                dal.BeginTransaction();
                dal.Update<Gathering>(selectedGathering);
                dal.CommitTransaction();

                return selectedGathering;
            }
            catch
            {
                dal.RollbackTransaction();
                throw;
            }
        }

        public int StartGathering(long gatheringId, bool allowReGather)
        {
            using (IDAL dal = this.DAL)
            {
                int errorCode = 0;
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmGatheringId = dal.CreateParameter("GatheringId", gatheringId);
                    IUniParameter prmAllowReControl = dal.CreateParameter("AllowReGather", allowReGather ? "Y" : "N");
                    IUniParameter prmErrorCode = dal.CreateParameter("ErrorCode", 4, System.Data.ParameterDirection.Output, 0);


                    dal.ExecuteNonQuery("WHS_UPD_STARTGATHERING_SP", prmGatheringId, prmAllowReControl, prmErrorCode);
                    dal.CommitTransaction();
                    errorCode = prmErrorCode.Value.To<int>();
                    return errorCode;
                }
                catch (Exception ex)
                {
                    _logger.Error($" ServiceName : GatheringService, MethodName : StartGathering, Input : gatheringId: {gatheringId}, allowReGather: {allowReGather}, Exception : {ex.Message}");
                    dal.RollbackTransaction();
                    return 99;
                }
            }
        }

        public void CompleteGathering(long gatheringId)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    dal.BeginTransaction();
                    Gathering gathering = dal.Read<Gathering>(gatheringId);
                    createGatheringPallet(gathering, dal);
                    gathering.GatheringEndTime = DateTime.Now;
                    gathering.GatheringStatus = 9;
                    dal.Update<Gathering>(gathering);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($" ServiceName : GatheringService, MethodName : CompleteGathering, Input : {gatheringId.ToString()}, Exception : {ex.Message}");
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        private void createGatheringPallet(Gathering gathering, IDAL dal)
        {
            try
            {
                IUniParameter prmGathering = dal.CreateParameter("gatheringId", gathering.GatheringId.ToString());
                List<int> palletArr = dal.List<GatheringDetail>("WHS_LST_GATHERINGDETAIL_SP", prmGathering).Distinct(gd => gd.PalletNo).Select(gd => gd.PalletNo).ToList();

                palletArr.ForEach(pallet => {
                    GatheringPallet gatheringPallet = new GatheringPallet();
                    gatheringPallet.Deleted = false;
                    gatheringPallet.CreateDate = new DateTime();
                    gatheringPallet.CreateUser = OTApplication.Context.User.Id;
                    gatheringPallet.Organization = OTApplication.Context.Organization.Id;
                    gatheringPallet.Gathering = gathering.GatheringId;
                    gatheringPallet.PalletNo = pallet;
                    gatheringPallet.GatheringPalletStatus = 1;

                    dal.Create<GatheringPallet>(gatheringPallet);
                });
            }
            catch (Exception ex)
            {
                _logger.Error($" ServiceName : GatheringService, MethodName : createGatheringPallet, Input : {gathering.GatheringId.ToString()}, Exception : {ex.Message}");
                throw ex;
            }
        }

        public void AbortGathering(long gatheringId)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    dal.BeginTransaction();
                    Gathering gathering = dal.Read<Gathering>(gatheringId);
                    gathering.GatheringStatus = 1;
                    // gathering.Priority = -1;
                    dal.Update<Gathering>(gathering);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($" ServiceName : GatheringService, MethodName : AbortGathering, Input : {gatheringId.ToString()}, Exception : {ex.Message}");
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public GatheringStats GetGatheringPoolStats(string purpose)
        {
            using (IDAL dal = this.DAL)
            {
                var userId = purpose == "forOperation" ? OTApplication.Context.User.Id : -1;  // alternative is "forReporting"
                IUniParameter prmUser = dal.CreateParameter("User", userId);
                return dal.Read<GatheringStats>("WHS_SEL_GATHERINGSTATS_SP", prmUser);
            }
        }

        public void ChangePriority(long gatheringId, int priority)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    Gathering gathering = dal.Read<Gathering>(gatheringId);
                    gathering.Priority = priority;
                    dal.BeginTransaction();
                    dal.Update<Gathering>(gathering);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($" ServiceName : GatheringService, MethodName : ChangePriority, Input : ({gatheringId.ToString()}, {priority.ToString()}), Exception : {ex.Message}");
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public void AssignUserToGathering(long gatheringId, int userId)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    Gathering gathering = dal.Read<Gathering>(gatheringId);
                    gathering.GatheringUser = userId;
                    dal.BeginTransaction();
                    dal.Update<Gathering>(gathering);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($" ServiceName : GatheringService, MethodName : AssignUserToGathering, Input : ({gatheringId.ToString()}, {userId.ToString()}), Exception : {ex.Message}");
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public IEnumerable<Gathering> GetGatheringByStoreOrder(long storeOrderId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreOrder = dal.CreateParameter("StoreOrderId", storeOrderId);
                return dal.List<Gathering>("WHS_LST_GATHERING_SP", prmStoreOrder).ToList();
            }
        }

        public IEnumerable<Gathering> ListByShipmentDate(DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStartDate = dal.CreateParameter("ShipmentStartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("ShipmentEndDate", endDate);
                return dal.List<Gathering>("WHS_LST_GATHERINGBYDATE_SP", prmStartDate, prmEndDate).ToList();
            }
        }

        public IEnumerable<Gathering> ListActiveGatherings(int productGroup, int gatheringStatus)
        {
            using (IDAL dal = this.DAL)
            {
                // IUniParameter prmIncomplete = dal.CreateParameter("OnlyIncompleteFlag", "Y");
                IUniParameter prmGatheringType = dal.CreateParameter("GatheringType", productGroup);
                IUniParameter prmGatheringStatus = dal.CreateParameter("GatheringStatus", gatheringStatus);
                return dal.List<Gathering>("WHS_LST_GATHERING_SP", prmGatheringType, prmGatheringStatus).ToList();
            }
        }

        public IEnumerable<GatheringControlList> GetGatheringControlList(DateTime ShipmentDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmShipmentDate = dal.CreateParameter("ShipmentDate", ShipmentDate);
                return dal.List<GatheringControlList>("WHS_LST_GATHERINGADMIN_SP", prmShipmentDate).ToList();
            }
        }

        public IEnumerable<OrderGathering> ListOrderGathering(long storeOrderId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreOrderId = dal.CreateParameter("StoreOrderId", storeOrderId);
                return dal.List<OrderGathering>("WHS_LST_ORDERGATHERING_SP", prmStoreOrderId).ToList();
            }
        }

        public void TransferGathering(long storeOrderId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmStoreOrderId = dal.CreateParameter("StoreOrderId", storeOrderId);
                    dal.ExecuteNonQuery("WHS_UPD_ORDERGATHERING_SP", prmStoreOrderId);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($" ServiceName : GatheringService, MethodName : TransferGathering, Input : ({storeOrderId.ToString()}), Exception : {ex.Message}");
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public WHDashboard GetDashboardInfo()
        {
            using (IDAL dal = this.DAL)
            {
                DataSet ds = dal.ExecuteDataset("WHS_LST_DASHBOARD_SP");
                WHDashboard d = new WHDashboard();
                d.OrderList = new List<OrderDBList>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    OrderDBList ol = new OrderDBList();
                    ol.StoreOrderId = (long)dr["STOREORDERID"];
                    ol.Store = (int)dr["STORE"];
                    ol.Status = (int)dr["STATUS"];
                    ol.OrderDate = (DateTime)dr["ORDER_DT"];
                    ol.ShipmentDate = (DateTime)dr["SHIPMENT_DT"];
                    ol.OldOrderFlag = (dr["OLDORDER_FL"].ToString() == "Y");
                    ol.OrderWeight = (decimal)dr["ORDERWEIGHT"];
                    ol.HeavyOrderWeight = (decimal)dr["HEAVYORDERWEIGHT"];
                    ol.LightOrderWeight = (decimal)dr["LIGHTORDERWEIGHT"];
                    ol.HeavyGatheredWeight = (decimal)dr["HEAVYGATHEREDWEIGHT"];
                    ol.LightGatheredWeight = (decimal)dr["LIGHTGATHEREDWEIGHT"];
                    ol.WaitingHeavyOrderCount = (int)dr["WAITINGHEAVYORDER_CNT"];
                    ol.WaitingLightOrderCount = (int)dr["WAITINGLIGHTORDER_CNT"];
                    ol.WaitingHeavyControlPalletCount = (int)dr["WAITINGHEAVYCONTROLPALLET_CNT"];
                    ol.WaitingLightControlPalletCount = (int)dr["WAITINGLIGHTCONTROLPALLET_CNT"];
                    ol.OrderPrice = (decimal)dr["ORDERPRICE"];
                    d.OrderList.Add(ol);
                }
                    

                d.GatheringList = new List<GatheringDBList>();
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    GatheringDBList gl = new GatheringDBList();
                    gl.GatheringUserName = dr["USERFULL_NM"].ToString();
                    gl.GatheringType = (int)dr["GATHERINGTYPE"];
                    gl.GatheredPalletCount = (int)dr["GATHEREDPALLET_CNT"];
                    gl.GatheredWeight = (decimal)dr["GATHEREDWEIGHT"];
                    gl.OrderCount = (int)dr["ORDER_CNT"];
                    gl.GatheredPackage = (decimal)dr["GATHEREDPACKAGE_QTY"];
                    d.GatheringList.Add(gl);
                }

                d.ControlList = new List<ControlDBList>();
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    ControlDBList cl = new ControlDBList();
                    cl.ControlUserName = dr["USERFULL_NM"].ToString();
                    cl.GatheringType = (int)dr["GATHERINGTYPE"];
                    cl.ControlUser = (int)dr["CONTROLUSER"];
                    cl.ControlPalletCount = (int)dr["CONTROLPALLET_CNT"];
                    cl.ControlledPalletCount = (int)dr["CONTROLLEDPALLET_CNT"];
                    d.ControlList.Add(cl);
                }

                return d;

            }
        }

        public DataTable DashboardHourGathering()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("WHS_LST_DBOARDHOURGATHERING_SP").Tables[0];
            }
        }

        public WDashboardOrder GetWDashboardOrderInfo()
        {
            using (IDAL dal = this.DAL)
            {
                WDashboardOrder wdo = new WDashboardOrder();

                wdo.WidgetData = getWDWidgetData(dal, null);
                wdo.GatheringDifferences = listWDGatheringDifference(dal, null);
                wdo.OrderTrend = listOrderTrend(dal);

                return wdo;
            }
        }

        private WDWidgetData getWDWidgetData(IDAL dal, Nullable<DateTime> gatheringDate)
        {
            IUniParameter prmGatheringDate = dal.CreateParameter("GatheringDate", gatheringDate.HasValue ? gatheringDate : null);
            return dal.Read<WDWidgetData>("WHS_SEL_WDORDERWIDGET_SP", prmGatheringDate);
        }

        private IList<WDGatheringDifference> listWDGatheringDifference(IDAL dal, Nullable<DateTime> gatheringDate)
        {
            IUniParameter prmGatheringDate = dal.CreateParameter("GatheringDate", gatheringDate.HasValue ? gatheringDate : null);
            return dal.List<WDGatheringDifference>("WHS_LST_WDGATHERINGDIFF_SP", prmGatheringDate).ToList();
        }

        private IList<OrderTrend> listOrderTrend(IDAL dal, string trendDataType = "Amount", int dayCount = 30)
        {
            IUniParameter prmTrendDataType = dal.CreateParameter("TrendDataType", trendDataType);
            IUniParameter prmDayCount = dal.CreateParameter("DayCount", dayCount);
            return dal.List<OrderTrend>("WHS_LST_WDORDERTREND_SP", prmTrendDataType, prmDayCount).ToList();
        }

        public IEnumerable<OrderTrend> WDOrderTrendData(string trendDataType, int dayCount)
        {
            using (IDAL dal = this.DAL)
            {
                return listOrderTrend(dal, trendDataType, dayCount);
            }
        }

        public WDashboardGathering GetWDashboardGatheringInfo(int gatheringType)
        {
            using (IDAL dal = this.DAL)
            {
                WDashboardGathering wdg = new WDashboardGathering();

                wdg.WidgetData = getWDGatherPerformanceSummary(dal, gatheringType);
                wdg.GatheringTrend = listWDGatheringTrend(dal, gatheringType);

                return wdg;
            }
        }

        private WDGatherPerformanceSummary getWDGatherPerformanceSummary(IDAL dal, int gatheringType)
        {
            IUniParameter prmGatheringType = dal.CreateParameter("GatheringType", gatheringType);
            return dal.Read<WDGatherPerformanceSummary>("WHS_SEL_WDGATHERPERFORMANCESUMMARY_SP", prmGatheringType);
        }

        private IEnumerable<WDGatheringTrend> listWDGatheringTrend(IDAL dal, int gatheringType, int trendDataType = 1, int dayCount = 30, int gatheringUserId = -1)
        {
            IUniParameter prmGatheringType = dal.CreateParameter("GatheringType", gatheringType);
            IUniParameter prmTrendDataType = dal.CreateParameter("TrendDataType", trendDataType);
            IUniParameter prmDayCount = dal.CreateParameter("DayCount", dayCount);
            IUniParameter prmGatheringUserId = dal.CreateParameter("GatheringUserId", gatheringUserId);
            return dal.List<WDGatheringTrend>("WHS_LST_WDGATHERINGTREND_SP", prmGatheringType, prmTrendDataType, prmDayCount, prmGatheringUserId).ToList();
        }

        public IEnumerable<WDGatheringTrend> WDGatheringTrendData(int gatheringType, int trendDataType, int dayCount, int gatheringUserId)
        {
            using (IDAL dal = this.DAL)
            {
                return listWDGatheringTrend(dal, gatheringType, trendDataType, dayCount, gatheringUserId);
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}