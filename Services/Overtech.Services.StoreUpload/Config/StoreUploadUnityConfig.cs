using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Overtech.Core.Compression;
using Overtech.Shared.Configuration;
using Unity;

namespace Overtech.Services.StoreUpload
{
    public class StoreUploadUnityConfig : BasicUnityConfig
    {
        protected override void RegisterDependencies()
        {
            Container.RegisterType<IDeflateCompressor, DeflateCompressor>();
        }
    }
}