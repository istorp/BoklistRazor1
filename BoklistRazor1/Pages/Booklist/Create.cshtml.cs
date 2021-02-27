using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoklistRazor1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoklistRazor1.Pages.Booklist
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Books Books { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()//bara f�r jag har bindproperty p� prop s� tar den f�r givet att det �r den har annars hade jag beh�vt skriva Books booksObj
        {
            if(ModelState.IsValid)
            {
               await _db.Books.AddAsync(Books);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
