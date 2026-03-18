using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2380602555_LeNgocQuangVinh_KTGiuaKy.Models;

namespace _2380602555_LeNgocQuangVinh_KTGiuaKy.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SinhVienController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var sinhViens = await _context.SinhViens.Include(s => s.NganhHoc).ToListAsync();
            return View(sinhViens);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var sinhVien = await _context.SinhViens
                .Include(s => s.NganhHoc)
                .FirstOrDefaultAsync(m => m.MaSV == id);

            if (sinhVien == null) return NotFound();

            return View(sinhVien);
        }

        public IActionResult Create()
        {
            ViewBag.MaNganh = new SelectList(_context.NganhHocs, "MaNganh", "TenNganh");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SinhVien sinhVien, IFormFile? HinhUpload)
        {
            ModelState.Remove("HinhUpload");
            ModelState.Remove("NganhHoc");
            ModelState.Remove("DangKies");
            ModelState.Remove("Hinh");

            if (ModelState.IsValid)
            {
                if (HinhUpload != null && HinhUpload.Length > 0)
                {
                    sinhVien.Hinh = await UploadHinh(HinhUpload);
                }

                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MaNganh = new SelectList(_context.NganhHocs, "MaNganh", "TenNganh", sinhVien.MaNganh);
            return View(sinhVien);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var sinhVien = await _context.SinhViens.FindAsync(id);
            if (sinhVien == null) return NotFound();

            ViewBag.MaNganh = new SelectList(_context.NganhHocs, "MaNganh", "TenNganh", sinhVien.MaNganh);
            return View(sinhVien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SinhVien sinhVien, IFormFile? HinhUpload)
        {
            if (id != sinhVien.MaSV) return NotFound();

            ModelState.Remove("HinhUpload");
            ModelState.Remove("NganhHoc");
            ModelState.Remove("DangKies");
            ModelState.Remove("Hinh");

            if (ModelState.IsValid)
            {
                try
                {
                    var existingSV = await _context.SinhViens.AsNoTracking().FirstOrDefaultAsync(s => s.MaSV == id);

                    if (HinhUpload != null && HinhUpload.Length > 0)
                    {
                        sinhVien.Hinh = await UploadHinh(HinhUpload);
                    }
                    else
                    {
                        sinhVien.Hinh = existingSV.Hinh;
                    }

                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.MaSV)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MaNganh = new SelectList(_context.NganhHocs, "MaNganh", "TenNganh", sinhVien.MaNganh);
            return View(sinhVien);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            var sinhVien = await _context.SinhViens
                .Include(s => s.NganhHoc)
                .FirstOrDefaultAsync(m => m.MaSV == id);

            if (sinhVien == null) return NotFound();

            return View(sinhVien);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sinhVien = await _context.SinhViens.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SinhViens.Remove(sinhVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
            return _context.SinhViens.Any(e => e.MaSV == id);
        }

        private async Task<string> UploadHinh(IFormFile file)
        {
            string uploadFolder = Path.Combine(_env.WebRootPath, "Content", "images");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string extension = Path.GetExtension(file.FileName);
            string shortGuid = Guid.NewGuid().ToString().Substring(0, 10);
            string uniqueFileName = shortGuid + extension;

            string filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return "/Content/images/" + uniqueFileName;
        }
    }
}