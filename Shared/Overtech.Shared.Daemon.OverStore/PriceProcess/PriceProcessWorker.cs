using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Overtech.Core.Logger;
using Overtech.Core.Threading;
using Overtech.DataModels.Price;
using Overtech.ServiceContracts.Price;
using Overtech.DataModels.Store;
using Overtech.ServiceContracts.Store;

namespace Overtech.Shared.Daemon.OverStore
{
    public class PriceProcessWorker : DualWorker<IEnumerable<ProductPrice>>
    {

        private readonly IProductPriceService _productPriceService;
        private readonly IStoreCashRegisterService _cashRegisterService;
        private readonly string _wincorFileServer = @"D:\backoffice\wnpos\";

        public PriceProcessWorker(
            ILoggerFactory loggerFactory,
            IDictionary<string, string> parameters, string name,
            IProductPriceService productPriceService,
            IStoreCashRegisterService cashRegisterService) : base(loggerFactory, parameters, name)
        {
            _productPriceService = productPriceService;
            _cashRegisterService = cashRegisterService;
        }

        private string inDoubleQuotos(string s)
        {
            return "\"" + s + "\",";
        }

        private void createWincorPriceFile(string filePath, IEnumerable<ProductPrice> productPrices)
        {
            IList<string> lines = new List<string>();
            string today = DateTime.Now.ToString("yyyyMMdd");
            foreach (var line in productPrices)
            {
                string line1 = inDoubleQuotos(line.ProductCodeName.ToString().PadRight(20)); // ürün stok kodu
                line1 += inDoubleQuotos(line.Plu1.PadRight(20)); // Barkodu
                line1 += "01,"; // Barkod tipi
                line1 += inDoubleQuotos(line.ProductName.PadRight(60).Substring(0, 30)); // Açıklama1
                line1 += inDoubleQuotos(line.ProductName.PadRight(60).Substring(30, 30)); // Açıklama2
                line1 += inDoubleQuotos("".PadRight(20)); // Fatura açıklaması
                line1 += inDoubleQuotos("".PadRight(13)); // Fiş açıklaması
                line1 += inDoubleQuotos("".PadRight(20)); // Raf açıklaması
                line1 += inDoubleQuotos("".PadRight(16)); // Terazi etiketi açıklaması
                                                          // tüm kasalara gönder, aktif ve departman ve reyon bilgileri - 10-18
                line1 += "00,1,\"        \",\"        \",\"        \",\"        \",\"        \",\"        \",\"        \",";

                switch (line.Unit) // 19-20 : ana birim ve ana birim kısa açıklama
                {
                    case 1:
                        line1 += inDoubleQuotos("KG".PadRight(8)) + inDoubleQuotos("KG".PadRight(4)); break; //kg
                    case 2:
                        line1 += inDoubleQuotos("AD".PadRight(8)) + inDoubleQuotos("AD".PadRight(4)); break; //adet
                }

                // 21-29 ikinci, üçüncü birim kodları ve 3 tane alış fiyatı
                line1 += "\"        \",\"    \",0.000,\"        \",\"    \",0.000,      0.00,      0.00,      0.00,";

                line1 += Math.Round(line.PriceAmount * 100).ToString().PadLeft(10) + ","; // 1.satış fiyatı

                // 31-35 ikinci-üçüncü satış fiyatı döviz alış satış fiyatı ve döviz kodu 0 tl
                line1 += "       0.00,      0.00,0.000,      0.00, 0,";

                // 21-26 ikinci, üçüncü birim kodları
                // line1 += "\"        \",\"    \",0.000,\"        \",\"    \",0.000,";

                // 27 birinci alış fiyatı
                // line1 += Math.Round(line.PriceAmount * 100).ToString().PadLeft(10) + ","; // 1.satış fiyatı

                // 28-35 ikinci-üçüncü satış fiyatı, 3 alış fiyatı döviz alış satış fiyatı ve döviz kodu 0 tl
                // line1 += "      0.00,      0.00,      0.00,       0.00,      0.00,0.000,      0.00, 0,";

                line1 += line.SaleVATRate.ToString("n2").PadLeft(5).Replace(",", ".") + ","; // kdv oranı

                // 37-45
                line1 += $"\"111111\",\"          \",  0, 0.000, 0.000, 0.000, 0.000, 0.000, 0.000,";

                // 46 weighed at pos
                if (line.Unit == 1) line1 += "1,"; else line1 += "0,";

                // 47-52
                line1 += "\"                    \",01,\"                    \",01,0,0,";

                // 53 fiyat değişiklik uygunlanma tarihi bugün atılıyor. 16.01.2019
                line1 += inDoubleQuotos(today);
                
                // 54-69
                line1 += "0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.0,0,0,0,0,0,1000,";
                // 70-72
                line1 += "\"        \",\"        \",\"        \",";
                line1 += line.StoreId.ToString() + ",,";

                lines.Add(line1);
            }

            File.WriteAllText(filePath, String.Join("\r\n", lines), Encoding.GetEncoding(1252));

        }

        private void wincorPriceStatusUpdate()
        {
            try
            {
                foreach (string folder in Directory.EnumerateDirectories(_wincorFileServer))
                {

                    foreach (string file in Directory.EnumerateFiles(folder, "mesaj*.*"))
                    {

                        try
                        {
                            string[] lines = File.ReadAllLines(file);
                            string line = lines[0];

                            long crId = int.Parse(file.Substring(file.IndexOf("mesaj") + 6, 3));

                            DateTime modification = File.GetLastWriteTime(file);
                            StoreCashRegister cr = _cashRegisterService.Read(crId);


                            // dosyanın tarihi değişti ise güncelle
                            string[] statusarray = null;
                            if (cr.StatusText != null)
                                statusarray = cr.StatusText.Split('|');

                            bool updateRow = false;
                            if (cr.StatusText == null  || statusarray[0] != modification.ToString("dd.MM.yyyy HH:mm"))
                            {

                                foreach (string filegroup in line.Split('|'))
                                {

                                    string[] res = filegroup.Split(',');

                                    if (res != null && res.Length > 2 && res[1] == "7")
                                    {
                                        cr.Status = (res[0] == "3");
                                        updateRow = true;
                                    }

                                }

                                cr.StatusText = $"{modification.ToString("dd.MM.yyyy HH:mm")}|{line}";

                                if (updateRow) _cashRegisterService.Update(cr);

                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error($"wincorPriceStatusUpdate {file} error {DateTime.Now.ToString("dd.MM.yyyy HH:mm")} error : {ex.Message}");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"wincorPriceStatusUpdate error {DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} error : {ex.Message}");
            }
        }

        public override void ProcessItem(IEnumerable<ProductPrice> item)
        {
            try
            {
                if (item.Count() > 0)
                {
                    // price file path bilgisini oku.
                    string path = item.First<ProductPrice>().PriceFilePath;
                    // Dosyayı oluştur. 
                    createWincorPriceFile(path, item);
                    
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Unable to process wincor prices.", ex);
            }
        }

        public override bool TryFetchItem(out IEnumerable<ProductPrice> item)
        {
            try
            {
                wincorPriceStatusUpdate();

                _logger.Debug($"Trying to fetch wincor prices");
                item = _productPriceService.getNewPrices(1, -1, 1);
                _logger.Debug($"Fetch complete.");
                return item.Any();
            }
            catch (Exception ex)
            {
                _logger.Error("Trying to fetch wincor prices", ex);
                // Wait a little to prevent high CPU situations
                _cancelSpinEvent.WaitOne(10000);
                item = null;
                return false;
            }
        }
    }
}
