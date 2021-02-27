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
        public async Task<IActionResult> OnPost()//bara för jag har bindproperty på prop så tar den för givet att det är den har annars hade jag behövt skriva Books booksObj
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
