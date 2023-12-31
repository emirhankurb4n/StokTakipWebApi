﻿using System;
using System.Collections.Generic;

namespace StokTakipWebApi.Models;

public partial class TblMusteriler
{
    public int MusteriId { get; set; }

    public string? YetkiliAdSoyad { get; set; }

    public string FirmaAdi { get; set; } = null!;

    public string? MusteriMaili { get; set; }

    public string? MusteriGsm { get; set; }

    public string? Adres { get; set; }

    public virtual ICollection<TblStokCiki> TblStokCikis { get; set; } = new List<TblStokCiki>();
}
