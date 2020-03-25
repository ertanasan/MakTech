// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Accounting;
using Overtech.ServiceContracts.Accounting;
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;
using Overtech.Mutual.Security;
using Overtech.DataModels.Security;
using Overtech.API.BPM;
using Overtech.Core.Application;
using Overtech.DataModels.Store;
using Overtech.DataModels.Organization;
using System.Data;
using Overtech.Core.Logger;
using System.Net.Http;
using System.Threading.Tasks;
using Overtech.Mutual.Accounting;

/*Section="ClassHeader"*/
namespace Overtech.Services.Accounting
{
    [OTInspectorBehavior]
    public class SaleInvoiceService : CRUDLDataService<Overtech.DataModels.Accounting.SaleInvoice>, ISaleInvoiceService
    {
        IParameterReader _parameterReader;
        IOTResolver _resolver;
        private ILogger _logger;

        /*Section="Constructor-1"*/
        public SaleInvoiceService()
        {
        }

        public SaleInvoiceService(IParameterReader parameterReader, IOTResolver resolver, ILoggerFactory loggerFactory)
        {
            this._parameterReader = parameterReader;
            _resolver = resolver;
            _logger = loggerFactory.GetLogger(typeof(SaleInvoiceService));
        }

        /*Section="Constructor-2"*/
        internal SaleInvoiceService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        private void startEInvoiceProcess(DataModels.Accounting.SaleInvoice dataModel, IDAL dal)
        {

            int processDefinitionId = _parameterReader.ReadPublicParameter<int>("EInvoice", 2020);
            var store = dal.Read<Store>(dataModel.SaleStore);
            var branch = dal.Read<Branch>(store.OrganizationBranch);
            GroupOperations gop = new GroupOperations(dal);
            Group g = gop.FindGroup("Muhasebe E-Fatura");
            long userId;
            if (OTApplication.Context != null && OTApplication.Context.User != null) userId = OTApplication.Context.User.Id; else userId = 1;
            IProcessInstance processInstance = new ProcessInstance(processDefinitionId, userId);
            //Set Process Variables
            processInstance.AddProcessVariable("user", OTApplication.Context.User.Id);
            processInstance.AddProcessVariable("screenReference", "Accounting#SaleInvoiceListComponent#" + dataModel.SaleInvoiceId);
            processInstance.AddProcessVariable("branch", store.OrganizationBranch);
            processInstance.AddProcessVariable("region", branch.Parent);
            processInstance.AddProcessVariable("requestId", dataModel.SaleInvoiceId);
            processInstance.AddProcessVariable("accountingGroup", g.GroupId);


            //Set Action Varibles
            processInstance.AddActionVariable("user", OTApplication.Context.User.Id);
            processInstance.AddActionVariable("description", $"{store.Name} - {dataModel.CustomerIdNumber} - {dataModel.Title} - {dataModel.SaleDate} - {dataModel.SaleAmount}");

            //Start Process
            var processId = processInstance.Start(dataModel.SaleInvoiceId.ToString());
            dataModel.ProcessInstance = processId;
            dataModel.StatusCode = 1;
            dal.Update(dataModel);
        }

