using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBL_Opgave;

namespace RestApiBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private static List<Book> books = new List<Book>()
 {
 new Book("Book1", "Mr.Book1",11,"a123456789110"),
 new Book("Book2", "Mr.Book2",12,"a123456789111"),
 new Book("Book3", "Mr.Book3",13,"a123456789112"),

 };
        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public Book Get(string isbn)
        {
            return books.Find(i => i.ISBN13 == isbn);
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            books.Add(value);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public void Put(string isbn, [FromBody] Book value)
        {
            Book book = Get(isbn);
            if (book != null)
            {
                book.Titel = value.Titel;
                book.Forfatter = value.Forfatter;
                book.Sidetal = value.Sidetal;
                book.ISBN13 = value.ISBN13;
            }
        }
    

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string isbn)
        {
            Book book = Get(isbn);
            books.Remove(book);
        }
    }
}
