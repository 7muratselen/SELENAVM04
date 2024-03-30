using System.IO;
using System.Xml.Serialization;
using SELENAVM04.Models.XMLS;

namespace SELENAVM04.Services.XMLS
{
    public class XmlReaderService
    {
        public UrunXmlElemet_XA.Products ReadXml_XA(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UrunXmlElemet_XA.Products));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (UrunXmlElemet_XA.Products)serializer.Deserialize(reader);
            }
        }

        public Urunler ReadXml_BI(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Urunler));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (Urunler)serializer.Deserialize(reader);
            }
        }

    }
}
