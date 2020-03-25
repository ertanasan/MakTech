using Overtech.Core.Compression;
using Overtech.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;

namespace Overtech.Gateways.OverStore
{
    internal class OverStoreGatewayUnityConfig : GatewayUnityConfig
    {
        public override void Configure(params object[] args)
        {
            base.Configure(args);

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(Container);
        }

        protected override void RegisterDependencies()
        {
            base.RegisterDependencies();
            base.RegisterAuthenticationDependencies();

            Container.RegisterType<IDeflateCompressor, DeflateCompressor>();
        }

    }
}