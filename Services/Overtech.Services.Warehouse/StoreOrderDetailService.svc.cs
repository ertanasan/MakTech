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
using Overtech.Core.Logger;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class StoreOrderDetailService : CRUDLDataService<Overtech.DataModels.Warehouse.StoreOrderDetail>, IStoreOrderDetailService
    {
        /*Section="Constructor-1"*/
        private ILogger _logger;
        public StoreOrderDetailService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(typeof(StoreOrderDetailService));
        }

        /*Section="Constructor-2"*/
        internal StoreOrderDetailService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<WarehouseProductUnit> getWarehouseProductUnits()
        {
            IEnumerable<WarehouseProductUnit> _products = null;
            using (IDAL dal = this.DAL)
            {
                try
                {
                    _products = dal.List<WarehouseProductUnit>("WHS_LST_PRODUCT_SP").ToList();
                }
                catch (Exception ex)
                {
                    _logger.Error($" getWarehouseProductUnits {ex.Message}");
                }
            }
            return _products;
        }

        public IEnumerable<StoreOrderDetail> listStoreOrderDetails(long storeOrderId)
        {
            IEnumerable<StoreOrderDetail> _storeorderlist = null;
            using (IDAL dal = this.DAL)
            {
                try
                {
                    dal.BeginTransaction();
                    IUniParameter prmStoreOrderId = dal.CreateParameter("StoreOrderId", storeOrderId);
                    dal.ExecuteNonQuery("WHS_INS_STOREORDERSUGGESTIONS_SP", prmStoreOrderId);
                    _storeorderlist = dal.List<StoreOrderDetail>("WHS_LST_STOREORDERDETAIL_SP", prmStoreOrderId).ToList();
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($" listStoreOrderDetails {ex.Message}");
                }
            }
            return _storeorderlist;
        }

        public void updateOrderDetails(IEnumerable<StoreOrderDetail> orderDetailList)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    foreach (StoreOrderDetail s in orderDetailList)
                    {
                        if (s.StoreOrderDetailId != 0)
                        {
                            dal.Update(s);
                        } else
                        {
                            s.Event = 1047;
                            dal.Create(s);
                        }
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
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}