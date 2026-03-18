using Microsoft.AspNetCore.Mvc;
using _2380602555_LeNgocQuangVinh_KTGiuaKy.Models;

namespace _2380602555_LeNgocQuangVinh_KTGiuaKy.Controllers
{
    public class NguoiDungController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NguoiDungController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangNhap(string MaSV)
        {
            if (string.IsNullOrEmpty(MaSV))
            {
                ViewBag.Error = "Vui lòng nhập Mã Sinh Viên!";
                return View();
            }

            var sinhVien = _context.SinhViens.FirstOrDefault(s => s.MaSV == MaSV);

            if (sinhVien != null)
            {
                HttpContext.Session.SetString("MaSV", sinhVien.MaSV);
                HttpContext.Session.SetString("HoTen", sinhVien.HoTen);
                return RedirectToAction("ListHP", "HocPhan");
            }

            ViewBag.Error = "Mã Sinh Viên không tồn tại!";
            return View();
        }

        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("DangNhap");
        }
    }
}