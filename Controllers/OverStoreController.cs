using Overtech.Core.Application;
using Overtech.DataModels.StoreUpload;
using Overtech.ServiceContracts.StoreUpload;
using Overtech.DataModels.Price;
using Overtech.ServiceContracts.Price;
using Overtech.DataModels.Store;
using Overtech.ServiceContracts.Store;
using Overtech.ServiceContracts.Product;
using Overtech.Shared.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Overtech.Service.Data.Uni;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;
using System.Data;
using Newtonsoft.Json;
using Overtech.Service.Authorization;
using Overtech.Core.OverStore;
using Overtech.Core.Logger;
using Overtech.ServiceContracts.Warehouse;
using Overtech.DataModels.Warehouse;

namespace Overtech.Gateways.OverStore.Controllers
{

    public class HotKey
    {
        public int HotKeyId { get; set; }
        public int Code { get; set; }
        public string ProductName { get; set; }
    }

    public class StoreList
    {
        public long StoreId { get; set; }
        public string StoreName { get; set; }
    }

    [RoutePrefix("api/OverStore")]
    public class OverStoreController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IDataUploadService _dataUploadService;
        private readonly IParameterReader _parameterReader;
        private readonly IUploadTypeService _uploadTypeService;
        private readonly IStatusService _statusService;
        //private readonly IPackageDetailService _packageDetailService;
        private readonly IStoreCashRegisterService _storeCashRegisterService;
        private readonly IStoreScalesService _storeScaleService;
        private readonly IProductPriceService _productPriceService;
        private readonly ICurrentPricesService _currentPriceService;
        private readonly IStoreService _storeService;
        private readonly IProductService _productService;
        private readonly ICashierService _cashierService;
        private readonly IStorageZonesService _storageZonesService;
        private readonly IStockTakingScheduleService _stockTakingScheduleService;
        private readonly IStockTakingService _stockTakingService;
        private readonly IStoreOrderService _storeOrderService;

        public OverStoreController(
            ILoggerFactory loggerFactory,
            IDataUploadService dataUploadService,
            IParameterReader parameterReader,
            IUploadTypeService uploadTypeService,
            IStatusService statusService,
            //IPackageDetailService packageDetailService,
            IStoreCashRegisterService storeCashRegisterService,
            IStoreScalesService storeScaleService,
            IProductPriceService productPriceService,
            ICurrentPricesService currentPriceService,
            IStoreService storeService,
            IProductService productService,
            ICashierService cashierService,
            IStorageZonesService storageZonesService,
            IStockTakingScheduleService stockTakingScheduleService,
            IStockTakingService stockTakingService,
            IStoreOrderService storeOrderService
            )
        {
            _logger = loggerFactory.GetLogger(typeof(OverStoreController));
            _dataUploadService = dataUploadService;
            _parameterReader = parameterReader;
            _uploadTypeService = uploadTypeService;
            _statusService = statusService;
            //_packageDetailService = packageDetailService;
            _storeCashRegisterService = storeCashRegisterService;
            _storeScaleService = storeScaleService;
            _productPriceService = productPriceService;
            _currentPriceService = currentPriceService;
            _storeService = storeService;
            _productService = productService;
            _cashierService = cashierService;
            _storageZonesService = storageZonesService;
            _stockTakingScheduleService = stockTakingScheduleService;
            _stockTakingService = stockTakingService;
            _storeOrderService = storeOrderService;
        }

        [Route("ZetValue/{cashRegisterId}/{transactionDate}")]
        [AllowAuthenticated]
        [HttpGet]
        public bool Get(int cashRegisterId, DateTime transactionDate)
        {
            var storezet = _dataUploadService.GetZetData(cashRegisterId, transactionDate);
            if (storezet == null)
                return false;
            else
                return true;
            
        }

        [Route("CheckStoreZet/{storeId}/{transactionDate}")]
        [AllowAuthenticated]
        [HttpGet]
        public bool CheckStoreZet(int storeId, DateTime transactionDate)
        {
            var storezet = _dataUploadService.CheckStoreZet(storeId, transactionDate);
            if (storezet == null)
                return false;
            else
                return true;

        }

        [Route("StoreCashRegisters/{storeId}")]
        [AllowAuthenticated]
        [HttpGet]
        public IEnumerable<StoreCashRegister> ListStoreCashRegisters(int storeId)
        {
            try
            {
                IEnumerable<StoreCashRegister> returnvalue = _storeCashRegisterService.StoreCashRegisters(storeId);
                return returnvalue;
            }
            catch (Exception ex)
            {
                _logger.Error($"ListStoreCashRegisters : {ex.ToString()}");
                throw ex;
            }
        }

