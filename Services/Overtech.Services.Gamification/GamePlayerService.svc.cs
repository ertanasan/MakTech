// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Gamification;
using Overtech.ServiceContracts.Gamification;

/*Section="ClassHeader"*/
namespace Overtech.Services.Gamification
{
    [OTInspectorBehavior]
    public class GamePlayerService : CRUDLDataService<Overtech.DataModels.Gamification.GamePlayer>, IGamePlayerService
    {
        /*Section="Constructor-1"*/
        public GamePlayerService()
        {
        }

        /*Section="Constructor-2"*/
        internal GamePlayerService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public GamePlayer readPlayerId(int userId, int organization, string userName)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prm_UserId = dal.CreateParameter("UserId", userId);
                    IUniParameter prm_Organization = dal.CreateParameter("Organization", organization);
                    IUniParameter prm_UserName = dal.CreateParameter("UserName", userName);
                    GamePlayer gp = dal.Read<GamePlayer>("GAM_SEL_PLAYERID_SP", prm_UserId, prm_Organization, prm_UserName);
                    dal.CommitTransaction();
                    return gp;
                }
                catch(Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}