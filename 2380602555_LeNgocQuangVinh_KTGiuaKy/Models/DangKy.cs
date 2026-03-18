using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2380602555_LeNgocQuangVinh_KTGiuaKy.Models
{
    public class DangKy
    {
        [Key]
        public int MaDK { get; set; } 

        [DataType(DataType.Date)]
        public DateTime? NgayDK { get; set; }

        [StringLength(10)]
        public string MaSV { get; set; }

        [ForeignKey("MaSV")]
        public SinhVien SinhVien { get; set; }

        public ICollection<ChiTietDangKy> ChiTietDangKies { get; set; }
    }
}
