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
using Overtech.Mutual.Parameter; //Custom
using Overtech.Core.DependencyInjection; //Custom
using Overtech.API.BPM;
using Overtech.Core.Application;
using Overtech.Mutual.Security;
using Overtech.DataModels.Security;
using Overtech.DataModels.Store;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class TransferProductService : CRUDLDataService<Overtech.DataModels.Warehouse.TransferProduct>, ITransferProductService
    {
        IParameterReader _parameterReader;
        IOTResolver _resolver;
        ITransferProductDetailService _detailService;
        /*Section="Constructor-1", IsCustomized=true*/
        public TransferProductService(IParameterReader parameterReader, IOTResolver resolver, ITransferProductDetailService detailService)
        {
            this._parameterReader = parameterReader;
            _resolver = resolver;
            this._detailService = detailService;
        }

        /*Section="Constructor-2"*/
        internal TransferProductService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public override IEnumerable<TransferProduct> List()
        {
            using (IDAL dal = this.DAL)
            {

                dal.BeginTransaction();
                try
                {

                    var transferProduct = dal.List<Overtech.DataModels.Warehouse.TransferProduct>("WHS_LST_TRANSFERPRODUCT_SP").ToList();
                    var transferDetail = _detailService.List().ToList();

                    //return transferProduct;

                    var t = transferProduct.GroupJoin(
                        transferDetail,
                        transfer => transfer.TransferProductId,
                        detailCol => detailCol.TransferProduct,
                        (transfer, detailCol) =>
                       { transfer.TransferDetails = detailCol.Where(f => transfer.TransferProductId == f.TransferProduct); return transfer; }
                       );
                    return t;

                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }
        
        public override TransferProduct Create(TransferProduct dataObject)
        {

            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    if (dataObject.TransferProductId > 0)
                    {
                        dal.Update(dataObject);
                    }
                    else
                    {
                        dataObject.TransferProductId = dal.Create(dataObject);
                    }
                    foreach (TransferProductDetail td in dataObject.TransferDetails)
                    {
                        td.TransferProduct = dataObject.TransferProductId;
                        if (td.TransferProductDetailId > 0)
                            dal.Update(td);
                        else
                            dal.Create(td);
                    }
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw (ex);
                }

                return dataObject;
            }

        }

        public override void Delete(long objectId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    // Get processInstanceNo of the sugggestion
                    var processInstance = dal.Read<TransferProduct>(objectId).ProcessInstance;

                    // Delete via DAL 
                    TransferProduct tp = Read(objectId, dal);
                    foreach (TransferProductDetail td in tp.TransferDetails)
                    {
                        dal.Delete<TransferProductDetail>(td.TransferProductDetailId);
                    }
                    dal.Delete<TransferProduct>(objectId);

                    // Delete Mikro Records, if status is completed
                    if (tp.TransferStatus == 5)
                    {
                        IUniParameter prmTransferProduct = dal.CreateParameter("TransferProductId", objectId);
                        dal.ExecuteNonQuery("WHS_DEL_WAYBILLBYTRANSFERPRODUCTID_SP", prmTransferProduct);
                    }

                    // Kill process via ProcessOperations (other then already completed processes)
                    if (processInstance != null & tp.TransferStatus < 5)
                    {
                        ProcessOperations processOperations = new ProcessOperations(OTApplication.Context.User.Id);
                        processOperations.Cancel(processInstance.Value);
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
        public virtual void Update(TransferProduct dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    // Update via DAL
                    dal.Update<TransferProduct>(dataObject);
                    
                    // Delete and ReInsert Mikro Records, if status is completed
                    //if (dataObject.TransferStatus == 5)
                    //{
                    //    IUniParameter prmTransferProduct = dal.CreateParameter("TransferProductId", dataObject.TransferProductId);
                    //    dal.ExecuteNonQuery("WHS_DEL_WAYBILLBYTRANSFERPRODUCTID_SP", prmTransferProduct);
                    //    dal.ExecuteNonQuery("WHS_INS_WAYBILLBYTRANSFERPRODUCTID_SP", prmTransferProduct);
                    //}


                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public TransferProduct Read(long objectId, IDAL dal)
        {
            TransferProduct masterObject;
            IUniParameter prmId = dal.CreateParameter("TransferProductId", objectId);
            masterObject = dal.Read<Overtech.DataModels.Warehouse.TransferProduct>("WHS_SEL_TRANSFERPRODUCT_SP", prmId);
            var detailData = _detailService.List().Where<TransferProductDetail>(detail => detail.TransferProduct == masterObject.TransferProductId);
            masterObject.TransferDetails = detailData;
            return masterObject;
        }
        
        public override TransferProduct Read(long objectId)
        {
            using (IDAL dal = this.DAL)
            {
                return Read(objectId, dal);
            }

        }

        public void TriggerTransferProcess(DataModels.Warehouse.TransferProduct dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    startTransferProductProcess(dataObject, dal);
                    dal.CommitTransaction();
                } catch
                {
                    dal.RollbackTransaction();
                    throw;
                }                
            }
        }

        private void startTransferProductProcess(DataModels.Warehouse.TransferProduct dataModel, IDAL dal)
        {

            int processDefinitionId = _parameterReader.ReadPublicParameter<int>("MagazalarArasiTransferSureci", 2016);
            var sourceStore = dal.Read<Store>(dataModel.SourceStore);
            var intakeBranchId = dataModel.DestinationStore == 999 ? 999 : dal.Read<Store>(dataModel.DestinationStore).OrganizationBranch;

            GroupOperations gop = new GroupOperations(dal);
            Group g = gop.FindGroup("Mağazalar Arası Ürün Transfer Kullanıcıları");
            Group gWarehouse = gop.FindGroup("Depo Sorumlusu");
            IProcessInstance processInstance = new ProcessInstance(processDefinitionId, OTApplication.Context.User.Id);

            //Set Process Variables
            processInstance.AddProcessVariable("user", OTApplication.Context.User.Id);
            processInstance.AddProcessVariable("screenReference", "Warehouse#TransferProductListComponent#" + dataModel.TransferProductId);
            processInstance.AddProcessVariable("sendBranch", sourceStore.OrganizationBranch);
            processInstance.AddProcessVariable("transferProductAdminGroup", g.GroupId);
            processInstance.AddProcessVariable("intakeBranch", intakeBranchId);
            processInstance.AddProcessVariable("warehouseGroup", gWarehouse.GroupId);
            processInstance.AddProcessVariable("transferId", dataModel.TransferProductId);
            processInstance.AddProcessVariable("transferToWarehouse", dataModel.DestinationStore == 999 ? true : false);

            //Set Action Varibles
            processInstance.AddActionVariable("user", OTApplication.Context.User.Id);

            //Start Process
            var processId = processInstance.Start(dataModel.TransferProductId.ToString());

            // Update DB
            dataModel.ProcessInstance = processId;
            dataModel.TransferStatus = 2;
            dal.Update(dataModel);
        }

        public void TakeAction(DataModels.Warehouse.TransferProduct dataObject, long actionId, string choice, string comment)
        {


            using (IDAL dal = this.DAL)
            {

                dal.BeginTransaction();
                try
                {
                    // var originalObject = dal.Read<DataModels.Announcement.Suggestion>(dataObject.TransferProductId);
                    IActionOperations actionOperations = new Overtech.API.BPM.ActionOperations(OTApplication.Context.User.Id);
                    var actionInfo = actionOperations.GetActionInfo(actionId);
                    IAction action = new Overtech.API.BPM.Action(actionId, OTApplication.Context.User.Id);
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

        public void UpdateStatus(long transferProductId, long statusId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    var transferProduct = dal.Read<TransferProduct>(transferProductId);
                    transferProduct.TransferStatus = statusId;
                    dal.Update<TransferProduct>(transferProduct);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public void TransferToMikro(long transferProductId, long statusId, bool toWarehouse)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    // TRANSFER TO MIKRO DB
                    IUniParameter prmTransferProduct = dal.CreateParameter("TransferProductId", transferProductId);
                    dal.ExecuteNonQuery("WHS_INS_WAYBILLBYTRANSFERPRODUCTID_SP", prmTransferProduct);

                    // UPDATE STATUS
                    var transferProduct = dal.Read<TransferProduct>(transferProductId);
                    transferProduct.TransferStatus = statusId;
                    dal.Update<TransferProduct>(transferProduct);

                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
        #endregion Customized

                /*Section="ClassFooter"*/
            }
        }
    }
}