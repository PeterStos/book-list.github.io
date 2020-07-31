using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookListApp.Model;

namespace BookListApp.Pages.BookList
{
    public class CreateModel : PageModel  
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty] // 
        public Book Book { get; set; }

        public void OnGet()
        {
            
        }

        //public async Task<IActionResult> OnPost(Book bookObj) // this is an option 
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) // if valid we can add into the database
            {
                await _db.Books.AddAsync(Book); // add to queue
                await _db.SaveChangesAsync(); // push to the database
                return RedirectToPage("Index");            
            }
            else
            {
                return Page();
            }

        }

    }
}