// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Accounting;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Accounting
{
    [ServiceContract]
    public interface ILoomisService : ICRUDLServiceContract<Overtech.DataModels.Accounting.Loomis>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        void LoadLoomisFile(byte[] formData);

        [OperationContract]
        IEnumerable<Loomis> ListDay(DateTime saleDate);

        [OperationContract]
        void MikroTransfer(DateTime saleDate, long[] LoomisIdList);

        [OperationContract]
        void CancelMikroTransfer(DateTime SaleDate);

        [OperationContract]
        void ClearDate(DateTime SaleDate);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

