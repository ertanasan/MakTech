// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Warehouse;
using System.Web.Http.ModelBinding;
using System;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Net;
using Overtech.Core.Document;
using System.Reflection;
using Overtech.ViewModels.Warehouse;
using OfficeOpenXml;
using Overtech.Core.Document2;
using System.Web;

namespace Overtech.Core.Document2
{
    public static class DocumentExtentions
    {
        public static void ExportToExcel2(this DataTable dataTable, string excelFilePath)
        {
            using (var excelPackage = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                addWorksheet2(excelPackage, "DataTable", dataTable);
                excelPackage.Save();
            }
        }

        public static void ExportToExcel2(this DataTable dataTable, Stream stream)
        {
            using (var excelPackage = new ExcelPackage(stream))
            {
                addWorksheet2(excelPackage, "DataTable", dataTable);
                excelPackage.Save();
                stream.Position = 0;
            }
        }

        public static void ExportToExcel2(this DataSet dataSet, string excelFilePath)
        {
            using (var excelPackage = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                foreach (DataTable dataTable in dataSet.Tables)
                {
                    addWorksheet2(excelPackage, "DataTable" + dataSet.Tables.IndexOf(dataTable), dataTable);
                }
                excelPackage.Save();
            }
        }

        private static void addWorksheet2(ExcelPackage excelPackage, string sheetName, DataTable dataTable)
        {
            if (!String.IsNullOrEmpty(dataTable.TableName))
            {
                sheetName = dataTable.TableName;
            }
            var worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);
            worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);
            int colNumber = 1;

