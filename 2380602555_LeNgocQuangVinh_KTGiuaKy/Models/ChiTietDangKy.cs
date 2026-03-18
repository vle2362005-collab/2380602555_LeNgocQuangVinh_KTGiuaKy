using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2380602555_LeNgocQuangVinh_KTGiuaKy.Models
{
    public class ChiTietDangKy
    {
        public int MaDK { get; set; }
        [ForeignKey("MaDK")]
        public DangKy DangKy { get; set; }

        [StringLength(6)]
        public string MaHP { get; set; }
        [ForeignKey("MaHP")]
        public HocPhan HocPhan { get; set; }
    }
}
