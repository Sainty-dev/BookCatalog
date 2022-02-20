using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Models.Repository
{
    public class inMemBookRepo : IBook
    {
        private List<Book> _books;

        public inMemBookRepo()
        {
            _books = new() { new Book { Id = Guid.NewGuid(), Title = "Book 0", Price = 12 } };
        }

        public void CreateBook(Book book)
        {
            _books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            _books.Remove(book);
        }

        public Book GetBook(Guid id)
        {
            var book = _books.Where(x => x.Id == id).SingleOrDefault();
            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }

        public void UpdateBook(Guid id, Book book)
        {
            var bookindex = _books.FindIndex(x => x.Id == id);
            if (bookindex > -1)
                _books[bookindex] = book;
        }
    }
}
