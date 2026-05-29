using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Data;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Helpers;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Models;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Services;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.ViewModels;

namespace T2502E_Assignment_Nguyen_anh_tu_NetCore.Controllers;

public class SongController : Controller
{
    // GET
    private readonly AppDbContext _context;
    private readonly IPhotoService _photoService;

    public SongController(AppDbContext context, IPhotoService photoService)
    {
        _context = context;
        _photoService = photoService;
    }


    // GET
    public async Task<IActionResult> Index(SongFilterViewModel filter, int? pageIndex)
    {
        var query = _context.Songs.Include(c => c.Singer).Include(c => c.Composer).AsQueryable();

        // 1. Logic Lọc
        if (!string.IsNullOrEmpty(filter.Keyword))
        {
            /*query = query.Where(u => u.Title.Contains(filter.Keyword));*/
            var keyword = $"%{filter.Keyword.Trim()}%"; // Tạo chuỗi dạng %từ_khóa%
            query = query.Where(u => EF.Functions.Like(u.Title, keyword));
        }
        
        // 2. Logic Thời gian
        if (!string.IsNullOrEmpty(filter.DateRange))
        {
            var dates = filter.DateRange.Split('-').Select(d => d.Trim()).ToArray();
            if (dates.Length == 2)
            {
                var ReleaseDate = DateTime.ParseExact(dates[0], "MM/dd/yyyy", null);
                var UpdatedAt = DateTime.ParseExact(dates[1], "MM/dd/yyyy", null);
                query = query.Where(u => u.ReleaseDate >= ReleaseDate && u.ReleaseDate <= UpdatedAt);
            }
        }

        // 3. Logic Sắp xếp
        query = filter.SortOrder switch
        {
            "name_desc" => query.OrderByDescending(u => u.Title),
            "date_asc" => query.OrderBy(u => u.ReleaseDate),
            "date_desc" => query.OrderByDescending(u => u.ReleaseDate),
            _ => query.OrderBy(u => u.Title),
        };
        
        // 4. Thực thi Phân trang
        int pageSize = 10; // Số lượng bản ghi trên mỗi trang
        
        
        
        filter.Songs = await PaginatedList<Song>.CreateAsync(query.AsNoTracking(), pageIndex ?? 1, pageSize);

        
        var allSongsQuery = _context.Songs.Include(c => c.Singer).Include(c => c.Composer).AsQueryable();
        filter.Singers = await PaginatedList<Song>.CreateAsync(allSongsQuery.AsNoTracking(), pageIndex ?? 1, pageSize);
        filter.Composers = await PaginatedList<Song>.CreateAsync(allSongsQuery.AsNoTracking(), pageIndex ?? 1, pageSize);
        return View(filter);
    }
    
    public async Task<IActionResult> Create()
    {
        // Lấy danh sách ID và Name để đổ vào Dropdown
        var Singers = await _context.Singers.ToListAsync();
        ViewBag.SingerId = new SelectList(Singers, "Id", "Name");
        var Composers = await _context.Composers.ToListAsync();
        ViewBag.ComposerId = new SelectList(Composers, "Id", "Name");
    
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Song song)
    {
        if (ModelState.IsValid)
        {
            if (song.ImageFile != null)
            {
                var result = await _photoService.AddPhotoAsync(song.ImageFile);
                if (result.Error != null)
                {
                    ModelState.AddModelError("ImageFile", "Tải ảnh thất bại.");
                    return View(song);
                }

                song.ThumbnailUrl = result.SecureUrl.AbsoluteUri; // Lấy URL từ Cloudinary
            }
            
            if (song.AudioFile != null)
            {
                var results = await _photoService.AddAudioAsync(song.AudioFile);
                if (results.Error != null)
                {
                    ModelState.AddModelError("AudioFile", "Tải Audio thất bại.");
                    return View(song);
                }

                song.Mp3Link = results.SecureUrl.AbsoluteUri; // Lấy URL từ Cloudinary
            }

            if (song.ReleaseDate < DateTime.Now)
            {
                ModelState.AddModelError("ReleaseDate", "Ngày phát hành không dược trước ngày hiện tại.");
                return View(song);
            }

            var sanitizer = new HtmlSanitizer();
            string cleanHtml = sanitizer.Sanitize(song.Lyrics);

            song.Lyrics = cleanHtml;
            song.CreatedAt = DateTime.Now;
            song.UpdatedAt = DateTime.Now;
            _context.Add(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(song);
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        // Lấy danh sách ID và Name để đổ vào Dropdown
        var Singers = await _context.Singers.ToListAsync();
        ViewBag.SingerId = new SelectList(Singers, "Id", "Name");
        var Composers = await _context.Composers.ToListAsync();
        ViewBag.ComposerId = new SelectList(Composers, "Id", "Name");
        var Song = await _context.Songs.FindAsync(id);
        return Song == null ? NotFound() : View(Song);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Song song)
    {
        if (ModelState.IsValid)
        {
            if (song.ImageFile != null)
            {
                var result = await _photoService.AddPhotoAsync(song.ImageFile);
                if (result.Error != null)
                {
                    ModelState.AddModelError("ImageFile", "Tải ảnh thất bại.");
                    return View(song);
                }

                song.ThumbnailUrl = result.SecureUrl.AbsoluteUri; // Lấy URL từ Cloudinary
            }
            
            if (song.AudioFile != null)
            {
                var results = await _photoService.AddAudioAsync(song.AudioFile);
                if (results.Error != null)
                {
                    ModelState.AddModelError("AudioFile", "Tải Audio thất bại.");
                    return View(song);
                }

                song.Mp3Link = results.SecureUrl.AbsoluteUri; // Lấy URL từ Cloudinary
            }

            var sanitizer = new HtmlSanitizer();
            string cleanHtml = sanitizer.Sanitize(song.Lyrics);

            song.Lyrics = cleanHtml;
            song.UpdatedAt = DateTime.Now;
            _context.Update(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(song);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken] // Nên bổ sung để bảo mật (Cần gửi kèm Token nếu dùng AJAX phức tạp hơn)
    public async Task<IActionResult> DeleteSelected(List<int> ids)
    {
        if (ids == null || ids.Count == 0)
        {
            return Json(new { success = false, message = "Không có tài khoản nào được chọn." });
        }

        try
        {
            // Lấy danh sách các User có Id nằm trong list gửi lên
            var songsToDelete = await _context.Songs.Where(u => ids.Contains(u.Id)).ToListAsync();
        
            if (songsToDelete.Any())
            {
                // Xóa cứng (Hard Delete)
                /*_context.Songs.RemoveRange(songsToDelete);*/
            
                // Hoặc Xóa mềm (nếu bảng có trường Status)
                foreach(var songs in songsToDelete) {
                    songs.Status = 0;
                }
            
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = $"Đã xóa thành công {songsToDelete.Count} Bài hát." });
            }

            return Json(new { success = false, message = "Không tìm thấy dữ liệu phù hợp." });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Lỗi: " + ex.Message });
        }
    }
}