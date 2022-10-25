using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Samson_Oana.Data;
using Samson_Oana.Models;

namespace Samson_Oana.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Samson_Oana.Data.Samson_OanaContext _context;

        public IndexModel(Samson_Oana.Data.Samson_OanaContext context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Publisher != null)
            {
                Publisher = await _context.Publisher.ToListAsync();
            }
        }
    }
}
