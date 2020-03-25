using Overtech.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Overtech.Gateways.OverStore
{
    public class OverStoreGatewayCacheConfig : GatewayCacheConfig
    {
        public OverStoreGatewayCacheConfig() : base()
        {
        }
        public override void Configure(params object[] args)
        {
            base.Configure(args);
        }
    }
}