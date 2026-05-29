using T2502E_Assignment_Nguyen_anh_tu_NetCore.Helpers;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Models;

namespace T2502E_Assignment_Nguyen_anh_tu_NetCore.ViewModels;

public class SongFilterViewModel
{
    public string? Keyword { get; set; }
    public string? DateRange { get; set; }
    public string? SortOrder { get; set; }
    
    public int? PageIndex { get; set; }
    
    public PaginatedList<Song> Songs { get; set; }
    
    public PaginatedList<Song> Singers { get; set; }
    
    public PaginatedList<Song> Composers { get; set; }
}