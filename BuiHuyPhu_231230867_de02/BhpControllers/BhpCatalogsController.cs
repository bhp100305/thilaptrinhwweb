using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuiHuyPhu_231230867_de02.Models;

namespace BuiHuyPhu_231230867_de02.BhpControllers
{
    public class BhpCatalogsController : Controller
    {
        private readonly BuiiHuyPhu231230867De02Context _context;

        public BhpCatalogsController(BuiiHuyPhu231230867De02Context context)
        {
            _context = context;
        }

        // ===========================
        // 🔹 Danh sách sản phẩm
        // ===========================
        public async Task<IActionResult> bhpIndex()
        {
            return View(await _context.BhpCatalogs.ToListAsync());
        }

        // ===========================
        // 🔹 Chi tiết sản phẩm
        // ===========================
        public async Task<IActionResult> bhpDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bhpCatalog = await _context.BhpCatalogs
                .FirstOrDefaultAsync(m => m.HvtId == id);
            if (bhpCatalog == null)
            {
                return NotFound();
            }

            return View(bhpCatalog);
        }

        // ===========================
        // 🔹 Thêm mới sản phẩm (GET)
        // ===========================
        public IActionResult bhpCreate()
        {
            return View();
        }

        // ===========================
        // 🔹 Thêm mới sản phẩm (POST)
        // ===========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> bhpCreate(
            [Bind("HvtId,HvtCateName,HvtCatePrice,HvtCateQty,HvtCateActive")] BhpCatalog bhpCatalog,
            IFormFile? imageFile)
        {
            if (ModelState.IsValid)
            {
                // Nếu có chọn ảnh
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Thư mục lưu ảnh
                    string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                    // Tạo nếu chưa có
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // Lấy tên file
                    string fileName = Path.GetFileName(imageFile.FileName);

                    // Đường dẫn đầy đủ trên ổ đĩa
                    string filePath = Path.Combine(uploadFolder, fileName);

                    // Lưu file vật lý vào thư mục wwwroot/images
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Lưu đường dẫn tương đối (để hiển thị ảnh)
                    bhpCatalog.HvtPicture = "/images/" + fileName;
                }

                _context.Add(bhpCatalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(bhpIndex));
            }

            return View(bhpCatalog);
        }

        // ===========================
        // 🔹 Sửa sản phẩm (GET)
        // ===========================
        public async Task<IActionResult> bhpEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bhpCatalog = await _context.BhpCatalogs.FindAsync(id);
            if (bhpCatalog == null)
            {
                return NotFound();
            }
            return View(bhpCatalog);
        }

        // ===========================
        // 🔹 Sửa sản phẩm (POST)
        // ===========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> bhpEdit(int id, [Bind("HvtId,HvtCateName,HvtCatePrice,HvtCateQty,HvtPicture,HvtCateActive")] BhpCatalog bhpCatalog)
        {
            if (id != bhpCatalog.HvtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bhpCatalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BhpCatalogExists(bhpCatalog.HvtId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(bhpIndex));
            }
            return View(bhpCatalog);
        }

        // ===========================
        // 🔹 Xóa sản phẩm (GET)
        // ===========================
        public async Task<IActionResult> bhpDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bhpCatalog = await _context.BhpCatalogs
                .FirstOrDefaultAsync(m => m.HvtId == id);
            if (bhpCatalog == null)
            {
                return NotFound();
            }

            return View(bhpCatalog);
        }

        // ===========================
        // 🔹 Xóa sản phẩm (POST)
        // ===========================
        [HttpPost, ActionName("bhpDeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> bhpDeleteConfirmed(int id)
        {
            var bhpCatalog = await _context.BhpCatalogs.FindAsync(id);
            if (bhpCatalog != null)
            {
                _context.BhpCatalogs.Remove(bhpCatalog);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(bhpIndex));
        }

        // ===========================
        // 🔹 Kiểm tra tồn tại
        // ===========================
        private bool BhpCatalogExists(int id)
        {
            return _context.BhpCatalogs.Any(e => e.HvtId == id);
        }
    }
}
