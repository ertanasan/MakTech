// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Store;
using Overtech.ServiceContracts.Store;

using Overtech.Core.Application;
using System.Data;
using Overtech.Mutual.Accounting;
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;
using Overtech.Core.Logger;

/*Section="ClassHeader"*/
namespace Overtech.Services.Store
{
    [OTInspectorBehavior]
    public class WorkingHoursService : CRUDLDataService<Overtech.DataModels.Store.WorkingHours>, IWorkingHoursService
    {
        IParameterReader _parameterReader;
        IOTResolver _resolver;
        private ILogger _logger;

        /*Section="Constructor-1"*/
        public WorkingHoursService(
            IParameterReader parameterReader,
            IOTResolver resolver,
            ILoggerFactory loggerFactory)
        {
            _parameterReader = parameterReader;
            _resolver = resolver;
            _logger = loggerFactory.GetLogger(typeof(WorkingHoursService));
        }

        /*Section="Constructor-2"*/
        internal WorkingHoursService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public string LoadWorkingHoursFile(byte[] formData)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    _logger.Debug($"WorkingHour file read started : {DateTime.Now.ToLongTimeString()}");
                    ExcelOperations exOp = new ExcelOperations(dal);

                    DateTime reportDate;

                    // get report date
                    try
                    {
                        reportDate = DateTime.ParseExact(
                            exOp.GetSpesificCellContent(formData, "WorkingHours", 18, 8).Substring(0, 10),
                            "dd.MM.yyyy",
                            System.Globalization.CultureInfo.GetCultureInfo("en-US")
                        );
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"serviceName : WorkingHoursService, methodName : LoadWorkingHoursFile, Datetime parsing failed, Exception : {ex.Message}");
                        throw new Exception($"Datetime parsing failed, Exception : {ex.Message}");
                    }

                    string result = exOp.ReadExceltoDataTable(formData, "WorkingHours", 1); // filetype 1: xlsx
                    if (result.Length == 0)
                    {
                        DataTable dt = exOp.ExcelTable;
                        IList<WorkingHours> whFailList = new List<WorkingHours>();

                        WorkingHours wh = new WorkingHours();
                        wh.Organization = OTApplication.Context.Organization.Id;
                        wh.Event = _parameterReader.ReadEventId("Import Workinghours");

                        foreach (DataRow dr in dt.Rows)
                        {
                            // InnerRows
                            IList<string> openUserList = dr["ACAN"].ToString().Trim().Split('\n').ToList();
                            IList<string> closeUserList = dr["KAPATAN"].ToString().Trim().Split('\n').ToList();
                            IList<string> openingTimeList = dr["ACILISZAMANI"].ToString().Trim().Split('\n').ToList();
                            IList<string> closingTimeList = dr["KAPANISZAMANI"].ToString().Trim().Split('\n').ToList();

                            wh.StoreCode = dr["ABONENO"].ToString();
                            wh.StoreName = dr["ABONEADI"].ToString();
                            wh.Note = dr["NOTLAR"].ToString();

                            var processWorkingHoursResultTuple = processWorkingHours(dr, reportDate, whFailList, wh, openUserList, closeUserList, openingTimeList, closingTimeList);
                            if (processWorkingHoursResultTuple.Item1)
                            {
                                updateYesterdayRecord(dal, reportDate, wh, openUserList, closeUserList, openingTimeList, closingTimeList);
                            }
                            if (processWorkingHoursResultTuple.Item2)
                            {
                                insertWorkingHours(dal, reportDate, wh, openUserList, closeUserList, openingTimeList, closingTimeList);
                            }
                        }
                        if (whFailList.Count > 0)
                        {
                            result = $"{dt.Rows.Count } kaydın {whFailList.Count} adedi aktarılamadı. Lütfen kayıtları kontrol ediniz.";
                        }
                        if (String.IsNullOrEmpty(result))
                        {
                            _logger.Debug($"WorkingHour file read finished : {DateTime.Now.ToLongTimeString()}");
                        }

                    }
                    dal.CommitTransaction();
                    return result;
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        private ValueTuple<bool, bool> processWorkingHours(DataRow dr, DateTime reportDate, IList<WorkingHours> whFailList, WorkingHours wh, IList<string> openUserList, IList<string> closeUserList, IList<string> openingTimeList, IList<string> closingTimeList)
        {
            // synchronise open-close time rows
            if (openingTimeList.Count < closingTimeList.Count)   // There is at least 1 record which has not opening time and probably belong to yesterday
            {
                return (true, true);
            }
            else if (openingTimeList.Count > closingTimeList.Count)  // There is at least 1 record which has not closing time
            {
                // Nothing change
                return (false, true);
            }
            else if (openingTimeList.Count == 0)   // No time records for that row 
            {
                wh.OpenUserName = openUserList.Count > 0 ? dr["ACAN"].ToString() : null;
                wh.CloseUserName = closeUserList.Count > 0 ? dr["KAPATAN"].ToString() : null;
                wh.OpeningTime = (DateTime?)null;
                wh.ClosingTime = (DateTime?)null;
                whFailList.Add(wh);
                return (false, false);
            }
            else // Default Case OR  At least two unordered records, first closing one is belong to yesterday and the last opening time has no closing pair
            {
                return (true, true);
            }
        }

