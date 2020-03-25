// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Store;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Store
{
    [ServiceContract]
    public interface IStoreService : ICRUDLServiceContract<Overtech.DataModels.Store.Store>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Store.Store Find(string name);

        /*Section="Method-ListStoreScaless"*/
        [OperationContract]
        IEnumerable<StoreScales> ListStoreScaless(long storeId);


        /*Section="Method-ListStoreCashRegisters"*/
        [OperationContract]
        IEnumerable<StoreCashRegister> ListStoreCashRegisters(long storeId);

        /*Section="Method-CreateUsersStores"*/
        [OperationContract]
        void CreateUsersStores(UsersStores usersStores);

        /*Section="Method-ReadUsersStores"*/
        [OperationContract]
        UsersStores ReadUsersStores(long store, long user);

        /*Section="Method-DeleteUsersStores"*/
        [OperationContract]
        void DeleteUsersStores(long store, long user);

        /*Section="Method-ListUsersStoress"*/
        [OperationContract]
        IEnumerable<UsersStores> ListUsersStoress(long storeId);


        /*Section="Method-ListStoreFixtures"*/
        [OperationContract]
        IEnumerable<StoreFixture> ListStoreFixtures(long storeId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<Overtech.DataModels.Store.Store> ListOverStores();

        [OperationContract]
        IEnumerable<Overtech.DataModels.Store.CashRegisterBrand> ListStoreCashRegisterBrands(long storeId);

        [OperationContract]
        IEnumerable<Overtech.DataModels.Store.ScaleBrand> ListStoreScaleBrands(long storeId);

        [OperationContract]
        IEnumerable<Overtech.DataModels.Store.Store> UserStores();

        [OperationContract]
        DataTable ListUserPrivilegesByScreen(long screenId, long programId);

        [OperationContract]
        DataTable ListScreenActionsByUser(long userId, long programId);

        [OperationContract]
        DataTable ListAllPrograms();

        [OperationContract]
        DataTable GetDashboardOutdatedCodeStore();
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

