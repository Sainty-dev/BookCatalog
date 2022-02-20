using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Models.Repository
{
    public interface IBook
    {
        public IEnumerable<Book> GetBooks();
        public Book GetBook(Guid id);

        public void CreateBook(Book book);

        public void DeleteBook(Book book);

        public void UpdateBook(Guid id, Book book);


    }
}
