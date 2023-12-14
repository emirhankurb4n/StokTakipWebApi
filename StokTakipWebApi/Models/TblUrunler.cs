using System;
using System.Collections.Generic;

namespace StokTakipWebApi.Models;

public partial class TblUrunler
{
    public int UrunId { get; set; }

    public string UrunAdi { get; set; } = null!;

    public string UrunKodu { get; set; } = null!;

    public int UrunFiyati { get; set; }

    public int? MaxStok { get; set; }

    public int? MinStok { get; set; }

    public string? UrunAciklama { get; set; }

    public int KategoriId { get; set; }

    public virtual TblKategoriler Kategori { get; set; } = null!;

    public virtual ICollection<TblStokCiki> TblStokCikis { get; set; } = new List<TblStokCiki>();

    public virtual ICollection<TblStokGiris> TblStokGirises { get; set; } = new List<TblStokGiris>();
}
