using MediaLibraryApp.Data;
using MediaLibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace MediaLibraryApp.Controllers
{
    public class MediaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MediaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _context.MediaItems.ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MediaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            MediaItem newItem;

            switch (model.MediaType)
            {
                case "Book":
                    newItem = new Book { Title = model.Title, Description = model.Description, BorrowedBy = model.BorrowedBy, Author = model.Author ?? "Neznámý" };
                    break;
                case "CD":
                    newItem = new CD { Title = model.Title, Description = model.Description, BorrowedBy = model.BorrowedBy, Artist = model.Artist ?? "Neznámý" };
                    break;
                case "DVD":
                    newItem = new DVD { Title = model.Title, Description = model.Description, BorrowedBy = model.BorrowedBy, Director = model.Director ?? "Neznámý" };
                    break;
                default:
                    return View(model);
            }

            try
            {
                _context.MediaItems.Add(newItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Při ukládání položky do databáze došlo k chybě. Zkuste to prosím znovu.");
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            
            var item = await _context.MediaItems.FindAsync(id);
            if (item == null) return NotFound();

            var model = new MediaViewModel()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                BorrowedBy = item.BorrowedBy,
                MediaType = item.GetType().Name
            };

            if (item is Book book) model.Author = book.Author;
            if (item is CD cd) model.Artist = cd.Artist;
            if (item is DVD dvd) model.Director = dvd.Director;
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MediaViewModel model)
        {
            if (id != model.Id) return NotFound();

            if (!ModelState.IsValid) return View(model);
            
            var item = await _context.MediaItems.FindAsync(model.Id);
            if (item == null) return NotFound();
            
            item.Title = model.Title;
            item.Description = model.Description;
            item.BorrowedBy = model.BorrowedBy;

            if (item is Book book) book.Author = model.Author ?? "Neznámý";
            if (item is CD cd) cd.Artist = model.Artist ?? "Neznámý";
            if (item is DVD dvd) dvd.Director = model.Director ?? "Neznámý";
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            
            var item = await _context.MediaItems.FindAsync(id);
            if (item == null) return NotFound();
            
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.MediaItems.FindAsync(id);
            if (item != null)
            {
                _context.MediaItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }

    }
}