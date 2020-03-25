using Overtech.DataModels.Accounting;
using Overtech.Service;
using Overtech.ServiceContracts.Accounting;
using Overtech.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.Shared.OverStore.ProcessInvoker
{
    public class AccountingInvoker
    {
        
        private readonly Lazy<ISaleInvoiceService> _saleInvoiceService;

        public AccountingInvoker()
        {
            OTConfiguration.Configure<OTUnityConfig>();
            OTConfiguration.Configure<OTCacheConfig>();

            _saleInvoiceService = new Lazy<ISaleInvoiceService>(() => new OTChannelFactory<SaleInvoice>().CreateChannel<ISaleInvoiceService>());
        }

        public void UpdateStatus(long requestId, int statusId)
        {
            try
            {
                _saleInvoiceService.Value.UpdateStatus(requestId, statusId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