            foreach (DataColumn col in dataTable.Columns)
            {
                if (col.DataType == typeof(DateTime))
                {
                    worksheet.Column(colNumber).Style.Numberformat.Format = "dd.MM.yyyy HH:mm:ss";
                }
                colNumber++;
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

        }
    }
}

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    public class ParamStoreOrder
    {
        public long[] storeOrderId
        {
            get; set;
        }
    }


    [RoutePrefix("api/Warehouse/StoreOrder")]
    public class StoreOrderController : CRUDLApiController<Overtech.DataModels.Warehouse.StoreOrder, IStoreOrderService, Overtech.ViewModels.Warehouse.StoreOrder>
    {

        IStoreOrderDetailService _storeOrderDetailService;
        /*Section="Constructor"*/
        public StoreOrderController(
            ILoggerFactory loggerFactory,
            IStoreOrderService storeOrderService,
            IStoreOrderDetailService storeOrderDetailService)
            : base(loggerFactory, storeOrderService)
        {
            _storeOrderDetailService = storeOrderDetailService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        public override StoreOrder Create([FromBody] StoreOrder viewModel)
        {
            return base.Create(viewModel);
        }

        public override DataSourceResult List([ModelBinder(typeof(WebApiDataSourceRequestModelBinder))] DataSourceRequest request = null)
        {
            try
            {
                foreach (FilterDescriptor f in request.Filters)
                {
                    if (f.Member == "OrderDate" || f.Member == "ShipmentDate" || f.Member == "LastApproveTime" || f.Member == "DispatchTime")
                    {
                        DateTime dt = DateTime.ParseExact(f.Value.ToString().Substring(0, 15), "ddd MMM dd yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        f.Value = new DateTime(dt.Year, dt.Month, dt.Day);
                    }
                }
            }
            catch 
            {
                foreach (CompositeFilterDescriptor f in request.Filters)
                {
                    foreach (FilterDescriptor f2 in f.FilterDescriptors)
                    {
                        if (f2.Member == "OrderDate" || f2.Member == "ShipmentDate" || f2.Member == "LastApproveTime" || f2.Member == "DispatchTime")
                        {
                            DateTime dt = DateTime.ParseExact(f2.Value.ToString().Substring(0, 15), "ddd MMM dd yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            f2.Value = new DateTime(dt.Year, dt.Month, dt.Day);
                        }
                    }

                }
            }
            
            DataSourceResult rs = base.List(request);
            
            return rs;
        }


        

        [HttpGet]
        [Route("ExportStoreOrders")]
        [OTControllerAction("List")]
        public IHttpActionResult ExportStoreOrders([ModelBinder(typeof(WebApiDataSourceRequestModelBinder))] DataSourceRequest request = null)
        {
            request.PageSize = 10000;
            DataSourceResult rs = List(request);
            DataTable dt = new DataTable();
            dt.Columns.Add("StoreName");
            dt.Columns.Add("OrderCode");
            dt.Columns.Add("Status");
            DataColumn colOrderDate = new DataColumn("OrderDate");
            colOrderDate.DataType = System.Type.GetType("System.DateTime");
            dt.Columns.Add(colOrderDate);
            DataColumn colShipmentDate = new DataColumn("ShipmentDate");
            colShipmentDate.DataType = System.Type.GetType("System.DateTime");
            dt.Columns.Add(colShipmentDate);
            dt.Columns.Add("LastApproveUser");
            DataColumn colLastApproveTime = new DataColumn("LastApproveTime");
            colLastApproveTime.DataType = System.Type.GetType("System.DateTime");
            dt.Columns.Add(colLastApproveTime);
            dt.Columns.Add("DispatchUser");
            DataColumn colDispatchTime = new DataColumn("DispatchTime");
            colDispatchTime.DataType = System.Type.GetType("System.DateTime");
            dt.Columns.Add(colDispatchTime);
            foreach (Overtech.ViewModels.Warehouse.StoreOrder item in rs.Data)
            {
                var values = new object[9];
                values[0] = item.StoreName;
                values[1] = item.OrderCode;
                values[2] = (item.Status==1)?"Giriş": (item.Status == 2)?"Onaylandı": (item.Status == 3)?"Kontrol Edildi":"Sevk Edildi";
                values[3] = item.OrderDate; //.ToString("dd.MM.yyyy");
                values[4] = item.ShipmentDate; // .ToString("dd.MM.yyyy");
                values[5] = item.LastApproveUser;
                values[6] = item.LastApproveTime; //.ToString("dd.MM.yyyy HH:mm:ss");
                values[7] = item.DispatchUser;
                values[8] = item.DispatchTime; //.ToString("dd.MM.yyyy HH:mm:ss");
                dt.Rows.Add(values);
            }
            
            byte[] excelData;
            using (var ms = new MemoryStream())
            {
                dt.ExportToExcel2(ms);
                excelData = ms.ToArray();
            }
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(excelData)
            };
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = $"Export_{"Orders"}_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
            };
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.ms-excel");

            return ResponseMessage(result);
        }

        [HttpGet]
        [OTControllerAction("Read")]
        [Route("GetShipmentDay")]
        public DateTime GetShipmentDay(long storeId)
        {
            return _dataService.getShipmentDay(storeId);
        }

        [HttpPost]
        [OTControllerAction("Update")]
        [Route("Dispatch")]
        public void Dispatch(Overtech.ViewModels.Warehouse.StoreOrder storeOrder)
        {
            _dataService.Dispatch(storeOrder.Map<Overtech.DataModels.Warehouse.StoreOrder, Overtech.ViewModels.Warehouse.StoreOrder>());
        }

        [HttpGet]
        [OTControllerAction("List")]
        [Route("GetOrderofDay")]
        public StoreOrder GetOrderofDay(long storeId, DateTime shipmentDay)
        {
            return _dataService.getOrderofDay(storeId, shipmentDay).Map< Overtech.DataModels.Warehouse.StoreOrder, StoreOrder>();
        }

        [HttpGet]
        [OTControllerAction("Read")]
        [Route("GetTime")]
        public DateTime GetTime()
        {
            return DateTime.Now;
        }

        [HttpGet]
        [Route("ListOrderSaleProductDetails")]
        [OTControllerAction("List")]
        public DataSourceResult ListOrderSaleProductDetails(long storeId, DateTime startDate, DateTime endDate)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListOrderSaleProductDetails(storeId, startDate, endDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListOrderSaleDateDetails")]
        [OTControllerAction("List")]
        public DataSourceResult ListOrderSaleDateDetails(long storeId, long productId, DateTime startDate, DateTime endDate)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListOrderSaleDateDetails(storeId, productId, startDate, endDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListOrderSaleStoreDetails")]
        [OTControllerAction("List")]
        public DataSourceResult ListOrderSaleStoreDetails(long productId, DateTime startDate, DateTime endDate)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListOrderSaleStoreDetails(productId, startDate, endDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ConstraintTheory")]
        [OTControllerAction("List")]
        public IList<DataSourceResult> ConstraintTheory(long storeId, long productId, DateTime startDate, DateTime endDate, decimal startBuffer, decimal shipmenUnit,
                int greenCycle, decimal bufferBandwith, bool ceiling)
        {
            DataSourceRequest request = new DataSourceRequest();
            IList<DataSourceResult> result = new List<DataSourceResult>();
            DataSet dtReport = null;
            dtReport = _dataService.ConstraintTheory(storeId, productId, startDate, endDate, startBuffer, shipmenUnit, greenCycle, bufferBandwith, ceiling);
            result.Add(dtReport.Tables[0].ToDataSourceResult(request));
            result.Add(dtReport.Tables[1].ToDataSourceResult(request));
            return result;
        }

        [HttpGet]
        [Route("TopSaleDayGroup")]
        [OTControllerAction("List")]
        public DataSourceResult TopSaleDayGroup(long storeId, long productId, DateTime startDate, DateTime endDate)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.TopSaleDayGroup(storeId, productId, startDate, endDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }


        [HttpGet]
        [Route("PrintOrders")]
        [OTControllerAction("List")]
        public IList<StoreOrder> PrintOrders(string orders)
        {
            var _params = Newtonsoft.Json.JsonConvert.DeserializeObject<ParamStoreOrder>(orders);
            IList<StoreOrder> returnList = new List<StoreOrder>();
            foreach (long orderId in _params.storeOrderId)
            {
                returnList.Add(_dataService.Read(orderId).Map<Overtech.DataModels.Warehouse.StoreOrder,StoreOrder>());
            }

            return returnList;
        }

        [HttpGet]
        [Route("PrintDetails")]
        [OTControllerAction("List")]
        public IList<StoreOrderDetail> PrintDetails(string orders)
        {
            var _params = Newtonsoft.Json.JsonConvert.DeserializeObject<ParamStoreOrder>(orders);
            IList<StoreOrderDetail> returnList = new List<StoreOrderDetail>();
            foreach (long orderId in _params.storeOrderId)
            {
                IEnumerable<StoreOrderDetail> res = _storeOrderDetailService.listStoreOrderDetails(orderId).Map<Overtech.DataModels.Warehouse.StoreOrderDetail, Overtech.ViewModels.Warehouse.StoreOrderDetail>();
                foreach (StoreOrderDetail sd in res)
                {
                    returnList.Add(sd);
                }
            }
            
            return returnList;
        }

        [HttpGet]
        [Route("ListOrders")]
        [OTControllerAction("List")]
        public IEnumerable<ViewModels.Warehouse.StoreOrder> ListOrders(string includeCompletedOrders, DateTime baseDate)
        {
            return _dataService.ListOrders(includeCompletedOrders, baseDate).Map<DataModels.Warehouse.StoreOrder, ViewModels.Warehouse.StoreOrder>();
        }

        [HttpGet]
        [Route("MikroShipmentControl")]
        [OTControllerAction("List")]
        public IEnumerable<ViewModels.Warehouse.StoreOrderDetail> MikroShipmentControl(long storeOrderId)
        {
            return _dataService.MikroShipmentControl(storeOrderId).Map<DataModels.Warehouse.StoreOrderDetail, ViewModels.Warehouse.StoreOrderDetail>();
        }

        [HttpPost]
        [OTControllerAction("Create")]
        [Route("AddProductsFromExcel")]
        public HttpResponseMessage AddProductsFromExcel(long storeOrderId)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                string result = "";
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    int FileLen = httpRequest.Files[0].ContentLength;
                    byte[] data = new byte[FileLen];
                    System.IO.Stream fileStream = httpRequest.Files[0].InputStream;
                    fileStream.Read(data, 0, FileLen);
                    _dataService.AddProductsFromExcel(data, storeOrderId);

                }
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StringContent(result);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("NoOrderStoreList")]
        [OTControllerAction("List")]
        public IEnumerable<ViewModels.Store.Store> NoOrderStoreList()
        {
            return _dataService.NoOrderStoreList().Map<DataModels.Store.Store, ViewModels.Store.Store>();
        }

        [HttpGet]
        [Route("StockDashboard")]
        [OTControllerAction("List")]
        public IEnumerable<DataSourceResult> StockDashboard()
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSet dtReport = null;
            dtReport = _dataService.StockDashboard();
            IEnumerable<DataSourceResult> result = (new[] {
                dtReport.Tables[0].ToDataSourceResult(request),
                dtReport.Tables[1].ToDataSourceResult(request),
                dtReport.Tables[2].ToDataSourceResult(request),
                dtReport.Tables[3].ToDataSourceResult(request)
            });
            return result;
        }

        [HttpGet]
        [Route("StockDashboardTrend")]
        [OTControllerAction("List")]
        public IEnumerable<DataSourceResult> StockDashboardTrend(string categoryName, string productName, string storeName)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSet dtReport = null;
            dtReport = _dataService.StockDashboardTrend(categoryName, productName, storeName);
            IEnumerable<DataSourceResult> result = (new[] {
                dtReport.Tables[0].ToDataSourceResult(request),
                dtReport.Tables[1].ToDataSourceResult(request)
            });
            return result;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}