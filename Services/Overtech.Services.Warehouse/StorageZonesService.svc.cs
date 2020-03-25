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
    public class StorageZonesService : CRUDLDataService<Overtech.DataModels.Warehouse.StorageZones>, IStorageZonesService
    {
        /*Section="Constructor-1"*/
        public StorageZonesService()
        {
        }

        /*Section="Constructor-2"*/
        internal StorageZonesService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<StorageZones> ZoneList(int store)
        {
            IEnumerable<StorageZones> _zoneList = null;
            using (IDAL dal = this.DAL)
            {
                try
                {
                    IUniParameter prmStore = dal.CreateParameter("Store", store);
                    _zoneList = dal.List<StorageZones>("WHS_LST_ZONE_SP", prmStore).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _zoneList;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}