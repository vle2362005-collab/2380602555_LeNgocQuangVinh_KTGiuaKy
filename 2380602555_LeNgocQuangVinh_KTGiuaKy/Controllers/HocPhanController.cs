using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2380602555_LeNgocQuangVinh_KTGiuaKy.Models;

namespace _2380602555_LeNgocQuangVinh_KTGiuaKy.Controllers
{
    public class HocPhanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HocPhanController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListHP()
        {
            var maSV = HttpContext.Session.GetString("MaSV");

            if (string.IsNullOrEmpty(maSV))
            {
                TempData["Message"] = "Bạn cần đăng nhập để xem danh sách học phần!";
                return RedirectToAction("DangNhap", "NguoiDung");
            }

            var hocPhans = await _context.HocPhans.ToListAsync();
            return View(hocPhans);
        }
    }
}