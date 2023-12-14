using System;
using System.Collections.Generic;

namespace StokTakipWebApi.Models;

public partial class TblTedarikciler
{
    public int TedarikciId { get; set; }

    public string FirmaAdi { get; set; } = null!;

    public string? YetkiliAdSoyad { get; set; }

    public string? TedarikciGsm { get; set; }

    public string? TedarikciMail { get; set; }

    public string? Adres { get; set; }

    public virtual ICollection<TblStokGiris> TblStokGirises { get; set; } = new List<TblStokGiris>();
}
