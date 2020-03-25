using Overtech.Core.Compression;
using Overtech.Core.Daemon;
using Overtech.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Overtech.Daemons.OverStore.Store
{
    class StoreUnityConfig : OTUnityConfig
    {
        protected override void RegisterDependencies()
        {
            base.RegisterDependencies();

            Container.RegisterType<IDaemonRuntime, DaemonRuntime>()
                     .RegisterInstance<IDaemonConfig>(DaemonConfig.Current)
                     .RegisterType<IDeflateCompressor, DeflateCompressor>();
        }
    }
}
