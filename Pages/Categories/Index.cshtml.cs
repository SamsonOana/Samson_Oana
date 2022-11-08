using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Samson_Oana.Data;
using Samson_Oana.Models;
using Samson_Oana.Models.ViewModels;

namespace Samson_Oana.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Samson_Oana.Data.Samson_OanaContext _context;

        public IndexModel(Samson_Oana.Data.Samson_OanaContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public CategorieIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategorieIndexData();
            CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories)
            .ThenInclude(c => c.Book)
            .ThenInclude(c => c.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.BookCategories = category.BookCategories;
            }
        }
    }

           
 }
