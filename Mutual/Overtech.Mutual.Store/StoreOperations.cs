using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Store;
using Overtech.Core.Data;
using Overtech.Core.Organization;
using Overtech.DataModels.Organization;

namespace Overtech.Mutual.Store
{
    public class StoreOperations
    {
        private IDAL _dal;

        public StoreOperations(IDAL dal)
        {
            _dal = dal;
        }

        public IEnumerable<Overtech.DataModels.Store.Store> ListActiveStores()
        {
            return _dal.List<Overtech.DataModels.Store.Store>("STR_LST_ACTIVESTORES_SP").ToList();
        }

        public IEnumerable<Overtech.DataModels.Store.Store> ListOverStores()
        {
            return _dal.List<Overtech.DataModels.Store.Store>("STR_LST_OVERSTORES_SP").ToList();
        }

        public Overtech.DataModels.Store.Store getStore(long branchID)
        {
            IUniParameter prmStoreID = _dal.CreateParameter("Branch", branchID);
            Overtech.DataModels.Store.Store store = _dal.Read<Overtech.DataModels.Store.Store>("STR_SEL_FINDSTORE_SP", prmStoreID);
            return store;
        }

        public bool TimeControl (int actionId, int time, long store)
        {
            IUniParameter prmActionId = _dal.CreateParameter("ActionId", actionId);
            IEnumerable<ProhibitedHours> ph = _dal.List<ProhibitedHours>("STR_LST_PROHIBITEDHOURS_SP", prmActionId).ToList();

            var storeph = ph.Where(o => (o.StoreCode == store));

            if (storeph.Count() > 0)
            {
                foreach (ProhibitedHours h in storeph)
                {
                    if (time >= h.StartHour && time <= h.EndHour) return false;
                }
            } else
            {
                foreach (ProhibitedHours h in ph)
                {
                    bool storeControl = (h.StoreCode == -1 || (h.StoreCode == -2 && store != 999) || h.StoreCode == store);
                    if (storeControl && time >= h.StartHour && time <= h.EndHour) return false;
                }
            }
            
            return true;
        }
        
        public Employee ReadEmployee(long employeeId)
        {
            return _dal.Read<Employee>(employeeId);
        }

        public void CreateEmployee(Employee e)
        {
            _dal.Create(e);
        }

        public void UpdateEmployee(Employee e)
        {
            _dal.Update(e);
        }

    }
}
