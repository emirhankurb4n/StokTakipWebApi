using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StokTakipWebApi.Models;

public partial class StokTakipDbContext : DbContext
{
    public StokTakipDbContext()
    {
    }

    public StokTakipDbContext(DbContextOptions<StokTakipDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblKategoriler> TblKategorilers { get; set; }

    public virtual DbSet<TblKullanicilar> TblKullanicilars { get; set; }

    public virtual DbSet<TblMusteriler> TblMusterilers { get; set; }

    public virtual DbSet<TblStokCiki> TblStokCikis { get; set; }

    public virtual DbSet<TblStokGiris> TblStokGirises { get; set; }

    public virtual DbSet<TblTedarikciler> TblTedarikcilers { get; set; }

    public virtual DbSet<TblUrunler> TblUrunlers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=.\\Sqlexpress;Initial Catalog=stoktakip_db;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblKategoriler>(entity =>
        {
            entity.HasKey(e => e.KategoriId);

            entity.ToTable("Tbl_Kategoriler");

            entity.Property(e => e.KategoriAdi)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblKullanicilar>(entity =>
        {
            entity.HasKey(e => e.KullaniciId).HasName("PK_TblKullanicilar");

            entity.ToTable("Tbl_Kullanicilar");

            entity.Property(e => e.KullaniciAd).HasMaxLength(50);
            entity.Property(e => e.Parola).HasMaxLength(50);
        });

        modelBuilder.Entity<TblMusteriler>(entity =>
        {
            entity.HasKey(e => e.MusteriId);

            entity.ToTable("Tbl_Musteriler");

            entity.Property(e => e.Adres)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.FirmaAdi).HasMaxLength(50);
            entity.Property(e => e.MusteriGsm)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MusteriGSM");
            entity.Property(e => e.MusteriMaili).HasMaxLength(50);
            entity.Property(e => e.YetkiliAdSoyad).HasMaxLength(50);
        });

        modelBuilder.Entity<TblStokCiki>(entity =>
        {
            entity.HasKey(e => e.IslemId).HasName("PK_TblStokCikis");

            entity.ToTable("Tbl_StokCikis");

            entity.Property(e => e.Tarih).HasColumnType("datetime");

            entity.HasOne(d => d.IslemYapanPersonel).WithMany(p => p.TblStokCikis)
                .HasForeignKey(d => d.IslemYapanPersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblStokCikis_TblKullanicilar");

            entity.HasOne(d => d.Musteri).WithMany(p => p.TblStokCikis)
                .HasForeignKey(d => d.MusteriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblStokCikis_Tbl_Musteriler");

            entity.HasOne(d => d.Urun).WithMany(p => p.TblStokCikis)
                .HasForeignKey(d => d.UrunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblStokCikis_Tbl_Urunler");
        });

        modelBuilder.Entity<TblStokGiris>(entity =>
        {
            entity.HasKey(e => e.IslemId).HasName("PK_TblStokGiris");

            entity.ToTable("Tbl_StokGiris");

            entity.Property(e => e.Tarih).HasColumnType("datetime");

            entity.HasOne(d => d.IslemYapanPersonel).WithMany(p => p.TblStokGirises)
                .HasForeignKey(d => d.IslemYapanPersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblStokGiris_TblKullanicilar");

            entity.HasOne(d => d.Tedarikci).WithMany(p => p.TblStokGirises)
                .HasForeignKey(d => d.TedarikciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblStokGiris_Tbl_Tedarikciler");

            entity.HasOne(d => d.Urun).WithMany(p => p.TblStokGirises)
                .HasForeignKey(d => d.UrunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblStokGiris_Tbl_Urunler");
        });

        modelBuilder.Entity<TblTedarikciler>(entity =>
        {
            entity.HasKey(e => e.TedarikciId);

            entity.ToTable("Tbl_Tedarikciler");

            entity.Property(e => e.Adres).HasMaxLength(100);
            entity.Property(e => e.FirmaAdi).HasMaxLength(50);
            entity.Property(e => e.TedarikciGsm)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("TedarikciGSM");
            entity.Property(e => e.TedarikciMail).HasMaxLength(50);
            entity.Property(e => e.YetkiliAdSoyad).HasMaxLength(50);
        });

        modelBuilder.Entity<TblUrunler>(entity =>
        {
            entity.HasKey(e => e.UrunId);

            entity.ToTable("Tbl_Urunler");

            entity.Property(e => e.UrunAciklama).HasMaxLength(100);
            entity.Property(e => e.UrunAdi).HasMaxLength(30);
            entity.Property(e => e.UrunKodu).HasMaxLength(10);

            entity.HasOne(d => d.Kategori).WithMany(p => p.TblUrunlers)
                .HasForeignKey(d => d.KategoriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_Urunler_Tbl_Kategoriler1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
