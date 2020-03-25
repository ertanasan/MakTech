// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Warehouse;
using Overtech.ServiceContracts.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class MaterialService : CRUDLDataService<Overtech.DataModels.Warehouse.Material>, IMaterialService
    {
        /*Section="Constructor-1"*/
        public MaterialService()
        {
        }

        /*Section="Constructor-2"*/
        internal MaterialService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-ListMaterialInfoes"*/
        public IEnumerable<MaterialInfo> ListMaterialInfoes(long materialId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmMaterial = dal.CreateParameter("Material", materialId);
                return dal.List<MaterialInfo>("WHS_LST_MATERIALINFO_SP", prmMaterial).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}