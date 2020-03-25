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
using Overtech.DataModels.Product;
using System.Data;
using Overtech.Core.Logger;
using Overtech.Mutual.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class StockTakingService : CRUDLDataService<Overtech.DataModels.Warehouse.StockTaking>, IStockTakingService
    {
        /*Section="Constructor-1"*/
        private ILogger _logger;

        public StockTakingService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(typeof(StockTakingService));
        }

        /*Section="Constructor-2"*/
        internal StockTakingService(IDAL dal)
            : base(dal)
        {
        }


        /*Section="CustomCodeRegion"*/
        #region Customized
        public override StockTaking Create(StockTaking dataObject)
        {
            try
            {
                return base.Create(dataObject);
            }
            catch (Exception ex)
            {
                _logger.Error($" ServiceName : StockTakingService, MethodName : Create, Input : {Newtonsoft.Json.JsonConvert.SerializeObject(dataObject)}, Exception : {ex.Message}");
                throw ex;
            }
        }

        public override void Update(StockTaking dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    CountingOperations o = new CountingOperations(dal);
                    o.UpdateStockTaking(dataObject);
                    dal.CommitTransaction();
                } catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($" ServiceName : StockTakingService, MethodName : Update, Input : {Newtonsoft.Json.JsonConvert.SerializeObject(dataObject)}, Exception : {ex.Message}");
                    throw ex;
                }
            }
            
        }

        public IEnumerable<StockTaking> ListStockTakingProducts(long scheduleId)
        {
            IEnumerable<StockTaking> _stockTakingList = null;
            using (IDAL dal = this.DAL)
            {
                try
                {
                    IUniParameter prmStockTakingScheduleId = dal.CreateParameter("StockTakingSchedule", scheduleId);
                    _stockTakingList = dal.List<StockTaking>("WHS_LST_STOCKTAKING_SP", prmStockTakingScheduleId).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                    // _logger.Error($" listStoreOrderDetails {ex.Message}");
                }
            }
            return _stockTakingList;
        }

        public decimal InsertFromBarcodeReader(long scheduleId, int zoneId, int opCode, string eanCode, decimal manualWeight)
        {
            using (IDAL dal = this.DAL)
            {
                decimal finalValue = 0;
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmScheduleId = dal.CreateParameter("ScheduleID", scheduleId);
                    IUniParameter prmZoneId = dal.CreateParameter("Zone", zoneId);
                    IUniParameter prmOpCode = dal.CreateParameter("OpCode", opCode);
                    IUniParameter prmEanCode = dal.CreateParameter("EanCode", eanCode);
                    IUniParameter prmManualWeight = dal.CreateParameter("ManualWeight", manualWeight);

                    IUniParameter prmFinalValue = dal.CreateParameter("FinalValue", 4, ParameterDirection.Output, 0.0);
                    dal.ExecuteNonQuery("WHS_UPD_COUNTINGWITHBARCODE_SP", prmScheduleId, prmZoneId, prmOpCode, prmEanCode, prmManualWeight, prmFinalValue);
                    finalValue = prmFinalValue.Value.To<decimal>();
                    dal.CommitTransaction();
                    return finalValue;
                }
                catch (Exception ex)
                {
                    _logger.Error($"Error: InsertFromBarcodeReader {ex.Message}, Parameters : {scheduleId}, {zoneId}, {opCode}, {eanCode}");
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public void UpdateStockTakings(IEnumerable<StockTaking> stockTakingList)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                StockTaking temps = null;
                try
                {
                    _logger.Debug($"UpdateStockTakings RecordCount : {stockTakingList.Count()}");
                    foreach (StockTaking s in stockTakingList)
                    {
                        temps = s;
                        if (s.StockTakingId != 0)
                        {
                            dal.Update(s);
                        }
                        else
                        {
                            s.Event = 1;
                            s.Organization = 1;
                            s.CountingDate = DateTime.Now.Date.AddHours(-6);
                            //_logger.Debug($"UpdateStockTakings counting date: {s.CountingDate}");
                            dal.Create(s);
                        }
                    }
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($"Error: UpdateStockTakings {ex.Message}");
                    _logger.Error(temps.CountingDate);
                    throw ex;
                }
            }

        }

        public DataTable ListCurrentStocks(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                return dal.ExecuteDataset("INV_LST_STOCK_SP", prmStoreId).Tables[0];
            }
        }

        public DataTable ListStockTransactions(long storeId, long productId, decimal currentStock)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmProductId = dal.CreateParameter("ProductId", productId);
                IUniParameter prmCurrentStock = dal.CreateParameter("CurrentStock", currentStock);
                return dal.ExecuteDataset("INV_LST_STOCKTRANSACTIONS_SP", prmStoreId, prmProductId, prmCurrentStock).Tables[0];
            }
        }
        
        public DataTable ListStocksAtCriticalLevel(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                return dal.ExecuteDataset("INV_LST_STOCKSATCRITICALLEVEL_SP", prmStoreId).Tables[0];
            }
        }

        public DataTable ListStocktracking(DateTime startDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStartDate = dal.CreateParameter("Date", startDate);
                return dal.ExecuteDataset("INV_LST_WAREHOUSESTOCK_SP", prmStartDate).Tables[0];
            }
        }
        
        public DataTable ListStocktrackingProducts(long product, DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmProduct = dal.CreateParameter("ProductId", product);
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate ", endDate);
                return dal.ExecuteDataset("INV_LST_WHPRODUCTSTOCK_SP", prmProduct, prmStartDate, prmEndDate).Tables[0];
            }
        }

        public DataTable ListDailyStockTrendByStore(long store, DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStore = dal.CreateParameter("Store", store);
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate ", endDate);
                return dal.ExecuteDataset("INV_LST_DAILYSTOCKTREND_SP", prmStore, prmStartDate, prmEndDate).Tables[0];
            }
        }

        public void FastEntryUpdate(StockTaking stockTaking)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmStockTakingSchedule = dal.CreateParameter("StockTakingSchedule", stockTaking.StockTakingSchedule);
                    IUniParameter prmProduct = dal.CreateParameter("Product", stockTaking.Product);
                    IUniParameter prmZone = dal.CreateParameter("Zone ", stockTaking.Zone);
                    IUniParameter prmCountingValue = dal.CreateParameter("CountingValue", stockTaking.CountingValue);
                    dal.ExecuteNonQuery("WHS_UPD_FESTOCKTAKING_SP", prmStockTakingSchedule, prmProduct, prmZone, prmCountingValue);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($"Error: FastEntryUpdate {ex.Message}");
                    throw ex;
                }
            }
        }

        public void MikroTransfer()
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    dal.ExecuteNonQuery("MIK_INS_STOCKTAKING_SP");
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($"Error: MikroTransfer {ex.Message}");
                    throw ex;
                }
            }

        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}