        [Route("StoreScales/{storeId}")]
        [AllowAuthenticated]
        [HttpGet]
        public IEnumerable<StoreScales> ListStoreScales(int storeId)
        {
            return _storeScaleService.StoreScales(storeId);
        }

        [Route("Cashiers/{storeId}")]
        [AllowAuthenticated]
        [HttpGet]
        public IEnumerable<Cashier> ListStoreCashiers(int storeId)
        {
            return _cashierService.StoreCashiers(storeId);
        }

        [Route("StoreCashRegisterBrands/{storeId}")]
        [AllowAuthenticated]
        [HttpGet]
        public IEnumerable<CashRegisterBrand> ListStoreCashRegisterBrands(int storeId)
        {
            try
            {
                IEnumerable<CashRegisterBrand> returnvalue = _storeService.ListStoreCashRegisterBrands(storeId);
                return returnvalue;
            }
            catch (Exception ex)
            {
                _logger.Error($"ListStoreCashRegisterBrands : {ex.ToString()}");
                throw ex;
            }
        }

        [Route("StoreScaleBrands/{storeId}")]
        [AllowAuthenticated]
        [HttpGet]
        public IEnumerable<ScaleBrand> ListStoreScaleBrands(int storeId)
        {
            try
            {
                IEnumerable<ScaleBrand> returnvalue = _storeService.ListStoreScaleBrands(storeId);
                return returnvalue;
            }
            catch (Exception ex)
            {
                _logger.Error($"ListStoreScaleBrands : {ex.ToString()}");
                throw ex;
            }
        }

        [Route("CashRegisterSalePrices/{storeId}")]
        [AllowAuthenticated]
        [HttpGet]
        public IEnumerable<ProductPrice> GetCashRegisterSalePrices(int storeId)
        {
            return _productPriceService.getNewPrices(1, storeId, 0);
        }

        [Route("ScaleSalePrices/{storeId}")]
        [AllowAuthenticated]
        [HttpGet]
        public IEnumerable<ProductPrice> GetScaleSalePrices(int storeId)
        {
            return _productPriceService.getNewPrices(2, storeId, 0);
        }

        [Route("HotKeys")]
        [AllowAuthenticated]
        [HttpGet]
        public List<HotKey> ListHotKeys()
        {
            DataTable dt =_productService.ListHotKeys();
            List<HotKey> hotkeyList = new List<HotKey>();
            foreach (DataRow dr in dt.Rows)
            {
                HotKey h = new HotKey();
                h.HotKeyId = int.Parse(dr["HOTKEY"].ToString());
                h.Code = int.Parse(dr["CODE"].ToString());
                h.ProductName = dr["PRODUCTNAME"].ToString();
                hotkeyList.Add(h);
            }
            return hotkeyList;
        }

        [Route("HotKeys32")]
        [AllowAuthenticated]
        [HttpGet]
        public List<HotKey> ListHotKeys32()
        {
            DataTable dt = _productService.ListHotKeys32();
            List<HotKey> hotkeyList = new List<HotKey>();
            foreach (DataRow dr in dt.Rows)
            {
                HotKey h = new HotKey();
                h.HotKeyId = int.Parse(dr["HOTKEY"].ToString());
                h.Code = int.Parse(dr["CODE"].ToString());
                h.ProductName = dr["PRODUCTNAME"].ToString();
                hotkeyList.Add(h);
            }
            return hotkeyList;
        }

        [Route("HotKeys56")]
        [AllowAuthenticated]
        [HttpGet]
        public List<HotKey> ListHotKeys56()
        {
            DataTable dt = _productService.ListHotKeys56();
            List<HotKey> hotkeyList = new List<HotKey>();
            foreach (DataRow dr in dt.Rows)
            {
                HotKey h = new HotKey();
                h.HotKeyId = int.Parse(dr["HOTKEY"].ToString());
                h.Code = int.Parse(dr["CODE"].ToString());
                h.ProductName = dr["PRODUCTNAME"].ToString();
                hotkeyList.Add(h);
            }
            return hotkeyList;
        }

        [Route("StoreCurrentPrices/{storeId}/{groupCode}")]
        [AllowAuthenticated]
        [HttpGet]
        public IEnumerable<CurrentPrices> ListStoreCurrentPrices(int storeId, int groupCode)
        {
            return _currentPriceService.ListStoreCurrentPrices(storeId, groupCode);
        }

