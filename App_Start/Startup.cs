using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Overtech.ApiControllers.Authentication;
using Overtech.Service.Authorization;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(Overtech.Gateways.OverStore.Startup))]
namespace Overtech.Gateways.OverStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.Use((context, next) =>
            {
                WebApiHandlers.OnAuthenticateRequest(context);
                WebApiHandlers.SetLanguage(context);
                return next.Invoke();
            });
            app.UseStageMarker(PipelineStage.Authenticate);

            app.UsePrivilegeAuthorization(new OTPrivilegeAuthorization());
        }

        private bool IsApiRequest(IOwinRequest request)
        {
            return request.Uri.AbsolutePath.StartsWith("/api");
        }
    }
}
