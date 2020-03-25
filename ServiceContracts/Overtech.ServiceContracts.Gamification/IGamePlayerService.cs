// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Gamification;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Gamification
{
    [ServiceContract]
    public interface IGamePlayerService : ICRUDLServiceContract<Overtech.DataModels.Gamification.GamePlayer>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        GamePlayer readPlayerId(int userId, int organization, string userName);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

