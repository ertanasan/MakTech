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
    public interface ILandlordService : ICRUDLServiceContract<Overtech.DataModels.Finance.Landlord>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Finance.Landlord Find(string landlordName);
        /*Section="Method-CreateEstateLandlord"*/
        [OperationContract]
        void CreateEstateLandlord(EstateLandlord estateLandlord);

        /*Section="Method-ReadEstateLandlord"*/
        [OperationContract]
        EstateLandlord ReadEstateLandlord(long landlord, long estateRent);

        /*Section="Method-UpdateEstateLandlord"*/
        [OperationContract]
        void UpdateEstateLandlord(EstateLandlord estateLandlord);

        /*Section="Method-DeleteEstateLandlord"*/
        [OperationContract]
        void DeleteEstateLandlord(long landlord, long estateRent);

        /*Section="Method-ListEstateLandlords"*/
        [OperationContract]
        IEnumerable<EstateLandlord> ListEstateLandlords(long landlordId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        IEnumerable<DataModels.Finance.LandlordMikro> ListAllLandlordsFromMikro();
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

