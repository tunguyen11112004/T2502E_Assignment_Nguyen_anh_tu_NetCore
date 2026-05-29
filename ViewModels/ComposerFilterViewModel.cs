using T2502E_Assignment_Nguyen_anh_tu_NetCore.Helpers;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Models;

namespace T2502E_Assignment_Nguyen_anh_tu_NetCore.ViewModels;

public class ComposerFilterViewModel
{
    public string? Keyword { get; set; }
    public string? DateRange { get; set; } 
    public string? SortOrder { get; set; }
    
    public int? PageIndex { get; set; }
    
    public PaginatedList<Composer> Composers { get; set; }
}