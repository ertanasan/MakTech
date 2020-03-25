using Overtech.Core.Cache;
using Overtech.Core.Compression;
using Overtech.Core.Expression;
using Overtech.Core.Jwt;
using Overtech.Shared.Configuration;
using Overtech.Shared.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Overtech.Shared.OverStore.Configuration
{
    public class OverStoreUnityConfig : MvcUnityConfig
    {
        public OverStoreUnityConfig() : base()
        {
        }

        protected override void RegisterDependencies()
        {
            base.RegisterDependencies();

            Type genericCacheService = typeof(ICacheService<,>);

            Container.RegisterType<ProgramContentManager, ProgramContentManager>()
                     .RegisterType<IZipCompressor, ZipCompressor>()
                     .RegisterType<IExpressionEvaluatorFactory, ExpressionEvaluatorFactory>()
                     .RegisterType<IJwtOperations, JwtOperations>();

        }
    }
}
