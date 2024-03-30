using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SELENAVM04.Models.XMLS.UrunXmlElemet_XA;

namespace SELENAVM04.Models.XMLS
{
    public class UrunXmlElemet_XA
    {
        [XmlRoot("products")]
        public class Products
        {
            [XmlElement("product")]
            public List<Product> ProductList { get; set; }
        }

        public class Product
        {
            [XmlElement("code", IsNullable = false)]
            [StringLength(50)]
            public string UrunKodu { get; set; }

            [XmlElement("barcode", IsNullable = false)]
            [StringLength(50)]
            public string UrunBarkodu { get; set; }

            [XmlElement("subproduct_code", IsNullable = false)]
            [StringLength(50)]
            public string VaryantKodu { get; set; }

            [XmlElement("name", IsNullable = true)]
            [StringLength(255)]
            public string UrunAdi { get; set; }

            [XmlElement("brand", IsNullable = true)]
            [StringLength(50)]
            public string UrunMarka { get; set; }

            [XmlElement("subproduct_type1", IsNullable = true)]
            [StringLength(25)]
            public string UrunRengi { get; set; }

            [XmlElement("subproduct_type2", IsNullable = true)]
            [StringLength(25)]
            public string UrunModeli { get; set; }

            [XmlElement("stock", IsNullable = true)]
            public int? UrunAdeti { get; set; }

            [XmlElement("price_list", IsNullable = true)]
            public decimal? UrunFiyati { get; set; }
        }
    }

    public class UrunXmlElemet_BI
    {
        [XmlElement("urun_kodu", IsNullable = false)]
        [StringLength(50)]
        public string UrunKodu { get; set; }

        [XmlElement("minumum_siparis_barkodu", IsNullable = false)]
        [StringLength(50)]
        public string UrunBarkodu { get; set; }

        [XmlElement("varyant_kodu", IsNullable = false)]
        [StringLength(50)]
        public string VaryantKodu { get; set; }

        [XmlElement("urun_adi", IsNullable = true)]
        [StringLength(255)]
        public string UrunAdi { get; set; }

        [XmlElement("marka", IsNullable = true)]
        [StringLength(50)]
        public string UrunMarka { get; set; }

        [XmlElement("urun_rengi", IsNullable = true)]
        [StringLength(25)]
        public string UrunRengi { get; set; }

        [XmlElement("urun_modeli", IsNullable = true)]
        [StringLength(25)]
        public string UrunModeli { get; set; }

        [XmlElement("mevcut_stok", IsNullable = true)]
        public int? UrunAdeti { get; set; }

        [XmlElement("kdvli_brutfiyati", IsNullable = true)]
        public decimal? UrunFiyati { get; set; }
    }

    [XmlRoot("Urunler")]
    public class Urunler
    {
        [XmlElement("Urun")]
        public List<UrunXmlElemet_BI> ProductList { get; set; }
    }
}

