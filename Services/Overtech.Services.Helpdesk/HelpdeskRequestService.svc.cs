// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Core.Logger;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Helpdesk;
using Overtech.ServiceContracts.Helpdesk;
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;
using Overtech.DataModels.Store;
using Overtech.API.BPM;
using Overtech.Core.Application;
using Overtech.DataModels.Organization;
using Overtech.Mutual.Security;
using Overtech.DataModels.Security;
using Overtech.Shared.BPM;
using Overtech.Shared.OverStore.BPM;
using Overtech.DataModels.BPMAction;
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.Services.Helpdesk
{
    [OTInspectorBehavior]
    public class HelpdeskRequestService : CRUDLDataService<Overtech.DataModels.Helpdesk.HelpdeskRequest>, IHelpdeskRequestService
    {
        /*Section="Constructor-1"*/
        IParameterReader _parameterReader;
        IOTResolver _resolver;
        private ILogger _logger;

        public HelpdeskRequestService(IParameterReader parameterReader, IOTResolver resolver, ILoggerFactory loggerFactory)
        {
            this._parameterReader = parameterReader;
            _resolver = resolver;
            _logger = loggerFactory.GetLogger(typeof(HelpdeskRequestService));
        }

        /*Section="Constructor-2"*/
        internal HelpdeskRequestService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-ListRequestDetails"*/
        public IEnumerable<RequestDetail> ListRequestDetails(long helpdeskRequestId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmRequest = dal.CreateParameter("Request", helpdeskRequestId);
                return dal.List<RequestDetail>("HDK_LST_REQUESTDETAIL_SP", prmRequest).ToList();
            }
        }

        /*Section="Method-ListRequestAdditionalInfoes"*/
        public IEnumerable<RequestAdditionalInfo> ListRequestAdditionalInfoes(long helpdeskRequestId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmRequest = dal.CreateParameter("Request", helpdeskRequestId);
                return dal.List<RequestAdditionalInfo>("HDK_LST_REQADDITIONALINFO_SP", prmRequest).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        private void startHelpDeskProcess(DataModels.Helpdesk.HelpdeskRequest dataModel, IDAL dal)
        {
            bool yardimciMalzeme = (dataModel.ProcessName == "YardimMasasiYardimciMalzeme");
            bool bilgislem = (dataModel.ProcessName == "YardimMasasiAriza");
            int processDefinitionId = _parameterReader.ReadPublicParameter<int>(dataModel.ProcessName, dataModel.Process);
            var store = dal.Read<Store>(dataModel.Store);
            var branch = dal.Read<Branch>(store.OrganizationBranch);
            GroupOperations gop = new GroupOperations(dal);

            IProcessInstance processInstance = new ProcessInstance(processDefinitionId, OTApplication.Context.User.Id);
            //Set Process Variables
            processInstance.AddProcessVariable("user", OTApplication.Context.User.Id);
            processInstance.AddProcessVariable("screenReference", "Helpdesk#HelpdeskRequestListComponent#" + dataModel.HelpdeskRequestId);
            processInstance.AddProcessVariable("branch", store.OrganizationBranch);
            processInstance.AddProcessVariable("region", branch.Parent);
            processInstance.AddProcessVariable("requestId", dataModel.HelpdeskRequestId);
            if (yardimciMalzeme)
            {
                Overtech.DataModels.Security.Group g = gop.FindGroup("Satın Alma");
                processInstance.AddProcessVariable("purchasingGroup", g.GroupId);
                g = gop.FindGroup("Depo Sorumlusu");
                processInstance.AddProcessVariable("warehouseGroup", g.GroupId);
                g = gop.FindGroup("İdari İşler");
                processInstance.AddProcessVariable("executiveStaffGroup", g.GroupId);
            } else if (bilgislem)
            {
                Overtech.DataModels.Security.Group g = gop.FindGroup("Momende");
                processInstance.AddProcessVariable("momendeGroup", g.GroupId);
                g = gop.FindGroup("Bilgi Sistemleri Kullanıcıları");
                processInstance.AddProcessVariable("bilgiIslemGroup", g.GroupId);
            }
            processInstance.AddProcessVariable("description", dataModel.RequestDescription);
            string storeName = dal.List<Store>("STR_LST_STORE_SP").Where(s => s.StoreId == dataModel.Store)
                                                                  .Select(s => s.Name)
                                                                  .FirstOrDefault();
            processInstance.AddProcessVariable("storeName", storeName);
            string definitionName = dal.List<RequestDefinition>("HDK_LST_REQUESTDEF_SP").Where(rd => rd.RequestDefinitionId == dataModel.RequestDefinition)
                                                                                        .Select(rd => rd.RequestDefinitionName)
                                                                                        .FirstOrDefault();
            processInstance.AddProcessVariable("definition", definitionName);
            string deviceNo = "-";
            IEnumerable<DataModels.Helpdesk.RequestAttribute> deviceAttributeList = dal.List<DataModels.Helpdesk.RequestAttribute>("HDK_LST_ATTRIBUTE_SP")
                                                                                           .Where(a => a.AttributeType > 4 && a.RequestDefinition == dataModel.RequestDefinition);
            dataModel.RequestDetailList.ForEach(rd => 
            { 
                if (deviceNo == "-") 
                {
                    for(int i = 0; i < deviceAttributeList.Count(); i++)
                    {
                        DataModels.Helpdesk.RequestAttribute da = deviceAttributeList.ElementAt(i);
                        if (da.RequestAttributeId == rd.Attribute)
                        {
                            string deviceName;
                            string serialNo;
                            switch (da.AttributeType)
                            {
                                case 5: // TERAZI
                                    StoreScales scale = dal.Read<StoreScales>(Int32.Parse(rd.AttributeValue));
                                    deviceName = scale.BrandName ?? "";
                                    serialNo = scale.SerialNumber ?? "";
                                    i = deviceAttributeList.Count();
                                    break;
                                case 6:  // YAZARKASA
                                    StoreCashRegister cashRegister = dal.Read<StoreCashRegister>(Int32.Parse(rd.AttributeValue));
                                    deviceName = cashRegister.BrandName ?? "";
                                    serialNo = cashRegister.SerialNo ?? "";
                                    i = deviceAttributeList.Count();
                                    break;
                                case 7:  // DEMIRBAS
                                    StoreFixture fixture = dal.Read<StoreFixture>(Int32.Parse(rd.AttributeValue));
                                    deviceName = fixture.FixtureName ?? "";
                                    serialNo = fixture.SerialNo ?? "";
                                    i = deviceAttributeList.Count();
                                    break;
                                default:
                                    deviceName = "";
                                    serialNo = "";
                                    i = deviceAttributeList.Count();
                                    break;
                            }

                            deviceNo = deviceName + (serialNo.Length > 0 ? "-" + serialNo : "");
                        }
                    };
                }
            });
            processInstance.AddProcessVariable("deviceNo", deviceNo);

            //Set Action Varibles
            processInstance.AddActionVariable("user", OTApplication.Context.User.Id);
            //processInstance.AddActionVariable("description", $"{store.Name} - {product.Name}");

            //Start Process
            var processId = processInstance.Start(dataModel.HelpdeskRequestId.ToString());
            dataModel.ProcessInstance = processId;
            dataModel.StatusCode = 1;
            dal.Update(dataModel);
        }

        public void TakeAction(DataModels.Helpdesk.HelpdeskRequest dataObject, long actionId, string choice, string comment)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IActionOperations actionOperations = new Overtech.API.BPM.ActionOperations(OTApplication.Context.User.Id);

                    var actionInfo = actionOperations.GetActionInfo(actionId);

                    IAction action = new Overtech.API.BPM.Action(actionId, OTApplication.Context.User.Id);

                    switch (choice) {
                        case "Çözüldü": dataObject.StatusCode = (int)RequestStatusList.Cozuldu; break;
                        case "Revize": dataObject.StatusCode = (int)RequestStatusList.Revize; break;
                        case "Tamam": dataObject.StatusCode = (int)RequestStatusList.RevizeTamam; break;
                        case "Momende": dataObject.StatusCode = (int)RequestStatusList.Momende; break;
                        case "Yönlendirildi": dataObject.StatusCode = (int)RequestStatusList.Yonlendirildi; break;
                        case "Servise Alındı": dataObject.StatusCode = (int)RequestStatusList.ServiseAlindi; break;
                        case "Askıya Alındı": dataObject.StatusCode = (int)RequestStatusList.AskiyaAlindi; break;
                        case "Hurdaya Ayrıldı": dataObject.StatusCode = (int)RequestStatusList.HurdayaAlindi; break;
                        case "Reddedildi": dataObject.StatusCode = (int)RequestStatusList.Iptal; break;
                        case "Tamamlandı": dataObject.StatusCode = (int)RequestStatusList.CozumOnaylandi; break;
                        case "Çözülmedi": dataObject.StatusCode = (int)RequestStatusList.Cozulmemis; break;
                        case "Yenisi gönderildi": dataObject.StatusCode = (int)RequestStatusList.YenisiGonderildi; break;
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

        public HelpdeskRequest ReadRequest(long id)
        {
            using (IDAL dal = this.DAL)
            {
                HelpdeskRequest hr = dal.Read<HelpdeskRequest>(id);
                hr.RequestDetailList = dal.List<RequestDetail>(id).ToList();
                return hr;
            }
        }

        public HelpdeskRequest CreateRequest(Overtech.DataModels.Helpdesk.HelpdeskRequest rec)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {

                    rec.StatusCode = 1;
                    rec.Organization = OTApplication.Context.Organization.Id;
                    rec.Event = 1;
                    long recId = dal.Create<HelpdeskRequest>(rec);
                    rec.HelpdeskRequestId = recId;

                    foreach (RequestDetail rd in rec.RequestDetailList)
                    {
                        rd.Request = recId;
                        dal.Create<RequestDetail>(rd);
                    }

                    startHelpDeskProcess(rec, dal);

                    dal.CommitTransaction();
                    return rec;
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($"serviceName : HelpdeskRequestService, methodName : CreateRequest, model : {Newtonsoft.Json.JsonConvert.SerializeObject(rec)}, Exception : {ex.ToString()}");
                    throw (ex);
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
                    HelpdeskRequest o = dal.Read<HelpdeskRequest>(requestId);
                    o.StatusCode = statusId;
                    dal.Update(o);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($"serviceName : HelpdeskRequestService, methodName : UpdateStatus, Arguments (requestId, statusId): ({requestId},{statusId}) , Exception : {ex.ToString()}");
                    throw;
                }
            }
        }

        public IEnumerable<HelpdeskRequest> ListFiltered(Boolean OpenFlag, DateTime StartDate, DateTime EndDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmOpenFlag = dal.CreateParameter("OpenFlag", OpenFlag?"Y":"N");
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", StartDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", EndDate);
                return dal.List<HelpdeskRequest>("HDK_LST_REQUEST_SP", prmOpenFlag, prmStartDate, prmEndDate).ToList();
            }
        }

        public RequestBPM UserTask(long ProcessInstanceId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmProcessInstanceId = dal.CreateParameter("ProcessInstanceId", ProcessInstanceId);
                return dal.Read<RequestBPM>("BPM_SEL_USERTASK_SP", prmProcessInstanceId);
            }
        }

        public DataSet TaskDashboard()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("HDK_LST_TASKDASHBOARD_SP");
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}