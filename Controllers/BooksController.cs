using BookCatalog.Dtos;
using BookCatalog.Models;
using BookCatalog.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController:ControllerBase
    {
        private IBook _Ibook;

        public BooksController(IBook book)
        {
            _Ibook = book;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetBooks()
        {
            return _Ibook.GetBooks().Select(x => new BookDTO {Id = x.Id, Title =x.Title, Price = x.Price }).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<BookDTO> GetBook(Guid id)
        {
            var book = _Ibook.GetBook(id);
            if (book == null)
                return NotFound();
            var bookDto = new BookDTO { Id = book.Id, Title = book.Title, Price = book.Price };
            return bookDto;
        }


        [HttpPost]
        public ActionResult<BookDTO> CreatBook(CreateOrUpdateDto book)
        {
            var newBook = new Book();
            newBook.Price = book.Price;
            newBook.Title = book.Title;
            newBook.Id = Guid.NewGuid();

            _Ibook.CreateBook(newBook);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<BookDTO> UpdateBook(Guid id, CreateOrUpdateDto book)
        {
            var mybook = _Ibook.GetBook(id);
            if(mybook == null)
            {
                return NotFound();
            }
            mybook.Price = book.Price;
            mybook.Title = book.Title;
            mybook.Id = Guid.NewGuid();

            _Ibook.UpdateBook(id,mybook);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<BookDTO> DeleteBook(Guid id)
        {
            var mybook = _Ibook.GetBook(id);
            if (mybook == null)
            {
                return NotFound();
            }
            _Ibook.DeleteBook(mybook);
            return Ok();
        }
    }
}
