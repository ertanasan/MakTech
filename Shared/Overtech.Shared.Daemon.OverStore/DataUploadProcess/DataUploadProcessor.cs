using Overtech.Core;
using Overtech.Core.Cache;
using Overtech.Core.Logger;
using Overtech.Core.OverStore;
using Overtech.Core.Threading;
using Overtech.DataModels.StoreUpload;
using Overtech.ServiceContracts.StoreUpload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.Shared.Daemon.OverStore
{
    public class DataUploadProcessor : PerformWorker<IEnumerable<DataUpload>>
    {
        private readonly IDataUploadService _dataUploadService;
        private readonly IUploadTypeService _uploadTypeService;

        public DataUploadProcessor(
            ILoggerFactory loggerFactory, 
            IDictionary<string, string> parameters,
            string name,
            IDataUploadService dataUploadService,
            IUploadTypeService uploadTypeService) 
            : base(loggerFactory, parameters, name)
        {
            _dataUploadService = dataUploadService;
            _uploadTypeService = uploadTypeService;
        }

        public override void ProcessItem(IEnumerable<DataUpload> item)
        {
            try
            {
                var uploadTypes = OTCache.Instance.GetCached(() => _uploadTypeService.List(), "StoreUpload-UploadType", TimeSpan.FromMinutes(10));

                foreach (var dataUpload in item)
                {
                    switch (uploadTypes.Single(u => u.UploadTypeId == dataUpload.UploadType).UploadTypeId)
                    {
                        case 1 :
                            processCashRegister(dataUpload);
                            break;
                        case 2 :
                            processCashRegister(dataUpload);
                            break;
                        case 4 :
                            processCashRegister(dataUpload);
                            break;
                        default:
                            _logger.Warn($"Unimplemented upload type to process for data upload {dataUpload.DataUploadId}.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Unexpected processing error occured for data upload processor.", ex);
                // Wait a little to prevent high CPU situations
                _cancelSpinEvent.WaitOne(30000);
            }
        }

        private void processCashRegister(DataUpload dataUpload)
        {
            try
            {
                _logger.Debug($"Process File started : {DateTime.Now.ToString("yyyy-MM-dd hh24:mm:ss")} sourceRef : {dataUpload.SourceRef} uploadId : {dataUpload.DataUploadId}");
                _dataUploadService.ProcessFile(dataUpload);
                _logger.Debug($"Process File ended : {DateTime.Now.ToString("yyyy-MM-dd hh24:mm:ss")} sourceRef : {dataUpload.SourceRef} uploadId : {dataUpload.DataUploadId}");

                dataUpload.Status = DataUploadStatus.Processed.To<long>();
                _dataUploadService.Update(dataUpload);
            }
            catch (Exception ex)
            {
                _logger.Error($"Unable to complete cash register parsing for data upload {dataUpload.DataUploadId}.", ex);
                try
                {
                    dataUpload.Status = DataUploadStatus.Failed.To<long>();
                    _dataUploadService.Update(dataUpload);
                }
                catch (Exception ex2)
                {
                    _logger.FatalError($"Status update failed for data upload {dataUpload.DataUploadId}.", ex2);
                }
            }
        }
    }
}
