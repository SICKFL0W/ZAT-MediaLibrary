using System.ComponentModel.DataAnnotations;

namespace MediaLibraryApp.Models;

public class MediaViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Název je povinný")]
    public string Title { get; set; } = String.Empty;
    
    public string? Description { get; set; }
    
    public string MediaType { get; set; } = "Book";
    
    public string? Author { get; set; }
    public string? Artist { get; set; }
    public string? Director { get; set; }
    
    public string? BorrowedBy { get; set; }
}