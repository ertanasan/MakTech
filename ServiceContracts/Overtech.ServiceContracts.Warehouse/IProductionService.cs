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
    public interface IProductionService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.Production>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<ProductionContent> ListProductionContents(long productionId);

        [OperationContract]
        IEnumerable<ProductionContent> ListProductionContentswithStocks(long productionId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

