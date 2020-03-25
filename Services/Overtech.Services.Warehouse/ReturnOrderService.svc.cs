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
using Overtech.DataModels.Store;
using Overtech.DataModels.Organization;
using Overtech.Mutual.Security;
using Overtech.DataModels.Security;

/*Section="ClassHeader", IsCustomized=true*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class ReturnOrderService : CRUDLDataService<Overtech.DataModels.Warehouse.ReturnOrder>, IReturnOrderService
    {
        IParameterReader _parameterReader;
        IOTResolver _resolver;

        /*Section="Constructor-1", IsCustomized=true*/
        public ReturnOrderService(IParameterReader parameterReader, IOTResolver resolver)
        {
            this._parameterReader = parameterReader;
            _resolver = resolver;
        }

        /*Section="Constructor-2"*/
        internal ReturnOrderService(IDAL dal)
            : base(dal)
        {
        }


        /*Section="CustomCodeRegion"*/
        #region Customized
        public override ReturnOrder Create(ReturnOrder dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    dataObject.Organization = OTApplication.Context.Organization.Id;
                    dataObject.Event = _parameterReader.ReadEventId("System");
                    dataObject.ReturnOrderId = dal.Create(dataObject);

                    startReturnOrderProcess(dataObject, dal);

                    dal.CommitTransaction();
                    return dataObject;
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        private void startReturnOrderProcess(DataModels.Warehouse.ReturnOrder dataModel, IDAL dal)
        {
            
            int processDefinitionId = _parameterReader.ReadPublicParameter<int>("UrunIadeSureci", 2009);
            var store = dal.Read<Store>(dataModel.Store);
            var branch = dal.Read<Branch>(store.OrganizationBranch);
            GroupOperations gop = new GroupOperations(dal);
            Group g = gop.FindGroup("Ürün İade Kullanıcıları");
            IProcessInstance processInstance = new ProcessInstance(processDefinitionId, OTApplication.Context.User.Id);
            //Set Process Variables
            processInstance.AddProcessVariable("user", OTApplication.Context.User.Id);
            processInstance.AddProcessVariable("screenReference", "Warehouse#ReturnOrderListComponent#" + dataModel.ReturnOrderId);
            processInstance.AddProcessVariable("branch", store.OrganizationBranch);
            processInstance.AddProcessVariable("region", branch.Parent);
            processInstance.AddProcessVariable("requestId", dataModel.ReturnOrderId);
            processInstance.AddProcessVariable("accountingGroup", g.GroupId);

            //Set Action Varibles
            processInstance.AddActionVariable("user", OTApplication.Context.User.Id);
            //processInstance.AddActionVariable("description", dataModel.Description);

            //Start Process
            var processId = processInstance.Start(dataModel.ReturnOrderId.ToString());
            dataModel.ProcessInstance = processId;
            dal.Update(dataModel);
        }

        public void UpdateStatus(long requestId, long statusId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    ReturnOrder o = dal.Read<ReturnOrder>(requestId);
                    o.Status = statusId;
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

        public void TakeAction(DataModels.Warehouse.ReturnOrder dataObject, long actionId, string choice, string comment)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    var originalObject = dal.Read<DataModels.Warehouse.ReturnOrder>(dataObject.ReturnOrderId);

                    IActionOperations actionOperations = new Overtech.API.BPM.ActionOperations(OTApplication.Context.User.Id);

                    var actionInfo = actionOperations.GetActionInfo(actionId);

                    IAction action = new Overtech.API.BPM.Action(actionId, OTApplication.Context.User.Id);

                    if (choice == "Onay" || choice == "Gönder" || choice == "Tamamlandı")
                    {
                        switch (actionInfo.ActivityName)
                        {
                            case "Şube Adımı": originalObject.Status = 2; break;
                            case "Bölge Sorumlusu Adımı": originalObject.Status = 3; break;
                            case "Merkez Adımı": originalObject.Status = 4; break;
                            case "Şube Sevk Adımı": originalObject.Status = 5; break;
                            case "Merkez Statu Belirleme Adımı": originalObject.Status = 6; break;
                        }
                    } else if (choice == "Revize")
                    {
                        originalObject.Status = 1;
                    } else if (choice == "İptal")
                    {
                        originalObject.Status = 7;
                    }

                    /*
                    var planNote = new PurchaseOrderNote
                    {
                        Event = dataObject.Event,
                        Organization = dataObject.Organization,
                        PurchaseOrder = dataObject.PurchaseOrderId,
                        Message = $"Alınan aksiyon: {choice}. Açıklama: {comment}"

                    };
                    dal.Create(planNote);
                    */

                    dal.Update(originalObject);

                    //if (actionInfo.ActivityName == "Şube Revizyon")
                    //{
                    //    IUniParameter prmPurchaseOrder = dal.CreateParameter("PurchaseOrder", dataObject.PurchaseOrderId);
                    //    var orderItemList = dal.List<PurchaseOrderItem>("POR_LST_PURCHASEORDERITEM_SP", prmPurchaseOrder).ToList();
                    //    action.AddProcessVariable("orderItems", orderItemList);
                    //}

                    action.Commit(choice, comment);
                    // Update via DAL

                    dal.CommitTransaction();
                    /*
                    if (choice == "Onay" || choice == "Red" || choice == "Reddet")
                    {
                        SendRequesterOrderMail(dataObject.ReturnOrderId, choice);
                    }
                    */
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