// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Accounting;
using Overtech.ViewModels.Accounting;
using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Accounting
{
    [RoutePrefix("api/Accounting/EInvoiceClient")]
    public class EInvoiceClientController : CRUDLApiController<Overtech.DataModels.Accounting.EInvoiceClient, IEInvoiceClientService, Overtech.ViewModels.Accounting.EInvoiceClient>
    {
        
        IIdentityInfoService _identityInfoService;

        /*Section="Constructor"*/
        public EInvoiceClientController(
            ILoggerFactory loggerFactory,
            IEInvoiceClientService eInvoiceClientService,
            IIdentityInfoService identityInfoService)
            : base(loggerFactory, eInvoiceClientService)
        {
            _identityInfoService = identityInfoService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [Route("readEInvoice")]
        [OTControllerAction("Read")]
        public EInvoiceClient readEInvoice(long IdNo)
        {
            try
            {
                return _dataService.readEInvoice(IdNo).Map<Overtech.DataModels.Accounting.EInvoiceClient, EInvoiceClient>();
            }
            catch (Exception ex)
            {
                _logger.Debug($"readEInvoice Exception : {ex.ToString()}");
                throw ex;
            }
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

        [HttpGet]
        [Route("readEInvoiceGIB")]
        [OTControllerAction("Read")]
        public EInvoiceClient readEInvoiceGIBAsync(long IdNo)
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
                    eRow = base.Create(eRow);
                }
                return eRow;
            }
            catch
            {
                return eRow;
            }

        }

        [HttpGet]
        [Route("IdentityInfo")]
        [OTControllerAction("Read")]
        public IdentityInfo IdentityInfo(string IdentityNo)
        {
            try
            {
                IdentityInfo result = _dataService.ReadIdentityNo(IdentityNo).Map<DataModels.Accounting.IdentityInfo, IdentityInfo>();

                if (result.IdentityInfoId == 0)
                {
                    kdsservice.DisKullaniciKimlik k = new kdsservice.DisKullaniciKimlik();
                    k.ProgramAdi = kdsservice.ProgramAdi.NBS;
                    k.KimlikNO = "36442682498";
                    k.KimlikNOTipi = kdsservice.KimlikNOTipi.TCKN;
                    k.DisKullaniciTipi = kdsservice.DisKullaniciTipi.MaliMusavir;
                    k.Sifre = "28594222";

                    kdsservice.Service s = new kdsservice.Service();
                    long npsno = s.DisKullaniciKimlikDogrula(k, kdsservice.NPSIslemTipi.BelgeOnayi, DateTime.Now);

                    gibservice.BilgiServisHeader h = new gibservice.BilgiServisHeader();
                    h.NPSBelgeNO = npsno;
                    h.IslemTipi = gibservice.NPSIslemTipi.BelgeOnayi;
                    h.Program = gibservice.ProgramAdi.NBS;


                    gibservice.GIBBilgiServisi service = new gibservice.GIBBilgiServisi();
                    service.BilgiServisHeaderValue = h;
                    gibservice.MerkezBilgiSorguSonuc sonuc;
                    bool individual = (IdentityNo.Length == 11);
                    if (IdentityNo.Length == 11)
                    {
                        sonuc = service.GercekSahisMukellefMerkezBilgiSorgu(long.Parse(IdentityNo));
                    }
                    else
                    {
                        sonuc = service.TuzelSahisMukellefMerkezBilgiSorgu(IdentityNo);
                    }

                    IdentityInfo resultNew = new IdentityInfo();
                    resultNew.Organization = 1;
                    resultNew.IdentityNo = IdentityNo;
                    resultNew.IdentityName = individual ? sonuc.Soyadi + " " + sonuc.Adi : sonuc.Unvan;
                    resultNew.ActiveStatus = (sonuc.FaalTerkBilgisi == gibservice.GIBFaalKodlari.Faal) ? "Faal" : "Faal Değil";
                    resultNew.Address = $"CaddeSokak : {sonuc.IsAdresi.CaddeSokak}, DaireNO : {sonuc.IsAdresi.DaireNO}, IlAdi : {sonuc.IsAdresi.IlAdi}, " +
                        $"IlceAdi : {sonuc.IsAdresi.IlceAdi}, IlKodu : {sonuc.IsAdresi.IlKodu}, KapiNO : {sonuc.IsAdresi.KapiNO}, " +
                        $"MahalleSemt : {sonuc.IsAdresi.MahalleSemt}";
                    resultNew.CompanyType = sonuc.SirketTuru.ToString();
                    resultNew.FatherName = sonuc.BabaAdi;
                    resultNew.IdentityType = sonuc.SorguKimlikNOTipi.ToString();
                    resultNew.TaxCenterCode = sonuc.VergiDairesiKodu;
                    resultNew.TaxCenterName = sonuc.VergiDairesiAdi;
                    if (sonuc.MeslekListesi.Length > 0)
                    {
                        resultNew.ProfessionCode = sonuc.MeslekListesi[0].MeslekKodu;
                        resultNew.Profession = sonuc.MeslekListesi[0].MeslekAdi;
                    }
                    resultNew = _identityInfoService.Create(resultNew.Map<DataModels.Accounting.IdentityInfo, IdentityInfo>()).Map<DataModels.Accounting.IdentityInfo, IdentityInfo>();
                    return resultNew;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug($"IdentityInfo Exception : {ex.ToString()}");
                return new IdentityInfo();
            }
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}