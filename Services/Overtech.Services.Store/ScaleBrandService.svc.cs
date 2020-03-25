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
    public class ScaleBrandService : CRUDLDataService<Overtech.DataModels.Store.ScaleBrand>, IScaleBrandService
    {
        /*Section="Constructor-1"*/
        public ScaleBrandService()
        {
        }

        /*Section="Constructor-2"*/
        internal ScaleBrandService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Store.ScaleBrand Find(string name)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmName = dal.CreateParameter("Name", name);
                return dal.Read<Overtech.DataModels.Store.ScaleBrand>("STR_SEL_FINDSCALEBRAND_SP", prmName);
            }
        }

        /*Section="Method-ListScaleModels"*/
        public IEnumerable<ScaleModel> ListScaleModels(long scaleBrandId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmBrand = dal.CreateParameter("Brand", scaleBrandId);
                return dal.List<ScaleModel>("STR_LST_SCALEMODEL_SP", prmBrand).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}