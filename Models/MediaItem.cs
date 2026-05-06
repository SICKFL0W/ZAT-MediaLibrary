using System.ComponentModel.DataAnnotations;

namespace MediaLibraryApp.Models
{

    public abstract class MediaItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Název položky je povinný")]
        public string Title { get; set; } = String.Empty;

        public DateTime DateAcquired { get; set; } = DateTime.Now;

        public string? Description { get; set; }

        public string? BorrowedBy { get; set; }

        public bool IsBorrowed => !string.IsNullOrEmpty(BorrowedBy);


    }

    public class Book : MediaItem
    {
        [Required(ErrorMessage = "Autor je povinný")]
        public string Author { get; set; } = string.Empty;
    }

    public class CD : MediaItem
    {
        [Required(ErrorMessage = "Interpret je povinný")]
        public string Artist { get; set; } = string.Empty;
    }

    public class DVD : MediaItem
    {
        [Required(ErrorMessage = "Režisér je povinný")]
        public string Director { get; set; } = string.Empty;
    }

}