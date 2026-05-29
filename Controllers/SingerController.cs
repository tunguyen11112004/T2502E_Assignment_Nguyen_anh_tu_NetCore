using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Data;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Helpers;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Models;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.ViewModels;

namespace T2502E_Assignment_Nguyen_anh_tu_NetCore.Controllers;

public class SingerController : Controller
{
    // GET
    private readonly AppDbContext _context;
    private readonly IPhotoService _photoService;

    public SingerController(AppDbContext context, IPhotoService photoService)
    {
        _context = context;
        _photoService = photoService;
    }


    // GET
    public async Task<IActionResult> Index(SingerFilterViewModel filter, int? pageIndex)
    {
        var query = _context.Singers.AsQueryable();

        // 1. Logic Lọc
        if (!string.IsNullOrEmpty(filter.Keyword))
        {
            /*query = query.Where(u => u.Title.Contains(filter.Keyword));*/
            var keyword = $"%{filter.Keyword.Trim()}%"; // Tạo chuỗi dạng %từ_khóa%
            query = query.Where(u => EF.Functions.Like(u.Name, keyword));
        }

        // 3. Logic Sắp xếp
        query = filter.SortOrder switch
        {
            "name_desc" => query.OrderByDescending(u => u.Name),
            _ => query.OrderBy(u => u.Name),
        };
        
        // 4. Thực thi Phân trang
        int pageSize = 10; // Số lượng bản ghi trên mỗi trang
        
        filter.Singers = await PaginatedList<Singer>.CreateAsync(query.AsNoTracking(), pageIndex ?? 1, pageSize);
        
        return View(filter);
    }
    
    public async Task<IActionResult> Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Singer singer)
    {
        if (ModelState.IsValid)
        {
            if (singer.ImageFile != null)
            {
                var result = await _photoService.AddPhotoAsync(singer.ImageFile);
                if (result.Error != null)
                {
                    ModelState.AddModelError("ImageFile", "Tải ảnh thất bại.");
                    return View(singer);
                }

                singer.ImageUrl = result.SecureUrl.AbsoluteUri; // Lấy URL từ Cloudinary
            }

            var sanitizer = new HtmlSanitizer();
            string cleanHtml = sanitizer.Sanitize(singer.Biography);

            singer.Biography = cleanHtml;
            _context.Add(singer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(singer);
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var singer = await _context.Singers.FindAsync(id);
        return singer == null ? NotFound() : View(singer);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Singer singer)
    {
        if (ModelState.IsValid)
        {
            if (singer.ImageFile != null)
            {
                var result = await _photoService.AddPhotoAsync(singer.ImageFile);
                if (result.Error != null)
                {
                    ModelState.AddModelError("ImageFile", "Tải ảnh thất bại.");
                    return View(singer);
                }

                singer.ImageUrl = result.SecureUrl.AbsoluteUri; // Lấy URL từ Cloudinary
            }
            

            var sanitizer = new HtmlSanitizer();
            string cleanHtml = sanitizer.Sanitize(singer.Biography);

            singer.Biography = cleanHtml;
            _context.Update(singer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(singer);
    }
}