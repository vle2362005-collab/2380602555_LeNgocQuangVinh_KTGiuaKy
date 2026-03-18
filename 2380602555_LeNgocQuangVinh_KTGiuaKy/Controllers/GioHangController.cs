using Microsoft.AspNetCore.Mvc;
using _2380602555_LeNgocQuangVinh_KTGiuaKy.Models;
using System.Text.Json;

namespace _2380602555_LeNgocQuangVinh_KTGiuaKy.Controllers
{
    public class GioHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GioHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        private List<CartItem> GetCartItems()
        {
            var sessionCart = HttpContext.Session.GetString("GioHang");
            if (sessionCart != null)
            {
                return JsonSerializer.Deserialize<List<CartItem>>(sessionCart);
            }
            return new List<CartItem>();
        }

        private void SaveCartSession(List<CartItem> cart)
        {
            var jsonCart = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString("GioHang", jsonCart);
        }

        public IActionResult GioHang()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("MaSV")))
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }

            var cart = GetCartItems();
            return View(cart);
        }

        public IActionResult ThemGioHang(string maHP)
        {
            var cart = GetCartItems();
            var item = cart.FirstOrDefault(c => c.MaHP == maHP);

            if (item == null) 
            {
                var hocPhan = _context.HocPhans.FirstOrDefault(h => h.MaHP == maHP);
                if (hocPhan != null)
                {
                    cart.Add(new CartItem
                    {
                        MaHP = hocPhan.MaHP,
                        TenHP = hocPhan.TenHP,
                        SoTinChi = hocPhan.SoTinChi ?? 0
                    });
                    SaveCartSession(cart);
                }
            }
            return RedirectToAction("GioHang");
        }

        public IActionResult XoaGioHang(string maHP)
        {
            var cart = GetCartItems();
            var item = cart.FirstOrDefault(c => c.MaHP == maHP);
            if (item != null)
            {
                cart.Remove(item);
                SaveCartSession(cart);
            }
            return RedirectToAction("GioHang");
        }

        public IActionResult XoaTatCa()
        {
            HttpContext.Session.Remove("GioHang");
            return RedirectToAction("GioHang");
        }
        [HttpGet]
        public IActionResult DatHang()
        {
            var maSV = HttpContext.Session.GetString("MaSV");
            if (string.IsNullOrEmpty(maSV))
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }

            var cart = GetCartItems();
            if (cart.Count == 0)
            {
                return RedirectToAction("GioHang");
            }

            var sinhVien = _context.SinhViens.FirstOrDefault(s => s.MaSV == maSV);
            ViewBag.SinhVien = sinhVien;

            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> DatHang(string xacNhan)
        {
            var maSV = HttpContext.Session.GetString("MaSV");
            var cart = GetCartItems();

            if (string.IsNullOrEmpty(maSV) || cart.Count == 0) return RedirectToAction("GioHang");

            var dangKy = new DangKy
            {
                NgayDK = DateTime.Now,
                MaSV = maSV
            };
            _context.DangKies.Add(dangKy);

            await _context.SaveChangesAsync();

            foreach (var item in cart)
            {
                var chiTiet = new ChiTietDangKy
                {
                    MaDK = dangKy.MaDK, 
                    MaHP = item.MaHP
                };
                _context.ChiTietDangKies.Add(chiTiet);
                var hocPhan = await _context.HocPhans.FindAsync(item.MaHP);
                if (hocPhan != null && hocPhan.SoLuong > 0)
                {
                    hocPhan.SoLuong -= 1;
                    _context.HocPhans.Update(hocPhan);
                }
            }

            await _context.SaveChangesAsync();
            HttpContext.Session.Remove("GioHang");

            return RedirectToAction("XacNhanDonHang");
        }
        public IActionResult XacNhanDonHang()
        {
            return View();
        }
    }
}