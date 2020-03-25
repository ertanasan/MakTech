using Overtech.DataModels.Helpdesk;
using Overtech.DataModels.Warehouse;
using Overtech.Service;
using Overtech.ServiceContracts.Helpdesk;
using Overtech.ServiceContracts.Warehouse;
using Overtech.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.Shared.OverStore.ProcessInvoker
{
    public class HelpdeskInvoker
    {
        private readonly Lazy<IHelpdeskRequestService> _helpdeskRequestService;

        public HelpdeskInvoker()
        {
            OTConfiguration.Configure<OTUnityConfig>();
            OTConfiguration.Configure<OTCacheConfig>();

            _helpdeskRequestService = new Lazy<IHelpdeskRequestService>(() => new OTChannelFactory<HelpdeskRequest>().CreateChannel<IHelpdeskRequestService>());
        }

        public void UpdateStatus(long requestId, int statusId)
        {
            try
            {
                _helpdeskRequestService.Value.UpdateStatus(requestId, statusId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}