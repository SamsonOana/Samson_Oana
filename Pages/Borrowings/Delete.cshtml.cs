using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Samson_Oana.Data;
using Samson_Oana.Models;

namespace Samson_Oana.Pages.Borrowings
{
    public class DeleteModel : PageModel
    {
        private readonly Samson_Oana.Data.Samson_OanaContext _context;

        public DeleteModel(Samson_Oana.Data.Samson_OanaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; }
        public IList<Borrowing> BorrowingDelete { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);

            if (borrowing == null)
            {
                return NotFound();
            }
            else 
            {
                Borrowing = borrowing;
            }

            if (_context.Borrowing != null)
            {
                BorrowingDelete = await _context.Borrowing
                    .Include(b => b.Book)
                      .ThenInclude(b => b.Author)
                    .Include(b => b.Member).ToListAsync();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }
            var borrowing = await _context.Borrowing.FindAsync(id);

            if (borrowing != null)
            {
                Borrowing = borrowing;
                _context.Borrowing.Remove(Borrowing);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
