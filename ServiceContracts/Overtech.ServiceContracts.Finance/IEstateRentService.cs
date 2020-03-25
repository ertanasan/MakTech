// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Finance;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Finance
{
    [ServiceContract]
    public interface IEstateRentService : ICRUDLServiceContract<Overtech.DataModels.Finance.EstateRent>
    {
        /*Section="Method-CreateEstateLandlord"*/
        [OperationContract]
        void CreateEstateLandlord(EstateLandlord estateLandlord);

        /*Section="Method-ReadEstateLandlord"*/
        [OperationContract]
        EstateLandlord ReadEstateLandlord(long estateRent, long landlord);

        /*Section="Method-UpdateEstateLandlord"*/
        [OperationContract]
        void UpdateEstateLandlord(EstateLandlord estateLandlord);

        /*Section="Method-DeleteEstateLandlord"*/
        [OperationContract]
        void DeleteEstateLandlord(long estateRent, long landlord);

        /*Section="Method-ListEstateLandlords"*/
        [OperationContract]
        IEnumerable<EstateLandlord> ListEstateLandlords(long estateRentId);


        /*Section="Method-ListEstateRentPeriods"*/
        [OperationContract]
        IEnumerable<EstateRentPeriod> ListEstateRentPeriods(long estateRentId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

