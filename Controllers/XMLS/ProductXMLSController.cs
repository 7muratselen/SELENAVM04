using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SELENAVM04.Models.XMLS;
using SELENAVM04.Services.XMLS;
using SELENAVM04.Data;
using SELENAVM04.Entities;
using System.Diagnostics;



namespace SELENAVM04.Controllers.XMLS
{
    public class ProductXMLSController : Controller
    {
        private readonly XmlReaderService _xmlReaderService;
        private readonly SelenavmDbContext _dbContext;
        private readonly ILogger<ProductXMLSController> _logger;

        public ProductXMLSController(ILogger<ProductXMLSController> logger)
        {
            _xmlReaderService = new XmlReaderService();
            _dbContext = new SelenavmDbContext();
            _logger = logger;
        }

        public IActionResult Index()
        {

            Stopwatch stopwatch = new Stopwatch(); // Declare the Stopwatch object here
            try
            {
                stopwatch.Start();

                _logger.LogInformation("XML_XA dosyası okunuyor, lütfen bekleyin...");

                // XML_XA dosyasını oku
                UrunXmlElemet_XA.Products XML_XA = _xmlReaderService.ReadXml_XA(@"C:/Code/XML/XA_Ornek.xml");

                _logger.LogInformation("XML_XA dosyası başarıyla okundu. Veritabanına kaydediliyor...");

                stopwatch.Stop();
                _logger.LogInformation($"XML_XA dosyası okuma süresi: {stopwatch.Elapsed.TotalSeconds} saniye");
                stopwatch.Reset();


                // Tüm verileri sil
                var allUrunler = _dbContext.UrunlerXMLS.ToList();
                _dbContext.UrunlerXMLS.RemoveRange(allUrunler);

                stopwatch.Start();

                // XML_XA dosyasından gelen verileri işle ve veritabanına yaz
                foreach (var product in XML_XA.ProductList)
                {
                    // Veritabanı model nesnesini oluştur
                    var dbProduct = new UrunlerXMLS
                    {
                        UrunKodu = product.UrunKodu,
                        UrunBarkodu = product.UrunBarkodu,
                        VaryantKodu = product.VaryantKodu,
                        UrunAdi = product.UrunAdi,
                        UrunMarka = product.UrunMarka,
                        UrunRengi = product.UrunRengi,
                        UrunModeli = product.UrunModeli,
                        UrunAdeti = product.UrunAdeti,
                        UrunFiyati = product.UrunFiyati,
                    };

                    // Veritabanına ekle
                    _dbContext.UrunlerXMLS.Add(dbProduct);
                }

                

                // Değişiklikleri kaydet
                
                _dbContext.SaveChanges();
                
                
                _logger.LogInformation("XML_XA dosyasındaki veriler başarıyla veritabanına kaydedildi.");

                stopwatch.Stop();
                _logger.LogInformation($"XML_XA dosyası okuma süresi: {stopwatch.Elapsed.TotalSeconds} saniye");
                stopwatch.Reset();


                stopwatch.Start();
                _logger.LogInformation("XML_BI dosyası okunuyor, lütfen bekleyin...");

                // XML_BI dosyasını oku
                Urunler XML_BI = _xmlReaderService.ReadXml_BI(@"C:/Code/XML/BI_Ornek.xml");

                _logger.LogInformation("XML_BI dosyası başarıyla okundu. Veritabanına kaydediliyor...");

                // Tüm verileri sil
                allUrunler = _dbContext.UrunlerXMLS.ToList();
                _dbContext.UrunlerXMLS.RemoveRange(allUrunler);

                // XML_BI dosyasından gelen verileri işle ve veritabanına yaz
                foreach (var product in XML_BI.ProductList)
                {
                    // Veritabanı model nesnesini oluştur
                    var dbProduct = new UrunlerXMLS
                    {
                        UrunKodu = product.UrunKodu,
                        UrunBarkodu = product.UrunBarkodu,
                        VaryantKodu = product.VaryantKodu,
                        UrunAdi = product.UrunAdi,
                        UrunMarka = product.UrunMarka,
                        UrunRengi = product.UrunRengi,
                        UrunModeli = product.UrunModeli,
                        UrunAdeti = product.UrunAdeti,
                        UrunFiyati = product.UrunFiyati,
                    };

                    // Veritabanına ekle
                    _dbContext.UrunlerXMLS.Add(dbProduct);
                }

                // Değişiklikleri kaydet
                _dbContext.SaveChanges();

                _logger.LogInformation("XML_BI dosyasındaki veriler başarıyla veritabanına kaydedildi.");

                stopwatch.Stop();
                _logger.LogInformation($"XML_BI dosyası okuma süresi: {stopwatch.Elapsed.TotalSeconds} saniye");
                stopwatch.Reset();
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda çalışacak kod
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return View();
        }

    }
}
// Evet, kodunuz doğru görünüyor.ProductXMLSController sınıfınızın Index metodu, iki XML dosyasını okuyor(XML_XA ve XML_BI),
// her bir dosyadan gelen ürünleri UrunlerXMLS nesnelerine dönüştürüyor ve bu nesneleri veritabanına ekliyor.
//Her bir XML dosyasını okuduktan sonra, UrunlerXMLS tablosundaki tüm verileri silip yeni okunan XML bilgilerini ekliyorsunuz.
//Bu, her XML dosyasını okuduktan sonra veritabanındaki tüm verileri silmek ve yeni okunan XML bilgilerini eklemek istediğiniz anlamına geliyor.
//Her bir foreach döngüsünde, ProductList içindeki her bir product için yeni bir UrunlerXMLS nesnesi oluşturuyorsunuz ve bu nesneyi veritabanına ekliyorsunuz.
//Bu nesnenin özelliklerini, product nesnesinin özelliklerinden alıyorsunuz.
//Son olarak, her bir XML dosyasını işledikten sonra, SaveChanges metodu ile veritabanındaki değişiklikleri kaydediyorsunuz.
//Kodunuzun doğru çalışıp çalışmadığını kontrol etmek için, uygulamanızı çalıştırabilir ve ProductXMLSController'ın Index metodunu çağırabilirsiniz.
//Bu, XML dosyalarını okuyacak, UrunlerXMLS nesnelerine dönüştürecek ve bu nesneleri veritabanına ekleyecektir. Eğer herhangi bir hata alırsanız, lütfen bana bildirin!
