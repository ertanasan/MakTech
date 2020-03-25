// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Finance;
using Overtech.ServiceContracts.Finance;
using System.Text;
using Overtech.Shared.Content;
using System.Globalization;
using Overtech.Core.Application;
using Overtech.Mutual.Parameter;

/*Section="ClassHeader"*/
namespace Overtech.Services.Finance
{
    [OTInspectorBehavior]
    public class EstateLandlordService : CRUDRDataService<Overtech.DataModels.Finance.EstateLandlord>, IEstateLandlordService
    {
        private readonly IEstateRentPeriodService _estateRentPeriodService;
        IParameterReader _parameterReader;

        /*Section="Constructor-1"*/
        public EstateLandlordService(IEstateRentPeriodService estateRentPeriodService, IParameterReader parameterReader)
        {
            _estateRentPeriodService = estateRentPeriodService;
            _parameterReader = parameterReader;
        }

        /*Section="Constructor-2"*/
        internal EstateLandlordService(IDAL dal)
            : base(dal)
        {
        }



        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public void SendNegotiationReminderNotification(long estateRentPeriodId)
        {
            var estateRentPeriod = _estateRentPeriodService.Read(estateRentPeriodId);
            var templateName = "";
            var userCulture = new CultureInfo("tr-TR");
            StringBuilder mailContent = new StringBuilder("Kill them all!");

            //StringBuilder mailContent = new StringBuilder(readContentText(templateName));
            //mailContent
            //    .Replace("#PeriodEndDate", estateRentPeriod.PeriodEndDate.ToString("d MMMM yyyy dddd", userCulture))
            //    .Replace("#PeriodEndDate", estateRentPeriod.PeriodEndDate.ToString("d MMMM yyyy dddd", userCulture));

            ISessionContext context = OTApplication.Context;
            var notification = new Overtech.API.BPM.Notification(context.User.Id)
            {
                FromRecipient = _parameterReader.ReadSystemParameter("NotificationMailSender", "efaturatest@overtech.com.tr"),
                Subject = "Negotiation Reminder",
                Body = generateMessageWithoutHeaderAndFooter(mailContent.ToString()),
                TemplateName = "Multitravel"
            };

            notification.AddTarget(new Overtech.Shared.BPM.NotificationTarget
            {
                RecipientType = Overtech.Core.BPM.RecipientType.To,
                TargetScope = Overtech.Core.BPM.TargetScope.SingleUser,
                CustomRecipient = "mustafacem.ertem@overtech.com.tr"// 4 // read group by name
            });

            notification.SendNotification();

        }

        private string readContentText(string templateName)
        {
            return ProgramContentManager.ReadContentText("Notification Templates", templateName);
        }

        protected string generateMessageWithoutHeaderAndFooter(string message)
        {

            return $@"<!DOCTYPE html>             
            <html>
                <head>
                    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
                    <style>
                        body 
                        {{
                            margin: 0 auto !important;
                            padding: 20px !important;
                            height: 100% !important;
                            width: 100% !important;
                            color:#18163C!important;
                            font-size:14px!important;
                            font-weight:400;
                            text-decoration: none!important;
                            font-family:Tahoma, Geneva, sans-serif;
                            mso-line-height-rule: exactly;
                        }}
 
                        * {{
                            -ms-text-size-adjust: 100%;
                        }}
 
                        table,
                        td {{
                            mso-table-lspace: 0pt !important;
                            mso-table-rspace: 0pt !important;
                        }}
 
                        img {{
                            -ms-interpolation-mode:bicubic;
                        }}
 
                        a {{
                            text-decoration: none;
                        }}
                    </style>
                </head>
                <body>
                   {message}
                </body>
            </html>";
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}