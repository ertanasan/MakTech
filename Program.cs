using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.Daemons.OverStore.Store
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceMain serviceMain = new ServiceMain();
            serviceMain.Initialize();
#if (DEBUG)
            serviceMain.Start();
#else
            ServiceBase.Run(new ServiceBase[] { serviceMain });
#endif
        }
    }
}
