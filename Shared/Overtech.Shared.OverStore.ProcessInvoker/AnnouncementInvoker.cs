using Overtech.DataModels.Announcement;
using Overtech.Service;
using Overtech.ServiceContracts.Announcement;
using Overtech.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.Shared.OverStore.ProcessInvoker
{
    public class AnnouncementInvoker
    {
        private readonly Lazy<ISuggestionService> _suggestionService;

        public AnnouncementInvoker()
        {
            OTConfiguration.Configure<OTUnityConfig>();
            OTConfiguration.Configure<OTCacheConfig>();

            _suggestionService = new Lazy<ISuggestionService>(() => new OTChannelFactory<Suggestion>().CreateChannel<ISuggestionService>());
        }

        public void UpdateStatus(long requestId, long statusId)
        {
            try
            {
                _suggestionService.Value.UpdateStatus(requestId, statusId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
