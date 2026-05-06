using Microsoft.EntityFrameworkCore;
using MediaLibraryApp.Models;

namespace MediaLibraryApp.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<MediaItem> MediaItems { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<CD> CDs { get; set; }
        public DbSet<DVD> DVDs { get; set; }
    }
}