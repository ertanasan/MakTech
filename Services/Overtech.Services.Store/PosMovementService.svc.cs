// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Store;
using Overtech.ServiceContracts.Store;

/*Section="ClassHeader"*/
namespace Overtech.Services.Store
{
    [OTInspectorBehavior]
    public class PosMovementService : CRUDLDataService<Overtech.DataModels.Store.PosMovement>, IPosMovementService
    {
        /*Section="Constructor-1"*/
        public PosMovementService()
        {
        }

        /*Section="Constructor-2"*/
        internal PosMovementService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public void PosMoveInitial()
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    dal.ExecuteNonQuery("STR_INS_POSMOVEINITIAL_SP");
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                }
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}