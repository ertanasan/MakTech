using CsvHelper;
using Overtech.Core.Logger;
using Overtech.Core.Threading;
using Overtech.DataModels.Accounting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Overtech.ServiceContracts.Accounting;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Http;

namespace Overtech.Shared.Daemon.OverStore
{

    class EInvoiceClientLoadWorker : DualWorker<IEnumerable<EInvoiceClient>>
    {
        
        private readonly ISaleInvoiceService _saleInvoiceService;

        public EInvoiceClientLoadWorker(
           ILoggerFactory loggerFactory,
           IDictionary<string, string> parameters, string name,
           ISaleInvoiceService saleInvoiceService
           ) : base(loggerFactory, parameters, name)
        {
            _saleInvoiceService = saleInvoiceService;
        }

        public override void ProcessItem(IEnumerable<EInvoiceClient> item)
        {
            throw new NotSupportedException("Processing is not supported by this worker.");
        }

        

        public override bool TryFetchItem(out IEnumerable<EInvoiceClient> item)
        {
            try
            {
                _saleInvoiceService.ProcessCashRegisterEInvoice();
                item = null;
                return false;
            }
            catch (Exception ex)
            {
                _logger.Error("Trying to fetch EInvoiceClient", ex);
                _cancelSpinEvent.WaitOne(10000);
                item = null;
                return false;
            }
        }
    }
}
