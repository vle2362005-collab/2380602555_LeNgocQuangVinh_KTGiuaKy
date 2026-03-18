using System.ComponentModel.DataAnnotations;

namespace _2380602555_LeNgocQuangVinh_KTGiuaKy.Models
{
    public class NganhHoc
    {
        [Key]
        [StringLength(4)]
        public string MaNganh { get; set; }

        [StringLength(30)]
        public string TenNganh { get; set; }

        public ICollection<SinhVien> SinhViens { get; set; }
    }
}
