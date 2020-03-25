using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Overtech.DataModels.OverStoreMain;
using Overtech.Service;
using Overtech.ServiceContracts.OverStoreMain;
using Overtech.Shared.Configuration;

namespace Overtech.Shared.OverStore.ProcessInvoker
{
    public class OverStoreMainInvoker
    {
        private readonly Lazy<IOverStoreTaskService> _taskService;

        public OverStoreMainInvoker()
        {
            OTConfiguration.Configure<OTUnityConfig>();
            OTConfiguration.Configure<OTCacheConfig>();

            _taskService = new Lazy<IOverStoreTaskService>(() => new OTChannelFactory<OverStoreTask>().CreateChannel<IOverStoreTaskService>());
        }

        public void UpdateTaskStatus(long requestId, long statusId)
        {
            try
            {
                _taskService.Value.UpdateStatus(requestId, statusId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public int GetAssignmentType(long requestId)
        {
            try
            {
                return _taskService.Value.GetAssignmentType(requestId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public long GetTaskResponsibleId(long requestId)
        {
            try
            {
                return _taskService.Value.GetTaskResponsibleId(requestId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
