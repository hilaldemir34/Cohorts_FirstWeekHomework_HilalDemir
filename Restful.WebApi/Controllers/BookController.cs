using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restful.WebApi.DAL.Entities;

namespace Restful.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public List<Book> books;

        public BookController()
        {
            books = new();

            books.Add(new Book { ID = 1, Category = "Roman", Name = "Nar Ağacı", Page = 250, Price = 100 });
            books.Add(new Book { ID = 2, Category = "Roman", Name = "Kar", Page = 444, Price = 200 });
            books.Add(new Book { ID = 3, Category = "Hikaye", Name = "Beyhude Ömrüm", Page = 125, Price = 100 });
            books.Add(new Book { ID = 4, Category = "Hikaye", Name = "Mavi Kuş", Page = 145, Price = 100 });
            books.Add(new Book { ID = 5, Category = "Roman", Name = "İsimle Ateş Arasında", Page = 346, Price = 200 });
            books.Add(new Book { ID = 6, Category = "Roman", Name = "Beyaz Diş", Page = 347, Price = 100 });

            
        }
        [HttpGet]
        public IActionResult BookList()
        {
            if (books == null)
            {
                return NotFound(); 
            }

            return Ok(books); 
        }
        [HttpGet("{id}")]
        public IActionResult GetProductByID(int id)
        {
            var book = books.Find(x => x.ID == id); 

            if (book == null)
            {
                return NotFound(); 
            }

            return Ok(book); 
        }
        [HttpPost]//yeni kitap ekleme
        public IActionResult AddBook([FromBody] Book book)
        {
            book.ID = books.Count() + 1;

            books.Add(book);

            return Created("", book);
        }
        [HttpPut("{id}")]//Güncelleme
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            var bookUpdate = books.FirstOrDefault(x => x.ID == id);

            if (bookUpdate == null)
            {
                return NotFound(); 
            }

            books.Remove(bookUpdate);
            bookUpdate.ID = id;
            books.Add(book);

            return Ok(books); 
        }

        [HttpPatch("{id}")] 
        public IActionResult PatchBook(int id, [FromBody] Book book)
        {
            var patchBook = books.FirstOrDefault(x => x.ID == id);

            if (patchBook == null)
            {
                return NotFound(); // 404 Not Found yanıtı
            }

            patchBook.Name = book.Name ?? patchBook.Name;
            patchBook.Category = book.Category ?? patchBook.Category;

            return Ok(books);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var bookDelete = books.FirstOrDefault(x => x.ID == id);

            if (bookDelete == null)
            {
                return NotFound(); 
            }

            books.Remove(bookDelete);

            return Ok(books); 
        }
        [HttpGet("list")]
        public IActionResult GetBooksByName(string name)
        {
            var filterBook = books.Where(p => p.Name.Contains(name)).ToList(); 
            return Ok(filterBook);
        }
        [HttpGet("sort")]
        public IActionResult SortBooks(string sortBy, string sortDirection)
        {
            IQueryable<Book> sortedBooks;

            switch (sortBy)
            {
                case "name":
                    sortedBooks = sortDirection == "desc" ? books.OrderByDescending(p => p.Name).AsQueryable() : books.OrderBy(p => p.Name).AsQueryable();
                    break; 
                case "price":
                    sortedBooks = sortDirection == "desc" ? books.OrderByDescending(p => p.Price).AsQueryable() : books.OrderBy(p => p.Price).AsQueryable();
                    break; 
                default:
                    sortedBooks = books.AsQueryable();
                    break;
            }

            return Ok(sortedBooks.ToList()); 
        }

    }
}
