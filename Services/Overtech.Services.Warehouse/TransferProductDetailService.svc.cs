// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Warehouse;
using Overtech.ServiceContracts.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class TransferProductDetailService : CRUDLDataService<Overtech.DataModels.Warehouse.TransferProductDetail>, ITransferProductDetailService
    {
        /*Section="Constructor-1"*/
        public TransferProductDetailService()
        {
        }

        /*Section="Constructor-2"*/
        internal TransferProductDetailService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.

        public virtual IEnumerable<TransferProductDetail> CreateAll(IEnumerable<TransferProductDetail> dataObjects)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    TransferProduct transferProduct = null;
                    if (dataObjects.Count() > 0)
                    {
                        transferProduct = dal.Read<TransferProduct>(dataObjects.First().TransferProduct);
                    }

                    // Create via DAL and return the object with id
                    foreach (TransferProductDetail td in dataObjects) {
                        long objectId = dal.Create<TransferProductDetail>(td);
                        td.SetId(objectId);
                        if (transferProduct != null && transferProduct.TransferStatus == 5)
                        {
                            IUniParameter prmTransferProductDetail = dal.CreateParameter("TransferProductDetailId", td.TransferProductDetailId);
                            dal.ExecuteNonQuery("WHS_INS_WAYBILLBYTRANSFERPRODUCTDETAIL_SP", prmTransferProductDetail);
                        }
                    }
                    dal.CommitTransaction();
                   // dataObject.SetId(objectId);
                    return dataObjects;
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public virtual void UpdateAll(IEnumerable<TransferProductDetail> dataObjects)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    TransferProduct transferProduct = null;
                    if (dataObjects.Count() > 0)
                    {
                        transferProduct = dal.Read<TransferProduct>(dataObjects.First().TransferProduct);
                    }

                    // Update via DAL
                    foreach (TransferProductDetail td in dataObjects)
                    {
                        dal.Update<TransferProductDetail>(td);
                        if (transferProduct != null && transferProduct.TransferStatus == 5)
                        {
                            IUniParameter prmTransferProductDetail = dal.CreateParameter("TransferProductDetailId", td.TransferProductDetailId);
                            dal.ExecuteNonQuery("WHS_UPD_WAYBILLBYTRANSFERPRODUCTDETAIL_SP", prmTransferProductDetail);
                        }
                    }
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public virtual void DeleteAll(IEnumerable<long> objectIds)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    TransferProduct transferProduct = null;
                    if (objectIds.Count() > 0)
                    {
                        TransferProductDetail td = dal.Read<TransferProductDetail>(objectIds.First());
                        transferProduct = dal.Read<TransferProduct>(td.TransferProduct);
                    }

                    // Delete via DAL
                    foreach (long id in objectIds)
                    {
                        dal.Delete<TransferProductDetail>(id);
                        if (transferProduct != null && transferProduct.TransferStatus == 5)
                        {
                            IUniParameter prmTransferProductDetail = dal.CreateParameter("TransferProductDetailId", id);
                            dal.ExecuteNonQuery("WHS_DEL_WAYBILLBYTRANSFERPRODUCTDETAIL_SP", prmTransferProductDetail);
                        }
                    }
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }
    }

    #endregion Customized

    /*Section="ClassFooter"*/
}
