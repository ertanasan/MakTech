using Overtech.DataModels.Warehouse;
using Overtech.Mutual.Store;
using Overtech.Service.Data.Uni;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.Mutual.Warehouse
{
    public class CountingOperations
    {
        private IDAL _dal;
        public DataTable ExcelTable;

        public CountingOperations(IDAL dal)
        {
            _dal = dal;
        }

        public void UpdateStockTaking (StockTaking dataObject)
        {
            StockTakingSchedule masterObject = _dal.Read<StockTakingSchedule>(dataObject.StockTakingSchedule);
            if (masterObject.CountingType == 2)
            {
                StoreOperations stOp = new StoreOperations(_dal);
                if (!stOp.TimeControl(1, DateTime.Now.Hour, masterObject.Store))
                {
                    throw new Exception("Sondaj sayım giriş işlemleri bu saatte yapılamamaktadır.");
                }
            }
            _dal.Update(dataObject);

        }
    }
}
