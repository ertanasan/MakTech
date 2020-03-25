using Overtech.DataModels.Product;
using Overtech.DataModels.Warehouse;
using Overtech.Mutual.Accounting;
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
    public class OrderOperations
    {
        private IDAL _dal;
        public DataTable ExcelTable;

        public OrderOperations(IDAL dal)
        {
            _dal = dal;
        }

        public void AddProductsFromExcel(byte[] formData, long storeOrderId)
        {
            try
            {
                ExcelOperations exOp = new ExcelOperations(_dal);
                string result = exOp.ReadExceltoDataTable(formData, "OrderProducts", 1);
                if (result.Length == 0)
                {
                    DataTable dt = exOp.ExcelTable;

                    IUniParameter prmStoreOrderId = _dal.CreateParameter("StoreOrderId", storeOrderId);
                    IEnumerable<StoreOrderDetail> details = _dal.List<StoreOrderDetail>("WHS_LST_STOREORDERDETAIL_SP", prmStoreOrderId).ToList();
                    IEnumerable<Product> products = _dal.List<Product>("PRD_LST_PRODUCT_SP").ToList();

                    foreach (DataRow dr in dt.Rows)
                    {
                        var detailRow = details.Where<StoreOrderDetail>(detail => detail.ProductCode == dr[0].ToString()).FirstOrDefault();
                        if (detailRow != null)
                        {
                            var product = products.Where<Product>(row => row.Code == dr[0].ToString()).First();
                            if (detailRow.StoreOrderDetailId > 0)
                            {
                                detailRow.OrderQuantity = (decimal)dr[2] / product.PackageQuantity; 
                                _dal.Update<StoreOrderDetail>(detailRow);
                            }
                            else
                            {
                                detailRow.StoreOrder = storeOrderId;
                                detailRow.Product = product.ProductId;
                                detailRow.OrderQuantity = (decimal)dr[2] / product.PackageQuantity;
                                detailRow.ShippedQuantity = (decimal)dr[2] / product.PackageQuantity;
                                detailRow.RevisedQuantity = (decimal)dr[2] / product.PackageQuantity;
                                detailRow.IntakeQuantity = (decimal)dr[2] / product.PackageQuantity;
                                detailRow.PackageQuantity = product.PackageQuantity;
                                _dal.Create<StoreOrderDetail>(detailRow);
                            }
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
