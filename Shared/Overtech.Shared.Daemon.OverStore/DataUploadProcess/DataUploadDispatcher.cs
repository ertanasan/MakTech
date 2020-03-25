using Overtech.Core.Logger;
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
    public class DataUploadDispatcher : FetchWorker<IEnumerable<DataUpload>>
    {
        private readonly IDataUploadService _dataUploadService;

        public DataUploadDispatcher(
            ILoggerFactory loggerFactory, 
            IDictionary<string, string> parameters, string name,
            IDataUploadService dataUploadService) 
            : base(loggerFactory, parameters, name)
        {
            _dataUploadService = dataUploadService;
        }

        public override bool TryFetchItem(out IEnumerable<DataUpload> item)
        {
            try
            {
                _logger.Debug($"Trying to fetch data upload items to process.");
                item = _dataUploadService.ListNewToProcess();
                _logger.Debug($"Fetch complete.");
                return item.Any();
            }
            catch (Exception ex)
            {
                _logger.Error("Unable to fetch data upload items to process.", ex);
                // Wait a little to prevent high CPU situations
                _cancelSpinEvent.WaitOne(10000);
                item = null;
                return false;
            }
        }
    }
}
