using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace _2380602555_LeNgocQuangVinh_KTGiuaKy.Models
{
    public class SinhVien
    {
        [Key]
        [StringLength(10)]
        public string MaSV { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(5)]
        public string GioiTinh { get; set; }

        [DataType(DataType.Date)]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string Hinh { get; set; }

        [StringLength(4)]
        public string MaNganh { get; set; }

        [ForeignKey("MaNganh")]
        public NganhHoc NganhHoc { get; set; }

        public ICollection<DangKy> DangKies { get; set; }
    }
}
