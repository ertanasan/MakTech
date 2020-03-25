// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Finance;
using Overtech.ServiceContracts.Finance;

/*Section="ClassHeader"*/
namespace Overtech.Services.Finance
{
    [OTInspectorBehavior]
    public class ContractParameterService : CRUDLDataService<Overtech.DataModels.Finance.ContractParameter>, IContractParameterService
    {
        /*Section="Constructor-1"*/
        public ContractParameterService()
        {
        }

        /*Section="Constructor-2"*/
        internal ContractParameterService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Finance.ContractParameter Find(string parameterName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmParameterName = dal.CreateParameter("ParameterName", parameterName);
                return dal.Read<Overtech.DataModels.Finance.ContractParameter>("FIN_SEL_FINDCONTRACTPARAMETER_SP", prmParameterName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}