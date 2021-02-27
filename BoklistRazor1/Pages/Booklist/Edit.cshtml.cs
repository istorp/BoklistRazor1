using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoklistRazor1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;

namespace BoklistRazor1.Pages.Booklist
{
    public class EditModel : PageModel
    {
        private  ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Books Books { get; set; }
        public async Task OnGet(int id)
        {
            Books = await _db.Books.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var BookFromDb = await _db.Books.FindAsync(Books.Id);
                BookFromDb.Name = Books.Name;
                BookFromDb.Auther = Books.Auther;
                BookFromDb.ISBN = Books.ISBN;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
