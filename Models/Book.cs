using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Security.Policy;

namespace Samson_Oana.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Display(Name = "Book Title")]

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = 
            "Titlul trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]
        
        [StringLength(150, MinimumLength = 3)]


        public string Title { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]

        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int? AuthorID { get; set; }
        public Author? Author { get; set; }

        public int? PublisherID { get; set; }

        public Publisher? Publisher { get; set; }

        public Borrowing? Borrowing { get; set; }

        public ICollection<BookCategory>? BookCategories { get; set; }

        //public int? CategoryID { get; set; }
    }


}
