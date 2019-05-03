using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRUD_Razor_2_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Razor_2_1.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet(int id)
        {
            Book = _db.Books.Find(id);

        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var bookFromDb = _db.Books.Find(Book.Id);
                bookFromDb.Name = Book.Name;
                bookFromDb.ISBN = Book.ISBN;
                bookFromDb.Author = Book.Author;

                await _db.SaveChangesAsync();
                Message = "Book has been updated successfully";

                return RedirectToPage("Index");

            }

            return RedirectToPage();

        }
    }
}