        [Route("GetMissingDays/{storeId}")]
        [AllowAuthenticated]
        [HttpGet]
        public IEnumerable<StoreMissingDays> GetMissingDays(long storeId)
        {
            return _dataUploadService.GetMissingDays(storeId);
        }

        [Route("GetStoreList")]
        [AllowAuthenticated]
        [HttpGet]
        public List<StoreList> GetStoreList()
        {
            IEnumerable<Store> s = _storeService.List();
            List<StoreList> sl = new List<StoreList>();
            foreach (Store st in s)
            {
                if (st.ActiveFlag)
                {
                    sl.Add(new StoreList() { StoreId = st.StoreId, StoreName = st.Name });
                }
            }
            return sl;
        }

        [Route("GetStoreCountingSchedules/{storeId}")]
        [AllowAuthenticated]
        [HttpGet]
        public IEnumerable<StockTakingSchedule> GetStoreCountingSchedules(long storeId)
        {
            return _stockTakingScheduleService.ActiveStoreSchedules(storeId);
        }

        [Route("GetCountingZoneList")]
        [AllowAuthenticated]
        [HttpGet]
        public IEnumerable<StorageZones> GetCountingZoneList()
        {
            IEnumerable<StorageZones> s = _storageZonesService.ZoneList(1);
            return s;
        }

        // [Route("InsertFromBarcodeReader/{scheduleId}/{zoneId}/{opCode}/{eanCode}")]
        // [AllowAuthenticated]
        // [HttpGet]
        // public IHttpActionResult InsertFromBarcodeReader(long scheduleId, int zoneId, int opCode, string eanCode)
        // {
        //     try
        //     {
        //         _stockTakingService.InsertFromBarcodeReader(scheduleId, zoneId, opCode, eanCode);
        //         return base.Ok();
        //     }
        //     catch (Exception ex)
        //     {
        //         return Content(HttpStatusCode.InternalServerError, ex.ToString());
        //     }
        // }

        [Route("InsertStoreTraceLog/{storeId}/{traceText}")]
        [AllowAuthenticated]
        [HttpGet]
        public void InsertStoreTraceLog(int storeId, string traceText)
        {
            _dataUploadService.InsertStoreTraceLog(storeId, traceText);
        }


        [Route("UpdateScaleStatus")]
        [AllowAuthenticated]
        [HttpPost]
        public IHttpActionResult UpdateScaleStatus([FromBody] StoreScales sc)
        {
            try
            {
                // sc.Status = newStatus;
                // sc.StatusText = newStatusText;
                _storeScaleService.Update(sc);
                return base.Ok();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("GetDeListProducts")]
        [AllowAuthenticated]
        [HttpGet]
        public DataTable GetDeListProducts()
        {
            return _productPriceService.GetDeListProducts();
        }

        [Route("UploadCashRegisterData/{cashRegisterId}/{uploadTypeId}")]
        [AllowAuthenticated]
        [HttpPost]
        public IHttpActionResult Post(long cashRegisterId, int uploadTypeId, [FromBody]byte[] compressedData)
        {
            try
            {
                _logger.Debug($"UploadCashRegisterData: cashRegisterId={ cashRegisterId }, dataLength={ compressedData.Length } starting...");

                // var uploadType = _uploadTypeService.List().First(u => u.Name == "CashRegister");
                var status = _statusService.Find("New");
                // _logger.Debug($"1, cashRegisterId : {cashRegisterId}");
                var dataUpload = new DataUpload
                {
                    Event = _parameterReader.ReadEventId("StoreDataUpload", 1),
                    Organization = OTApplication.Context.Organization.Id,
                    UploadDate = DateTime.Now,
                    UploadType = uploadTypeId,
                    CompressedData = compressedData,
                    SourceRef = cashRegisterId.ToString(),
                    Status = status.StatusId
                };
                // _logger.Debug($"2, cashRegisterId : {cashRegisterId}");
                _dataUploadService.Create(dataUpload);

                _logger.Debug($"UploadCashRegisterData: cashRegisterId={ cashRegisterId }, dataLength={ compressedData.Length } completed.");
                return base.Ok();
            }
            catch (Exception ex)
            {
                _logger.Error($"UploadCashRegisterData failed. cashRegisterId : {cashRegisterId} uploadTypeId : {uploadTypeId}", ex);
                return Content(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("GetWaybillInfo/{storeOrderId}")]
        [AllowAuthenticated]
        [HttpGet]
        public DataTable GetWaybillInfo(long storeOrderId)
        {
            return _storeOrderService.GetWaybillInfo(storeOrderId);
        }
    }
}