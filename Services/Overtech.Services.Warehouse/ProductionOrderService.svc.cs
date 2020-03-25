// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Core.BPM;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Warehouse;
using Overtech.ServiceContracts.Warehouse;
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;
using Overtech.Mutual.Security;
using Overtech.DataModels.Security;
using Overtech.API.BPM;
using Overtech.Core.Application;
using Overtech.Mutual.Warehouse;
using Overtech.DataModels.Product;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class ProductionOrderService : CRUDLDataService<Overtech.DataModels.Warehouse.ProductionOrder>, IProductionOrderService
    {
        /*Section="Constructor-1"*/

        IParameterReader _parameterReader;
        IOTResolver _resolver;

        public ProductionOrderService(IParameterReader parameterReader, IOTResolver resolver)
        {
            this._parameterReader = parameterReader;
            _resolver = resolver;
        }

        /*Section="Constructor-2"*/
        internal ProductionOrderService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        public override ProductionOrder Create(ProductionOrder dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    long productionOrderId = dal.Create<ProductionOrder>(dataObject);
                    dataObject.ProductionOrderId = productionOrderId;
                    startProductionOrderProcess(dataObject, dal);
                    dal.CommitTransaction();
                    return dataObject;
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw (ex);
                }
            }
        }

        private void startProductionOrderProcess(DataModels.Warehouse.ProductionOrder dataModel, IDAL dal)
        {

            int processDefinitionId = _parameterReader.ReadPublicParameter<int>("UretimFisiSureci", 2017);
            GroupOperations gop = new GroupOperations(dal);
            Group g = gop.FindGroup("Depo Sorumlusu");
            Group g2 = gop.FindGroup("Uretim Grubu");
            IProcessInstance processInstance = new ProcessInstance(processDefinitionId, OTApplication.Context.User.Id);
            //Set Process Variables
            processInstance.AddProcessVariable("user", OTApplication.Context.User.Id);
            processInstance.AddProcessVariable("screenReference", "Warehouse#ProductionOrderListComponent#" + dataModel.ProductionOrderId);
            processInstance.AddProcessVariable("requestId", dataModel.ProductionOrderId);
            processInstance.AddProcessVariable("acceptanceGroup", g.GroupId);
            processInstance.AddProcessVariable("productionGroup", g2.GroupId);

            //Set Action Varibles
            processInstance.AddActionVariable("user", OTApplication.Context.User.Id);
            //processInstance.AddActionVariable("description", dataModel.Description);

            //Start Process
            var processId = processInstance.Start(dataModel.ProductionOrderId.ToString());
            dataModel.ProcessInstance = processId;
            dataModel.StatusCode = 1;
            dal.Update(dataModel);
        }

        public void UpdateStatus(long requestId, int statusId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    ProductionOrder o = dal.Read<ProductionOrder>(requestId);
                    o.StatusCode = statusId;
                    dal.Update(o);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        private void waybillFromMainWHtoProductionWH (IDAL dal, ProductionOrder po)
        {
            MikroOperations mikro = new MikroOperations(dal);
            MikroWaybill wb = new MikroWaybill();
            wb.TransactionDate = DateTime.Now;
            wb.TransactionKind = (int)TransactionKind.Transfer;
            wb.TransactionType = (int)TransactionType.DepoTransfer;
            wb.DocumentDate = DateTime.Now;
            wb.DocumentSerial = "OMP";
            wb.DocumentNo = (int)po.ProductionOrderId;
            wb.DocumentType = (int)DocumentType.DepoTransferFisi;
            wb.IsRefund = false;
            wb.ReceiverWarehouse = (int)WarehouseList.Production;
            wb.SenderWarehouse = (int)WarehouseList.Main;
            wb.IntakeShipmentDate = DateTime.Now;
            int rowno = 1;
            foreach (ProductionContent p in po.contents)
            {
                wb.Quantity = p.RequiredPackage * p.UnitWeight;
                Product pInfo = dal.Read<Product>(p.Product);
                wb.ProductCode = pInfo.Code;
                switch (pInfo.SaleVAT)
                {
                    case 0: wb.VATCode = 1; break;
                    case 1: wb.VATCode = 2; break;
                    case 8: wb.VATCode = 3; break;
                    case 18: wb.VATCode = 4; break;
                    default: wb.VATCode = 0; break;
                }
                wb.DocumentRowNo = rowno++;
                mikro.CreateWaybill(wb);
            }
        }

        private void waybillProduction(IDAL dal, ProductionOrder po)
        {
            MikroOperations mikro = new MikroOperations(dal);

            // önceki tamamlanan kayıtları oku, son satır numarasını almak için
            IEnumerable<MikroWaybill> currentwb = mikro.ReadWaybill(DateTime.Now, "OPR", (int)po.ProductionOrderId);
            int lastRowNo = 0;
            if (currentwb.Count() > 0)
            {
                var item = currentwb.OrderByDescending(x => x.DocumentRowNo).First();
                lastRowNo = item.DocumentRowNo + 1;
            }
            
            
            // Üretim depoya giriş satırını oluştur
            MikroWaybill wb = new MikroWaybill();
            wb.TransactionDate = DateTime.Now;
            wb.TransactionKind = (int)TransactionKind.Uretim;
            wb.TransactionType = (int)TransactionType.Giris;
            wb.DocumentDate = DateTime.Now;
            wb.DocumentSerial = "OPR";
            wb.DocumentNo = (int)po.ProductionOrderId;
            wb.DocumentType = (int)DocumentType.UretimFisi;
            wb.IsRefund = false;
            wb.ReceiverWarehouse = (int)WarehouseList.Production;
            wb.SenderWarehouse = 1;
            wb.IntakeShipmentDate = DateTime.Now;
            Production prInfo = dal.Read<Production>(po.Production);
            Product prProductInfo = dal.Read<Product>(prInfo.Product);
            wb.ProductCode = prProductInfo.Code;
            wb.Quantity = (decimal)po.PartialCompletion;
            int rowno;
            wb.DocumentRowNo = lastRowNo;
            mikro.CreateWaybill(wb);

            rowno = lastRowNo + 1;

            // üretim sırasında tüketilen ürünlerin çıkışını yap. 
            IUniParameter prmProduction = dal.CreateParameter("Production", po.Production);
            IEnumerable<ProductionContent> contents = dal.List<ProductionContent>("WHS_LST_PRODUCTIONCONTENT_SP", prmProduction).ToList();
            foreach (ProductionContent p in contents)
            {
                wb.ReceiverWarehouse = 1;
                wb.SenderWarehouse = (int)WarehouseList.Production; 
                wb.TransactionType = (int)TransactionType.Cikis;
                wb.Quantity = (decimal)po.PartialCompletion * p.ShareRate / 100;
                Product pInfo = dal.Read<Product>(p.Product);
                wb.ProductCode = pInfo.Code;
                switch (pInfo.SaleVAT)
                {
                    case 0: wb.VATCode = 1; break;
                    case 1: wb.VATCode = 2; break;
                    case 8: wb.VATCode = 3; break;
                    case 18: wb.VATCode = 4; break;
                    default: wb.VATCode = 0; break;
                }
                wb.DocumentRowNo = rowno++;
                mikro.CreateWaybill(wb);
            }

            // üretim depodan merkez depoya aktarımı yap. 
            wb.TransactionKind = (int)TransactionKind.Transfer;
            wb.TransactionType = (int)TransactionType.DepoTransfer;
            wb.DocumentType = (int)DocumentType.DepoTransferFisi;
            wb.ReceiverWarehouse = (int)WarehouseList.Main;
            wb.SenderWarehouse = (int)WarehouseList.Production;
            wb.ProductCode = prProductInfo.Code;
            wb.Quantity = (decimal)po.PartialCompletion;
            wb.DocumentRowNo = rowno++;
            mikro.CreateWaybill(wb);
        }

        private void waybillProductionCompleted(IDAL dal, ProductionOrder po)
        {
            MikroOperations mikro = new MikroOperations(dal);

            // önceki tamamlanan kayıtları oku, son satır numarasını almak için
            IEnumerable<MikroWaybill> currentwb = mikro.ReadWaybill(DateTime.Now, "OPR", (int)po.ProductionOrderId);
            var item = currentwb.OrderByDescending(x => x.DocumentRowNo).First();

            // sistemsel olarak kalan ama gerçekte kayıptan dolayı kalmamış olan giriş ürünlerini 0'la. 
            MikroWaybill wb = new MikroWaybill();
            wb.TransactionDate = DateTime.Now;
            wb.TransactionKind = (int)TransactionKind.Uretim;
            wb.TransactionType = (int)TransactionType.Cikis;
            wb.DocumentDate = DateTime.Now;
            wb.DocumentSerial = "OPR";
            wb.DocumentNo = (int)po.ProductionOrderId;
            wb.DocumentType = (int)DocumentType.UretimFisi;
            wb.IsRefund = false;
            wb.ReceiverWarehouse = 1;
            wb.SenderWarehouse = (int)WarehouseList.Production;
            wb.IntakeShipmentDate = DateTime.Now;
            int rowno;
            rowno = item.DocumentRowNo + 1;

            IUniParameter prmProduction = dal.CreateParameter("Production", po.Production);
            IEnumerable<ProductionContent> contents = dal.List<ProductionContent>("WHS_LST_PRODUCTIONCONTENT_SP", prmProduction).ToList();
            foreach (ProductionContent p in contents)
            {
                decimal completed = (decimal) po.CompletedQuantity;
                wb.Quantity = p.AllocatedQuantity;
                Product pInfo = dal.Read<Product>(p.Product);
                wb.ProductCode = pInfo.Code;
                switch (pInfo.SaleVAT)
                {
                    case 0: wb.VATCode = 1; break;
                    case 1: wb.VATCode = 2; break;
                    case 8: wb.VATCode = 3; break;
                    case 18: wb.VATCode = 4; break;
                    default: wb.VATCode = 0; break;
                }
                wb.DocumentRowNo = rowno++;
                mikro.CreateWaybill(wb);
            }
        }

        public void TakeAction(DataModels.Warehouse.ProductionOrder dataObject, long actionId, string choice, string comment)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    // var originalObject = dal.Read<DataModels.Warehouse.ProductReturn>(dataObject.ProductReturnId);

                    IActionOperations actionOperations = new Overtech.API.BPM.ActionOperations(OTApplication.Context.User.Id);

                    var actionInfo = actionOperations.GetActionInfo(actionId);

                    IAction action = new Overtech.API.BPM.Action(actionId, OTApplication.Context.User.Id);

                    if (choice != "İptal")
                    {
                        switch (actionInfo.ActivityName)
                        {
                            case "Uretim mal gonderim adımı":
                                dataObject.StatusCode = 2;
                                waybillFromMainWHtoProductionWH(dal, dataObject);
                                break;
                            case "Uretim Grubu Adımı":
                                if (choice == "Tamamlandı")
                                {
                                    dataObject.StatusCode = 4;
                                    if (dataObject.PartialCompletion > 0)
                                    {
                                        waybillProduction(dal, dataObject);
                                    }
                                    waybillProductionCompleted(dal, dataObject);
                                } else
                                {
                                    dataObject.StatusCode = 3;
                                    waybillProduction(dal, dataObject);
                                }
                                break;
                        }
                    }
                    else
                    {
                        dataObject.StatusCode = 7;
                    }

                    dal.Update(dataObject);

                    action.Commit(choice, comment);

                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public override void Delete(long objectId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    ProductionOrder po = dal.Read<ProductionOrder>(objectId);

                    // Kill process via ProcessOperations
                    if (po.ProcessInstance != null)
                    {
                        ProcessOperations processOperations = new ProcessOperations(OTApplication.Context.User.Id);
                        if (processOperations.GetInstanceStatus(po.ProcessInstance.Value) != Overtech.Core.BPM.InstanceStatus.Canceled)
                        {
                            try
                            {
                                processOperations.Cancel(po.ProcessInstance.Value);
                            }
                            catch
                            {
                                throw;
                            }
                        }
                    }
                    dal.Delete<ProductionOrder>(objectId);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}