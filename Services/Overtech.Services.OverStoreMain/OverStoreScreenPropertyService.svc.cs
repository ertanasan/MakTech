// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.OverStoreMain;
using Overtech.ServiceContracts.OverStoreMain;

/*Section="ClassHeader"*/
namespace Overtech.Services.OverStoreMain
{
    [OTInspectorBehavior]
    public class OverStoreScreenPropertyService : CRUDLDataService<Overtech.DataModels.OverStoreMain.OverStoreScreenProperty>, IOverStoreScreenPropertyService
    {
        /*Section="Constructor-1"*/
        public OverStoreScreenPropertyService()
        {
        }

        /*Section="Constructor-2"*/
        internal OverStoreScreenPropertyService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<OverStoreScreenProperty> ListScreenProperties (int screenId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmScreenId = dal.CreateParameter("ScreenId", screenId);
                return dal.List<OverStoreScreenProperty>("OSM_LST_SCREENPROPERTIES_SP", prmScreenId).ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}