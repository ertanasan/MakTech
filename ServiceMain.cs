using Overtech.Core;
using Overtech.Core.Application;
using Overtech.Core.Daemon;
using Overtech.Core.DependencyInjection;
using Overtech.Core.Logger;
using Overtech.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Overtech.Daemons.OverStore.Store
{
    public partial class ServiceMain : ServiceBase
    {
        private ILogger _logger;
        private ILogger _eventLogger;
        private IOTResolver _resolver;
        private IDaemonRuntime _daemonRuntime;

        public ServiceMain()
        {
            InitializeComponent();
            this.ServiceName = "{0}.{1}".FormatWith(typeof(ServiceMain).Namespace, OTApplication.Environment);
        }

        public void Initialize()
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

                OTConfigurer.Configure<StoreUnityConfig>();

                _resolver = OTUnityConfig.Container.Resolve<IOTResolver>();
                _logger = _resolver.Resolve<ILoggerFactory>().GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                _eventLogger = _resolver.Resolve<ILoggerFactory>().GetLogger(MethodBase.GetCurrentMethod().DeclaringType, LoggerType.Event);

                _logger.Info(String.Format("Welcome to {0}.{1}", typeof(ServiceMain).Namespace, OTApplication.Environment));

                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            }
            catch (Exception ex)
            {
                _logger.FatalError("Service could not start.", ex);
            }
        }

        public void Start()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) =>
                {
                    _logger.Debug("Certification validation warning. Accepting non-trusted certificate.");
                    return true;
                };

                _logger.Debug("Resolving DaemonRuntime.");
                _daemonRuntime = _resolver.Resolve<IDaemonRuntime>();
                _logger.Debug("DaemonRuntime resolved.");

                _logger.Debug("Starting DaemonRuntime.");
                _daemonRuntime.Start();
                _logger.Debug("DaemonRuntime is started and running.");
            }
            catch (Exception ex)
            {
                _logger.Error("Service cannot be started.", ex);
            }
        }

        protected override void OnStop()
        {
            try
            {
                _logger.Debug("Stopping DaemonRuntime.");
                _daemonRuntime.Stop();
                _logger.Debug("DaemonRuntime stopped.");
            }
            catch (Exception ex)
            {
                _logger.Error("Service cannot be stopped.", ex);
            }
        }

        protected override void OnPause()
        {
            try
            {
                _logger.Debug("Pausing DaemonRuntime.");
                _daemonRuntime.PauseImmediately();
                _logger.Debug("DaemonRuntime paused immediately.");
            }
            catch (Exception ex)
            {
                _logger.Error("Service cannot be paused.", ex);
            }
        }

        protected override void OnContinue()
        {
            try
            {
                _logger.Debug("Resuming DaemonRuntime.");
                _daemonRuntime.Resume();
                _logger.Debug("DaemonRuntime resumed.");
            }
            catch (Exception ex)
            {
                _logger.Error("Service cannot be resumed.", ex);
            }
        }

        protected void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string exceptionMessage = "Unhandled exception occured on AppDomain.{0}{1}".FormatWith(Environment.NewLine, e.ExceptionObject.ToString());
            _logger.Error(exceptionMessage);
            _eventLogger.Error(exceptionMessage);
        }
    }
}
