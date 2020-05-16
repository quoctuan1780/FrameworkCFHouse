namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CoffeeHouse : DbContext
    {
        public CoffeeHouse()
            : base("name=CoffeeHouse")
        {
        }

        public virtual DbSet<activation> activations { get; set; }
        public virtual DbSet<ctdh> ctdhs { get; set; }
        public virtual DbSet<cthd> cthds { get; set; }
        public virtual DbSet<dknt> dknts { get; set; }
        public virtual DbSet<donhang> donhangs { get; set; }
        public virtual DbSet<gioithieu> gioithieux { get; set; }
        public virtual DbSet<hoadon> hoadons { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<loaisanpham> loaisanphams { get; set; }
        public virtual DbSet<phanhoi> phanhois { get; set; }
        public virtual DbSet<quyen> quyens { get; set; }
        public virtual DbSet<reminder> reminders { get; set; }
        public virtual DbSet<sanpham> sanphams { get; set; }
        public virtual DbSet<slide> slides { get; set; }
        public virtual DbSet<tintuc> tintucs { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<activation>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<dknt>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<donhang>()
                .Property(e => e.httt)
                .IsUnicode(false);

            modelBuilder.Entity<donhang>()
                .Property(e => e.ghichu)
                .IsUnicode(false);

            modelBuilder.Entity<gioithieu>()
                .Property(e => e.tieude)
                .IsUnicode(false);

            modelBuilder.Entity<gioithieu>()
                .Property(e => e.noidung)
                .IsUnicode(false);

            modelBuilder.Entity<gioithieu>()
                .Property(e => e.hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.httt)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.ghichu)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.hoten)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.gioitinh)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.diachi)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.sodt)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.ghichu)
                .IsUnicode(false);

            modelBuilder.Entity<loaisanpham>()
                .Property(e => e.tenloaisp)
                .IsUnicode(false);

            modelBuilder.Entity<loaisanpham>()
                .Property(e => e.mota)
                .IsUnicode(false);

            modelBuilder.Entity<loaisanpham>()
                .Property(e => e.hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<phanhoi>()
                .Property(e => e.hoten)
                .IsUnicode(false);

            modelBuilder.Entity<phanhoi>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<phanhoi>()
                .Property(e => e.vande)
                .IsUnicode(false);

            modelBuilder.Entity<phanhoi>()
                .Property(e => e.noidung)
                .IsUnicode(false);

            modelBuilder.Entity<quyen>()
                .Property(e => e.tenquyen)
                .IsUnicode(false);

            modelBuilder.Entity<reminder>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.tensp)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.mota)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.dvt)
                .IsUnicode(false);

            modelBuilder.Entity<slide>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<slide>()
                .Property(e => e.hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<tintuc>()
                .Property(e => e.tieude)
                .IsUnicode(false);

            modelBuilder.Entity<tintuc>()
                .Property(e => e.noidung)
                .IsUnicode(false);

            modelBuilder.Entity<tintuc>()
                .Property(e => e.hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.tentk)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.remember_token)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.hinhanh)
                .IsUnicode(false);
        }
    }
}
