using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Data;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Helpers;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Models;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.ViewModels;

namespace T2502E_Assignment_Nguyen_anh_tu_NetCore.Controllers;

public class ComposerController : Controller
{
    // GET
    private readonly AppDbContext _context;
    private readonly IPhotoService _photoService;

    public ComposerController(AppDbContext context, IPhotoService photoService)
    {
        _context = context;
        _photoService = photoService;
    }


    // GET
    public async Task<IActionResult> Index(ComposerFilterViewModel filter, int? pageIndex)
    {
        var query = _context.Composers.AsQueryable();

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
        
        filter.Composers = await PaginatedList<Composer>.CreateAsync(query.AsNoTracking(), pageIndex ?? 1, pageSize);
        
        return View(filter);
    }
    
    public async Task<IActionResult> Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Composer composer)
    {
        if (ModelState.IsValid)
        {
            if (composer.ImageFile != null)
            {
                var result = await _photoService.AddPhotoAsync(composer.ImageFile);
                if (result.Error != null)
                {
                    ModelState.AddModelError("ImageFile", "Tải ảnh thất bại.");
                    return View(composer);
                }

                composer.ImageUrl = result.SecureUrl.AbsoluteUri; // Lấy URL từ Cloudinary
            }

            var sanitizer = new HtmlSanitizer();
            string cleanHtml = sanitizer.Sanitize(composer.Biography);

            composer.Biography = cleanHtml;
            _context.Add(composer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(composer);
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var composer = await _context.Composers.FindAsync(id);
        return composer == null ? NotFound() : View(composer);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Composer composer)
    {
        if (ModelState.IsValid)
        {
            if (composer.ImageFile != null)
            {
                var result = await _photoService.AddPhotoAsync(composer.ImageFile);
                if (result.Error != null)
                {
                    ModelState.AddModelError("ImageFile", "Tải ảnh thất bại.");
                    return View(composer);
                }

                composer.ImageUrl = result.SecureUrl.AbsoluteUri; // Lấy URL từ Cloudinary
            }
            

            var sanitizer = new HtmlSanitizer();
            string cleanHtml = sanitizer.Sanitize(composer.Biography);

            composer.Biography = cleanHtml;
            _context.Update(composer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(composer);
    }
}