        public void SendEInvoice(SaleInvoice rec)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    startEInvoiceProcess(rec, dal);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw (ex);
                }
            }
        }

        private void createMikroInvoice(long saleInvoiceId, IDAL dal)
        {
            IUniParameter prmSaleInvoiceId = dal.CreateParameter("SaleInvoiceId", saleInvoiceId);
            dal.ExecuteNonQuery("MIK_INS_EINVOICE_SP", prmSaleInvoiceId);
        }

        public void TakeAction(DataModels.Accounting.SaleInvoice dataObject, long actionId, string choice, string comment)
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

                    dataObject.StatusCode = 7;
                    
                    dal.Update(dataObject);

                    createMikroInvoice(dataObject.SaleInvoiceId, dal);

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


        public bool checkIfTaxIdentifierExists (string vkn)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmvkn = dal.CreateParameter("vkn", vkn);
                DataTable dt = dal.ExecuteDataset("MIK_SEL_VKN_SP", prmvkn).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        public void UpdateStatus(long requestId, int statusId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    SaleInvoice o = dal.Read<SaleInvoice>(requestId);
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

        public decimal StoreEInvoice(int storeId, DateTime invoiceDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmInvoiceDate = dal.CreateParameter("InvoiceDate", invoiceDate);
                DataTable dt = dal.ExecuteDataset("ACC_SEL_STOREDATEINVOICE_SP", prmStoreId, prmInvoiceDate).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return (decimal)dt.Rows[0][0];
                } else
                {
                    return 0;
                }
            }
        }

        public void CreateCurrentAccount(IdentityInfo identityInfo)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    dal.BeginTransaction();
                    IUniParameter prmkimlikno = dal.CreateParameter("kimlikno", identityInfo.IdentityNo);
                    IUniParameter prmunvan = dal.CreateParameter("unvan", identityInfo.IdentityName);
                    IUniParameter prmvergidaireadi = dal.CreateParameter("vergidaireadi", identityInfo.TaxCenterName);
                    IUniParameter prmefaturaflag = dal.CreateParameter("efaturaflag", identityInfo.EInvoiceFlag);
                    IUniParameter prmemail = dal.CreateParameter("email", identityInfo.Email);
                    IUniParameter prmceptel = dal.CreateParameter("ceptel", identityInfo.PhoneNumber);
                    IUniParameter prmvergidairekodu = dal.CreateParameter("vergidairekodu", identityInfo.TaxCenterCode);
                    dal.ExecuteNonQuery("MIK_INS_CURRENTACCOUNT_SP", prmkimlikno, prmunvan, prmvergidaireadi, prmefaturaflag, prmemail, prmceptel, prmvergidairekodu);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($"serviceName : SaleInvoiceService, methodName : CreateCurrentAccount, identityInfo : {Newtonsoft.Json.JsonConvert.SerializeObject(identityInfo)}, Exception : {ex.ToString()}");
                }
                
            }
        }

        public void ProcessCashRegisterEInvoice()
        {
            using (IDAL dal = this.DAL)
            {
                DataTable dt = dal.ExecuteDataset("ACC_LST_NEWINVOICES_SP").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        EInvoiceOperations invOp = new EInvoiceOperations(dal);
                        EInvoiceClient eInvCli = invOp.CheckIfEInvoiceCustomer(long.Parse(dr["IDENTITYNO_TXT"].ToString()));
                        // kaydı oluştur. 
                        dal.BeginTransaction();
                        try
                        {
                            SaleInvoice i = new SaleInvoice();
                            i.EInvoiceFlag = (eInvCli.EInvoiceClientId != 0);
                            if (eInvCli.EInvoiceClientId != 0) i.EInvoiceClient = eInvCli.EInvoiceClientId;
                            i.CustomerIdNumber = long.Parse(dr["IDENTITYNO_TXT"].ToString());
                            i.Email = dr["EMAIL_TXT"].ToString();
                            i.Event = 1;
                            i.Organization = 1;
                            i.PhoneNumber = dr["PHONENUMBER_TXT"].ToString();
                            i.Sale = (long)dr["SALE"];
                            i.Title = dr["CUSTOMER_NM"].ToString();
                            i.StatusCode = 1;
                            i.Address = dr["ADDRESS_TXT"].ToString();
                            i.SaleStore = int.Parse(dr["STORE"].ToString());
                            i.SaleAmount = decimal.Parse(dr["SALE_AMT"].ToString());
                            i.SaleDate = (DateTime)dr["TRANSACTION_DT"];
                            i.SaleInvoiceId = dal.Create<SaleInvoice>(i);

                            startEInvoiceProcess(i, dal);
                            dal.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            dal.RollbackTransaction();
                            throw ex;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"serviceName : SaleInvoiceService, methodName : ProcessCashRegisterEInvoice, identityInfo : {dr["IDENTITYNO_TXT"].ToString()}, Exception : {ex.ToString()}");
                    }

                }
            }
                
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}