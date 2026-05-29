using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2502E_Assignment_Nguyen_anh_tu_NetCore.Models;

public class Song
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Tên Bài hát không được để trống")]
    [MinLength(5)]
    public string Title { get; set; } = string.Empty;

    public string Lyrics  { get; set; } = string.Empty;
    
    public string? ThumbnailUrl  { get; set; }
    
    public string? Mp3Link { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    
    public DateTime CreatedAt  { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public int SingerId { get; set; }
    [ForeignKey("SingerId")]
    public virtual Singer? Singer { get; set; }

    public int ComposerId { get; set; }
    [ForeignKey("ComposerId")]
    public virtual Composer? Composer { get; set; }
    
    public int Status { get; set; } = 1;
    
    [NotMapped] // Không tạo cột này trong Database
    public IFormFile? ImageFile { get; set; } 
    
    [NotMapped]
    public IFormFile? AudioFile { get; set; }
}