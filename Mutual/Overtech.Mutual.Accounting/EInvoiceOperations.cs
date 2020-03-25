using Overtech.DataModels.Accounting;
using Overtech.Service.Data.Uni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.Mutual.Accounting
{
    public class EInvoiceOperations
    {
        private IDAL _dal;

        public EInvoiceOperations(IDAL dal)
        {
            _dal = dal;
        }

        private static readonly HttpClient client = new HttpClient();

        private async Task<string> makeCall(long IdNo)
        {
            var values = new Dictionary<string, string>
            {
            { "search_string", IdNo.ToString() }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://sorgu.efatura.gov.tr/kullanicilar/xliste.php", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        private EInvoiceClient readEInvoiceGIBAsync(long IdNo)
        {

            EInvoiceClient eRow = new EInvoiceClient();
            try
            {
                Task<string> task = Task.Run<string>(async () => await makeCall(IdNo));
                string responseString = task.Result;
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(responseString);

                List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table[@class='kurumlar']")
                            .Descendants("tr")
                            .Skip(1)
                            .Where(tr => tr.Elements("td").Count() > 1)
                            .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                            .ToList();


                if (table[0][0] == IdNo.ToString())
                {
                    eRow.Identifier = IdNo;
                    eRow.Alias = "";
                    eRow.Email = "";
                    eRow.Title = table[0][2];
                    eRow.Type = table[0][1];
                    _dal.Create<EInvoiceClient>(eRow);
                }
                return eRow;
            }
            catch
            {
                return eRow;
            }

        }

        public EInvoiceClient CheckIfEInvoiceCustomer (long customerId)
        {
            // kimlik numarasının e-fatura mükellefi olup olmadığını kontrol et.
            IUniParameter prmIdNo = _dal.CreateParameter("IdNo", customerId);
            EInvoiceClient e = _dal.Read<EInvoiceClient>("ACC_SEL_EINVOICECLIENTFROMID_SP", prmIdNo);
            if (e == null)
            { 
                e = readEInvoiceGIBAsync(customerId);
            }
            else
            {
                e = new EInvoiceClient();
                e.EInvoiceClientId = 0;
            }
            return e;
        }
    }
}
