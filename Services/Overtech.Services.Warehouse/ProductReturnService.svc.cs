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
using Overtech.Core.Application;
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;
using Overtech.DataModels.Store;
using Overtech.DataModels.Organization;
using Overtech.Mutual.Security;
using Overtech.DataModels.Security;
using Overtech.API.BPM;
using Overtech.DataModels.Product;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class ProductReturnService : CRUDLDataService<Overtech.DataModels.Warehouse.ProductReturn>, IProductReturnService
    {
        /*Section="Constructor-1"*/
        IParameterReader _parameterReader;
        IOTResolver _resolver;

        public ProductReturnService(IParameterReader parameterReader, IOTResolver resolver)
        {
            this._parameterReader = parameterReader;
            _resolver = resolver;
        }

        /*Section="Constructor-2"*/
        internal ProductReturnService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public override IEnumerable<ProductReturn> List()
        {
            return ListStatus(-1);
        }

        public IEnumerable<ProductReturn> ListStatus(int statusCode)
        {
            IEnumerable<ProductReturn> ret = new List<ProductReturn>();
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStatusCode = dal.CreateParameter("StatusCode", statusCode);
                ret = dal.List<ProductReturn>("WHS_LST_PRODUCTRETURN_SP", prmStatusCode).ToList();

                foreach (ProductReturn pr in ret)
                {
                    IUniParameter prmProductReturnId = dal.CreateParameter("ProductReturnId", pr.ProductReturnId);
                    IEnumerable<ProductReturnReason> l = dal.List<ProductReturnReason>("WHS_LST_PRODUCTRETURNREASON_SP", prmProductReturnId).ToList();
                    pr.ReturnReason = l;
                    string returnReasons = "";
                    foreach (ProductReturnReason rr in l)
                    {
                        returnReasons += rr.ReasonName + ";";
                    }
                    pr.ReturnReasons = returnReasons;
                }

                return ret;
            }
            // return base.List();
        }

        public override ProductReturn Read(long objectId)
        {
            ProductReturn ret;
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmProductReturnId = dal.CreateParameter("ProductReturnId", objectId);
                ret = dal.Read<ProductReturn>("WHS_SEL_PRODUCTRETURN_SP", prmProductReturnId);
                IEnumerable<ProductReturnReason> l = dal.List<ProductReturnReason>("WHS_LST_PRODUCTRETURNREASON_SP", prmProductReturnId).ToList();
                ret.ReturnReason = l;
                string returnReasons = "";
                foreach (ProductReturnReason rr in l)
                {
                    returnReasons += rr.ReasonName + ";";
                }
                ret.ReturnReasons = returnReasons;
            }
            return ret;
        }

        private void startReturnOrderProcess(DataModels.Warehouse.ProductReturn dataModel, IDAL dal)
        {

            int processDefinitionId = _parameterReader.ReadPublicParameter<int>("UrunIadeSureci", 2009);
            var store = dal.Read<Store>(dataModel.Store);
            var product = dal.Read<Product>(dataModel.Product);
            var branch = dal.Read<Branch>(store.OrganizationBranch);
            GroupOperations gop = new GroupOperations(dal);
            Group g = gop.FindGroup("Ürün İade Kullanıcıları");
            Group g2 = gop.FindGroup("Depo Sorumlusu");
            IProcessInstance processInstance = new ProcessInstance(processDefinitionId, OTApplication.Context.User.Id);
            //Set Process Variables
            processInstance.AddProcessVariable("user", OTApplication.Context.User.Id);
            processInstance.AddProcessVariable("screenReference", "Warehouse#ProductReturnListComponent#" + dataModel.ProductReturnId);
            processInstance.AddProcessVariable("branch", store.OrganizationBranch);
            processInstance.AddProcessVariable("region", branch.Parent);
            processInstance.AddProcessVariable("requestId", dataModel.ProductReturnId);
            processInstance.AddProcessVariable("accountingGroup", g.GroupId);
            processInstance.AddProcessVariable("acceptanceGroup", g2.GroupId);
            

            //Set Action Varibles
            processInstance.AddActionVariable("user", OTApplication.Context.User.Id);
            processInstance.AddActionVariable("description", $"{store.Name} - {product.Name}");

            //Start Process
            var processId = processInstance.Start(dataModel.ProductReturnId.ToString());
            dataModel.ProcessInstance = processId;
            dataModel.StatusCode = 2;
            dal.Update(dataModel);
        }

        public void UpdateStatus(long requestId, int statusId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    ProductReturn o = dal.Read<ProductReturn>(requestId);
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

        public long SaveProductReturn(ProductReturn rec)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                long recId;

                try
                {
                    if (rec.ProductReturnId > 0)
                    {
                        dal.Update(rec);
                        recId = rec.ProductReturnId;
                    }
                    else
                    {
                        recId = dal.Create(rec);
                    }

                    IUniParameter prmProductReturnId = dal.CreateParameter("ProductReturnId", recId);
                    IEnumerable<ProductReturnReason> l = dal.List<ProductReturnReason>("WHS_LST_PRODUCTRETURNREASON_SP", prmProductReturnId).ToList();
                    foreach (ProductReturnReason oldPr in l)
                    {
                        bool found = false;
                        foreach (ProductReturnReason pr in rec.ReturnReason)
                        {
                            if (oldPr.ProductReturnReasonId == pr.ProductReturnReasonId)
                                found = true;
                        }
                        if (!found)
                        {
                            dal.Delete<ProductReturnReason>(oldPr.ProductReturnReasonId);
                        }
                    }
                    foreach (ProductReturnReason pr in rec.ReturnReason)
                    {
                        pr.ProductReturn = recId;
                        if (pr.ProductReturnReasonId > 0)
                            dal.Update(pr);
                        else
                            dal.Create(pr);
                    }
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw (ex);
                }
                return recId;
            }
        }


        public void ApproveProductReturn(ProductReturn rec)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    if (rec.StatusCode == 2)
                    {
                        startReturnOrderProcess(rec, dal);
                    } else
                    {
                        dal.Update(rec);
                    }

                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw (ex);
                }
                // return recId;
            }
        }

        public void createMikroWaybill (long productReturnId, IDAL dal)
        {
            IUniParameter prmProductReturnId = dal.CreateParameter("ProductReturnId", productReturnId);
            dal.ExecuteNonQuery("WHS_INS_MIKROPRODUCTRETURN_SP", prmProductReturnId);
        }

        public void TakeAction(DataModels.Warehouse.ProductReturn dataObject, long actionId, string choice, string comment)
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
                            case "Şube Adımı": dataObject.StatusCode = 3; break;
                            case "Merkez Adımı": dataObject.StatusCode = 4; break;
                            //case "Merkez Statu Belirleme Adımı": originalObject.StatusCode = 5; break;
                        }
                    }
                    else 
                    {
                        dataObject.StatusCode = 7;
                    }

                    dal.Update(dataObject);

                    createMikroWaybill(dataObject.ProductReturnId, dal);

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

        public IEnumerable<ProductReturnHistory> ListHistoryData(long productReturnId)
        {
           using (IDAL dal = this.DAL)
            {
                IUniParameter prmProductReturnId = dal.CreateParameter("Id", productReturnId);
                return dal.List<ProductReturnHistory>("WHS_LST_PRODUCTRETURNHISTORY_SP", prmProductReturnId).ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}