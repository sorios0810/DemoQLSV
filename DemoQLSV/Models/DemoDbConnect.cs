namespace DemoQLSV.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DemoDbConnect : DbContext
    {
        public DemoDbConnect()
            : base("name=DemoDbConnect")
        {
        }

        public virtual DbSet<DMKhoa> DMKhoas { get; set; }
        public virtual DbSet<DMMH> DMMHs { get; set; }
        public virtual DbSet<DMSV> DMSVs { get; set; }
        public virtual DbSet<KetQua> KetQuas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DMKhoa>()
                .Property(e => e.MaKhoa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DMMH>()
                .Property(e => e.MaMH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DMMH>()
                .HasMany(e => e.KetQuas)
                .WithRequired(e => e.DMMH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DMSV>()
                .Property(e => e.MaSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DMSV>()
                .Property(e => e.Phai)
                .IsFixedLength();

            modelBuilder.Entity<DMSV>()
                .Property(e => e.MaKhoa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DMSV>()
                .HasMany(e => e.KetQuas)
                .WithRequired(e => e.DMSV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KetQua>()
                .Property(e => e.MaSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KetQua>()
                .Property(e => e.MaMH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KetQua>()
                .Property(e => e.Diem)
                .HasPrecision(4, 2);
        }
    }
}
