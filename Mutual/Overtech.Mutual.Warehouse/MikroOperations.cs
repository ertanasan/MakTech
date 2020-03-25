using Overtech.Service.Data.Uni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Overtech.DataModels.Warehouse;

namespace Overtech.Mutual.Warehouse
{
    public class MikroOperations
    {
        private IDAL _dal;

        public MikroOperations(IDAL dal)
        {
            _dal = dal;
        }

        public void CreateWaybill(MikroWaybill dataObject)
        {
            IUniParameter prmTransactionDate = _dal.CreateParameter("TransactionDate", dataObject.TransactionDate);
            IUniParameter prmDocumentSerial = _dal.CreateParameter("DocumentSerial", dataObject.DocumentSerial);
            IUniParameter prmDocumentNo = _dal.CreateParameter("DocumentNo", dataObject.DocumentNo);
            IUniParameter prmDocumentRowNo = _dal.CreateParameter("DocumentRowNo", dataObject.DocumentRowNo);
            IUniParameter prmDocumentInfo = _dal.CreateParameter("DocumentInfo", dataObject.DocumentInfo);
            IUniParameter prmTransactionType = _dal.CreateParameter("TransactionType", dataObject.TransactionType);
            IUniParameter prmTransactionKind = _dal.CreateParameter("TransactionKind", dataObject.TransactionKind);
            IUniParameter prmIsRefund = _dal.CreateParameter("IsRefund", dataObject.IsRefund?1:0);
            IUniParameter prmDocumentType = _dal.CreateParameter("DocumentType", dataObject.DocumentType);
            IUniParameter prmDocumentDate = _dal.CreateParameter("DocumentDate", dataObject.DocumentDate);
            IUniParameter prmProductCode = _dal.CreateParameter("ProductCode", dataObject.ProductCode);
            IUniParameter prmQuantity = _dal.CreateParameter("Quantity", dataObject.Quantity);
            IUniParameter prmVATCode = _dal.CreateParameter("VATCode", dataObject.VATCode);
            IUniParameter prmDescription = _dal.CreateParameter("Description", dataObject.Description);
            IUniParameter prmReceiverWarehouse = _dal.CreateParameter("ReceiverWarehouse", dataObject.ReceiverWarehouse);
            IUniParameter prmSenderWarehouse = _dal.CreateParameter("SenderWarehouse", dataObject.SenderWarehouse);
            IUniParameter prmIntakeShipmentDate = _dal.CreateParameter("IntakeShipmentDate", dataObject.IntakeShipmentDate);

            _dal.ExecuteNonQuery("MIK_INS_WAYBILL_SP", prmTransactionDate, prmDocumentSerial, prmDocumentNo, prmDocumentRowNo, prmDocumentInfo, prmTransactionType,
                prmTransactionKind, prmIsRefund, prmDocumentType, prmDocumentDate, prmProductCode, prmQuantity, prmVATCode, prmDescription, prmReceiverWarehouse,
                prmSenderWarehouse, prmIntakeShipmentDate);

        }

        public IEnumerable<MikroWaybill> ReadWaybill(DateTime dt, string documentSerial, int documentNo)
        {
            IUniParameter prmTransactionDate = _dal.CreateParameter("TransactionDate", dt);
            IUniParameter prmDocumentSerial = _dal.CreateParameter("DocumentSerial", documentSerial);
            IUniParameter prmDocumentNo = _dal.CreateParameter("DocumentNo", documentNo);
            return _dal.List<MikroWaybill>("MIK_LST_WAYBILL_SP", prmTransactionDate, prmDocumentSerial, prmDocumentNo).ToList();
        }
    }
}