        private void updateYesterdayRecord(IDAL dal, DateTime reportDate, WorkingHours wh, IList<string> openUserList, IList<string> closeUserList, IList<string> openingTimeList, IList<string> closingTimeList)
        {
            if (TimeSpan.Parse(openingTimeList[0]) > TimeSpan.Parse(closingTimeList[0]))
            {
                bool isYesterdayWhUpdated;
                IUniParameter prmYesterday = dal.CreateParameter("Date", reportDate.AddDays(-1));
                IUniParameter prmStoreCode = dal.CreateParameter("StoreCode", wh.StoreCode);
                WorkingHours yesterdayOpenRecord = dal.Read<WorkingHours>("STR_SEL_WORKINGHOURSOPENRECORD_SP", prmYesterday, prmStoreCode);

                if (yesterdayOpenRecord != null)
                {
                    yesterdayOpenRecord.ClosingTime = (DateTime?)(reportDate + TimeSpan.Parse(closingTimeList[0]));
                    yesterdayOpenRecord.CloseUserName = closeUserList.Count > 0 ? closeUserList[0] : null;
                    yesterdayOpenRecord.CloseUser = null;
                    try
                    {
                        dal.Update<WorkingHours>(yesterdayOpenRecord);
                        isYesterdayWhUpdated = true;
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"serviceName : WorkingHoursService, methodName : insertDataTabletoWorkingHoursTable, could not update object: {Newtonsoft.Json.JsonConvert.SerializeObject(yesterdayOpenRecord)} Exception : {ex.Message}");
                        isYesterdayWhUpdated = false;
                    }
                }
                else
                {
                    isYesterdayWhUpdated = false;
                }

                if (isYesterdayWhUpdated)
                {
                    closingTimeList.RemoveAt(0);
                    closeUserList.RemoveAt(0);
                }
                else
                {
                    openUserList.Insert(0, null);
                    openingTimeList.Insert(0, null);
                }
            }
        }

        private void insertWorkingHours(IDAL dal, DateTime reportDate, WorkingHours wh, IList<string> openUserList, IList<string> closeUserList, IList<string> openingTimeList, IList<string> closingTimeList)
        {
            //  Insert Records
            int maxInnerRowCount = new List<int>
                {
                    openUserList.Count,
                    closeUserList.Count,
                    openingTimeList.Count,
                    closingTimeList.Count
                }.Max();

            for (int i = 0; i < maxInnerRowCount; i++)
            {
                wh.OpenUserName = i < openUserList.Count ? openUserList[i] : null;
                wh.CloseUserName = i < closeUserList.Count ? closeUserList[i] : null;
                wh.OpeningTime = (i < openingTimeList.Count && !String.IsNullOrEmpty(openingTimeList[i])) ? (DateTime?)(reportDate + TimeSpan.Parse(openingTimeList[i])) : (DateTime?)null;
                wh.ClosingTime = i < closingTimeList.Count ? (DateTime?)(reportDate + TimeSpan.Parse(closingTimeList[i])) : (DateTime?)null;

                try
                {
                    dal.Create<WorkingHours>(wh);
                }
                catch (Exception ex)
                {
                    _logger.Error($"serviceName : WorkingHoursService, methodName : insertDataTabletoWorkingHoursTable, could not inserted object: {Newtonsoft.Json.JsonConvert.SerializeObject(wh)} Exception : {ex.Message}");
                    throw;
                }
            }
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}