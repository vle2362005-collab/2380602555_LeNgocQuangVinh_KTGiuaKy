using Microsoft.EntityFrameworkCore;
using _2380602555_LeNgocQuangVinh_KTGiuaKy.Models;

namespace _2380602555_LeNgocQuangVinh_KTGiuaKy.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<NganhHoc> NganhHocs { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<HocPhan> HocPhans { get; set; }
        public DbSet<DangKy> DangKies { get; set; }
        public DbSet<ChiTietDangKy> ChiTietDangKies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChiTietDangKy>()
                .HasKey(c => new { c.MaDK, c.MaHP });

            modelBuilder.Entity<NganhHoc>().HasData(
                new NganhHoc { MaNganh = "CNTT", TenNganh = "Công nghệ thông tin" },
                new NganhHoc { MaNganh = "QTKD", TenNganh = "Quản trị kinh doanh" }
            );
            modelBuilder.Entity<HocPhan>().HasData(
                new HocPhan { MaHP = "CNTT01", TenHP = "Lập trình C", SoTinChi = 3, SoLuong = 99 },
                new HocPhan { MaHP = "CNTT02", TenHP = "Cơ sở dữ liệu", SoTinChi = 2, SoLuong = 99 },
                new HocPhan { MaHP = "QTKD01", TenHP = "Kinh tế vi mô", SoTinChi = 2, SoLuong = 100 },
                new HocPhan { MaHP = "QTDK02", TenHP = "Xác suất thống kê 1", SoTinChi = 3, SoLuong = 99 }
            );

            modelBuilder.Entity<SinhVien>().HasData(
                new SinhVien { MaSV = "2380602555", HoTen = "Lê Ngọc Quang Vinh", GioiTinh = "Nam", NgaySinh = new DateTime(2005, 6, 23), Hinh = "/Content/images/sv1.jpg", MaNganh = "CNTT" }
            );
        }
    }
}
