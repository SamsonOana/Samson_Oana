using Samson_Oana.Models;

namespace Samson_Oana.Models.ViewModels
{
    public class CategorieIndexData
    {
        public IEnumerable <Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<BookCategory> BookCategories { get; set; }

    }
}
