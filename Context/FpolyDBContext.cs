﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Project_Template_SM22_Csharp.DomainClass;

#nullable disable

namespace Project_Template_SM22_Csharp.Context
{
    public partial class FpolyDBContext : DbContext
    {
        public FpolyDBContext()
        {
        }

        public FpolyDBContext(DbContextOptions<FpolyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<LoaiSp> LoaiSps { get; set; }
        public virtual DbSet<LoaiXm> LoaiXms { get; set; }
        public virtual DbSet<MoiQuanHe> MoiQuanHes { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Nxb> Nxbs { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<XeMay> XeMays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-D08A7VN;Initial Catalog=FINALASS_FPOLY_NET_JAVA_SM22_BL2;User ID=duytdph20598;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<Ban>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.GioiTinh).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdMqhNavigation)
                    .WithMany(p => p.Bans)
                    .HasForeignKey(d => d.IdMqh)
                    .HasConstraintName("FK1_MQH");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);
            });

            modelBuilder.Entity<LoaiSp>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);
            });

            modelBuilder.Entity<LoaiXm>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);
            });

            modelBuilder.Entity<MoiQuanHe>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.MatKhau).IsUnicode(false);

                entity.Property(e => e.Sdt).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCvNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.IdCv)
                    .HasConstraintName("FK1_NV");
            });

            modelBuilder.Entity<Nxb>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DonGia).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.SoTrang).HasDefaultValueSql("((0))");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdNxbNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.IdNxb)
                    .HasConstraintName("FK1_NXB");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.GiaBan).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdLoaiSpNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.IdLoaiSp)
                    .HasConstraintName("FK1_LSP");
            });

            modelBuilder.Entity<XeMay>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.GiaBan).HasDefaultValueSql("((0))");

                entity.Property(e => e.GiaNhap).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdLxmNavigation)
                    .WithMany(p => p.XeMays)
                    .HasForeignKey(d => d.IdLxm)
                    .HasConstraintName("FK1_LXM");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
