using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2502E_Assignment_Nguyen_anh_tu_NetCore.Models;

public class Singer
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Tên Ca sĩ không được để trống")]
    public string Name { get; set; } = string.Empty;
    
    public string? Biography  { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public int Status { get; set; } = 1;
    
    [NotMapped] // Không tạo cột này trong Database
    public IFormFile? ImageFile { get; set; } 
    
    public virtual ICollection<Song> Songs { get; set; } = new Collection<Song>();
}