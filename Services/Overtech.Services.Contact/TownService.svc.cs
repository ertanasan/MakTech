// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Contact;
using Overtech.ServiceContracts.Contact;

/*Section="ClassHeader"*/
namespace Overtech.Services.Contact
{
    [OTInspectorBehavior]
    public class TownService : CRUDLDataService<Overtech.DataModels.Contact.Town>, ITownService
    {
        /*Section="Constructor-1"*/
        public TownService()
        {
        }

        /*Section="Constructor-2"*/
        internal TownService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Contact.Town Find(string townName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmTownName = dal.CreateParameter("TownName", townName);
                return dal.Read<Overtech.DataModels.Contact.Town>("CNT_SEL_FINDTOWN_SP", prmTownName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}