using Restful.WebApi.DAL.Entities;

namespace Restful.WebApi.Models
{
    public class BookList
    {
        public List<Book> Books { get; set; }

        public BookList()
        {
            Books = new List<Book>
            {
               new Book { ID = 1, Category = "Roman", Name = "Nar Ağacı",Page  = 250, Price = 100 },
               new Book { ID = 2, Category = "Roman", Name = "Kar", Page = 444, Price = 200 },
               new Book { ID = 3, Category = "Hikaye", Name = "Beyhude Ömrüm", Page = 125, Price = 100 },
               new Book { ID = 4, Category = "Hikaye", Name = "Mavi Kuş", Page = 145, Price = 100 },
               new Book { ID = 5, Category = "Roman", Name = "İsimle Ateş Arasında", Page = 346, Price = 200 },
               new Book { ID = 6, Category = "Roman", Name = "Beyaz Diş", Page = 347, Price = 100 }

            };
        }
    }
}
