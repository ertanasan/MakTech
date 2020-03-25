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

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class MaterialOrderService : CRUDLDataService<Overtech.DataModels.Warehouse.MaterialOrder>, IMaterialOrderService
    {
        /*Section="Constructor-1"*/
        public MaterialOrderService()
        {
        }

        /*Section="Constructor-2"*/
        internal MaterialOrderService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public void UpdateStatus(int StatusCode, long[] MaterialOrderIdList)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    foreach (long orderId in MaterialOrderIdList)
                    {
                        var order = dal.Read<MaterialOrder>(orderId);
                        order.OrderStatusCode = StatusCode;
                        dal.Update(order);
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

        public void TakeOrderAction(int ActionCode, long[] MaterialOrderIdList)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    switch (ActionCode)
                    {
                        // split : head quarter
                        case 1:
                            foreach (long orderId in MaterialOrderIdList)
                            {
                                var order = dal.Read<MaterialOrder>(orderId);
                                var currentOrderQuantity = order.OrderQuantity;
                                var newOrderQuantity = Math.Round(currentOrderQuantity / 2, 0);
                                if (newOrderQuantity < 1) newOrderQuantity = 1;
                                var oldOrderQuantity = currentOrderQuantity - newOrderQuantity;
                                if (oldOrderQuantity < 1) oldOrderQuantity = 1;
                                order.OrderQuantity = oldOrderQuantity;
                                dal.Update(order);
                                order.OrderQuantity = newOrderQuantity;
                                dal.Create<MaterialOrder>(order);
                            }
                            break;
                        // reject : head quarter
                        case 2:
                            foreach (long orderId in MaterialOrderIdList)
                            {
                                var order = dal.Read<MaterialOrder>(orderId);
                                order.OrderStatusCode = 9; // reject
                                dal.Update(order);
                            }
                            break;
                        // none : depot
                        case 3:
                            foreach (long orderId in MaterialOrderIdList)
                            {
                                var order = dal.Read<MaterialOrder>(orderId);
                                order.OrderStatusCode = 8; // none
                                dal.Update(order);
                                order.OrderStatusCode = 2; // requested
                                dal.Create<MaterialOrder>(order);
                            }
                            break;
                        // refused : store
                        case 4:
                            foreach (long orderId in MaterialOrderIdList)
                            {
                                var order = dal.Read<MaterialOrder>(orderId);
                                order.OrderStatusCode = 6; // refused
                                dal.Update(order);
                                order.OrderStatusCode = 2; // requested
                                dal.Create<MaterialOrder>(order);
                            }
                            break;
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

        public IEnumerable<MaterialOrder> ListOrders(DateTime StartDate, Boolean AllRecords)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    IUniParameter prmStartDate = dal.CreateParameter("StartDate", StartDate);
                    IUniParameter prmAllRecords = dal.CreateParameter("AllRecords", AllRecords);
                    return dal.List<MaterialOrder>("WHS_LST_MATERIALORDER_SP", prmStartDate, prmAllRecords).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}