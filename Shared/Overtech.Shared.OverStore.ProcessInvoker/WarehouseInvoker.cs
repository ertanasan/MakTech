using Overtech.DataModels.Warehouse;
using Overtech.Service;
using Overtech.ServiceContracts.Warehouse;
using Overtech.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.Shared.OverStore.ProcessInvoker
{
    public class WarehouseInvoker
    {
        private readonly Lazy<IProductReturnService> _productReturnService;
        private readonly Lazy<ITransferProductService> _transferProductService;
        private readonly Lazy<IProductionOrderService> _productionOrderService;

        public WarehouseInvoker()
        {
            OTConfiguration.Configure<OTUnityConfig>();
            OTConfiguration.Configure<OTCacheConfig>();

            _productReturnService = new Lazy<IProductReturnService>(() => new OTChannelFactory<ProductReturn>().CreateChannel<IProductReturnService>());
            _transferProductService = new Lazy<ITransferProductService>(() => new OTChannelFactory<TransferProduct>().CreateChannel<ITransferProductService>());
            _productionOrderService = new Lazy<IProductionOrderService>(() => new OTChannelFactory<ProductionOrder>().CreateChannel<IProductionOrderService>());
        }

        public void UpdateStatus(long requestId, int statusId)
        {
            try
            {
                _productReturnService.Value.UpdateStatus(requestId, statusId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateProductionOrderStatus(long requestId, int statusId)
        {
            try
            {
                _productionOrderService.Value.UpdateStatus(requestId, statusId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateTransferProductStatus(long requestId, long statusId)
        {
            try
            {
                _transferProductService.Value.UpdateStatus(requestId, statusId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void TransferToMikro(long requestId, long statusId, bool toWarehouse)
        {
            try
            {
                _transferProductService.Value.TransferToMikro(requestId, statusId, toWarehouse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
