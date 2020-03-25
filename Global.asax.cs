using Overtech.Core.Session;
using Overtech.Service.Authorization.WebApi;
using Overtech.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Overtech.Gateways.OverStore
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            OTConfigurer.Configure<OverStoreGatewayUnityConfig, OverStoreGatewayCacheConfig>();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.Filters.Add(new OTWebApiContextAttribute());
            GlobalConfiguration.Configuration.Filters.Add(new OTWebApiAuthorizeAttribute());
        }
    }
}
