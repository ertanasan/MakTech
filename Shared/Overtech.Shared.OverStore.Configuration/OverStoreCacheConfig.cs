using Overtech.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.Shared.OverStore.Configuration
{
    public class OverStoreCacheConfig : MvcCacheConfig
    {
        public OverStoreCacheConfig() :base ()
        {
        }
        public override void Configure(params object[] args)
        {
            base.Configure(args);
        }
    }
}
