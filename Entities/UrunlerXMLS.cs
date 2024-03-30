namespace SELENAVM04.Entities
{
    public class UrunlerXMLS
{
    public int Id { get; set; }
    public string UrunKodu { get; set; } = string.Empty; 
    public string UrunBarkodu { get; set; } = string.Empty; 
    public string VaryantKodu { get; set; } = string.Empty; 
    public string? UrunAdi { get; set; } // nullable string
    public string? UrunMarka { get; set; } // nullable string
    public string? UrunRengi { get; set; } // nullable string
    public string? UrunModeli { get; set; } // nullable string
    public int? UrunAdeti { get; set; } // already nullable
    public decimal? UrunFiyati { get; set; } // already nullable
}
}
