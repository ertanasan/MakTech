// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Price;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Price
{
    [ServiceContract]
    public interface IPriceLabelService : ICRUDLServiceContract<Overtech.DataModels.Price.LabelPrice>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        //[OperationContract]
        //IEnumerable<PriceVersion> ListPriceVersions();

        [OperationContract]
        IEnumerable<LabelPrice> ListPriceLabel(/*long packageVersionID*/);


        [OperationContract]
        IEnumerable<int> ListPriceLabelChecked(string pS);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

