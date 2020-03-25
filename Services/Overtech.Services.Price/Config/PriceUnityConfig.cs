using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Overtech.Mutual.Store;
using Overtech.Service.Data.Uni;
using Overtech.Shared.Configuration;
using Unity;

namespace Overtech.Services.Price
{
    public class PriceUnityConfig : BasicUnityConfig
    {
        public PriceUnityConfig()
            : base()
        {
        }

        protected override void RegisterDependencies()
        {
            Container.RegisterType<StoreOperations, StoreOperations>();
        }
    }
}