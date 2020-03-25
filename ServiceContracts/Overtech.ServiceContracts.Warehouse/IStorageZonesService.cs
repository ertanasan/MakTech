// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Warehouse
{
    [ServiceContract]
    public interface IStorageZonesService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.StorageZones>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<StorageZones> ZoneList(int store);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

