// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Store;
using Overtech.ServiceContracts.Store;

/*Section="ClassHeader"*/
namespace Overtech.Services.Store
{
    [OTInspectorBehavior]
    public class StoreService : CRUDLDataService<Overtech.DataModels.Store.Store>, IStoreService
    {
        /*Section="Constructor-1"*/
        public StoreService()
        {
        }

        /*Section="Constructor-2"*/
        internal StoreService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Store.Store Find(string name)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmName = dal.CreateParameter("Name", name);
                return dal.Read<Overtech.DataModels.Store.Store>("STR_SEL_FINDSTORE_SP", prmName);
            }
        }

        /*Section="Method-ListStoreScaless"*/
        public IEnumerable<StoreScales> ListStoreScaless(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStore = dal.CreateParameter("Store", storeId);
                return dal.List<StoreScales>("STR_LST_SCALE_SP", prmStore).ToList();
            }
        }

        /*Section="Method-ListStoreCashRegisters"*/
        public IEnumerable<StoreCashRegister> ListStoreCashRegisters(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStore = dal.CreateParameter("Store", storeId);
                return dal.List<StoreCashRegister>("STR_LST_CASHREGISTER_SP", prmStore).ToList();
            }
        }

        /*Section="Method-CreateUsersStores"*/
        public void CreateUsersStores(UsersStores usersStores)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmUser = dal.CreateParameter("User", usersStores.User);
                    IUniParameter prmStore = dal.CreateParameter("Store", usersStores.Store);
                    dal.ExecuteNonQuery("STR_INS_USERSSTORES_SP", prmUser, prmStore);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-ReadUsersStores"*/
        public UsersStores ReadUsersStores(long store, long user)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStore = dal.CreateParameter("Store", store);
                IUniParameter prmUser = dal.CreateParameter("User", user);
                return dal.Read<UsersStores>("STR_SEL_USERSSTORES_SP", prmStore, prmUser);
            }
        }

        /*Section="Method-DeleteUsersStores"*/
        public void DeleteUsersStores(long store, long user)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmStore = dal.CreateParameter("Store", store);
                    IUniParameter prmUser = dal.CreateParameter("User", user);
                    dal.ExecuteNonQuery("STR_DEL_USERSSTORES_SP", prmStore, prmUser);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-ListUsersStoress"*/
        public IEnumerable<UsersStores> ListUsersStoress(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStore = dal.CreateParameter("Store", storeId);
                IUniParameter prmUser = dal.CreateParameter("User", null);
                return dal.List<UsersStores>("STR_LST_USERSSTORES_SP", prmStore, prmUser).ToList();
            }
        }

        /*Section="Method-ListStoreFixtures"*/
        public IEnumerable<StoreFixture> ListStoreFixtures(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStore = dal.CreateParameter("Store", storeId);
                return dal.List<StoreFixture>("STR_LST_FIXTURE_SP", prmStore).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<Overtech.DataModels.Store.Store> ListOverStores()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<Overtech.DataModels.Store.Store>("STR_LST_OVERSTORES_SP").ToList();
            }
        }

        public IEnumerable<Overtech.DataModels.Store.CashRegisterBrand> ListStoreCashRegisterBrands(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStore = dal.CreateParameter("StoreId", storeId);
                return dal.List<Overtech.DataModels.Store.CashRegisterBrand>("STR_LST_STORECASHREGISTERS_SP", prmStore).ToList();
            }
        }

        public IEnumerable<Overtech.DataModels.Store.ScaleBrand> ListStoreScaleBrands(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStore = dal.CreateParameter("StoreId", storeId);
                return dal.List<Overtech.DataModels.Store.ScaleBrand>("STR_LST_STORESCALES_SP", prmStore).ToList();
            }
        }

        public IEnumerable<Overtech.DataModels.Store.Store> UserStores()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<Overtech.DataModels.Store.Store>("STR_LST_USERSTORES_SP").ToList();
            }
        }

        public DataTable ListUserPrivilegesByScreen(long screenId, long programId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmScreen = dal.CreateParameter("Screen", screenId);
                IUniParameter prmProgram = dal.CreateParameter("Program", programId);
                return dal.ExecuteDataset("SEC_LST_SCREENUSERS_SP", prmScreen, prmProgram).Tables[0];
            }
        }

        public DataTable ListScreenActionsByUser(long userId, long programId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmUser = dal.CreateParameter("User", userId);
                IUniParameter prmProgram = dal.CreateParameter("Program", programId);
                return dal.ExecuteDataset("SEC_LST_USERSCREENS_SP", prmUser, prmProgram).Tables[0];
            }
        }

        public DataTable ListAllPrograms()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("PRG_LST_PROGRAM_SP").Tables[0];
            }
        }

        public DataTable GetDashboardOutdatedCodeStore()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("STR_LST_OUTDATEDCODESTORE_SP").Tables[0];
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}