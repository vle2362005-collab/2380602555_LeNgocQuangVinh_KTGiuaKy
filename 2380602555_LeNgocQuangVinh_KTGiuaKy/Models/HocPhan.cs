using System.ComponentModel.DataAnnotations;

namespace _2380602555_LeNgocQuangVinh_KTGiuaKy.Models
{
    public class HocPhan
    {
        [Key]
        [StringLength(6)]
        public string MaHP { get; set; }

        [Required]
        [StringLength(30)]
        public string TenHP { get; set; }

        public int? SoTinChi { get; set; }

        public int? SoLuong { get; set; }

        public ICollection<ChiTietDangKy> ChiTietDangKies { get; set; }
    }
}
