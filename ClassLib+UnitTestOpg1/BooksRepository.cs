using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib_UnitTestOpg1
{
    public class BooksRepository
    {
        private int _nextId = 1;
        private List<Book> _books = new List<Book>();

        public BooksRepository()
        {

        }

        public IEnumerable<Book> Get(string? sortBy = null, int? priceUnder = null, int? priceOver = null, string? titleHas = null)
        {
            IEnumerable<Book> result = new List<Book>(_books);


            if (priceOver != null)
            {
                result = result.Where(book => book.Price > priceOver);
            }

            if (priceUnder != null)
            {
                result = result.Where(book => book.Price < priceUnder);
            }


            if (sortBy != null)
            {


                sortBy = sortBy.ToLower();
                switch (sortBy)
                {
                    case "title":
                    case "title_asc":
                        result = result.OrderBy(book => book.Title);
                        break;
                    case "title_desc":
                        result = result.OrderByDescending(book => book.Title);
                        break;
                    case "price":
                    case "price_asc":
                        result = result.OrderBy(book => book.Price);
                        break;
                    case "price_desc":
                        result = result.OrderByDescending(book => book.Price);
                        break;
                    default:
                        break;

                }

            }
            return result;
        }
        public Book? GetById(int id )
        {
            return _books.Find(book => book.Id == id);
        }

        public Book Add(Book book)
        {

            book.Validate();
            book.Id = _nextId++;
            _books.Add(book);
            return book;

        }

        public Book? Delete(int id)
        {
            Book book = GetById(id);
            if (book == null) 
            {
                return null;
            }
            _books.Remove(book);
            return book;
        }

        public Book? Update(int id,  Book book)
        {

            book.Validate();
            Book? currentBook = GetById(id);
            if (currentBook == null)
            {

                return null;

            }
            currentBook.Id = book.Id;
            currentBook.Title = book.Title;
            currentBook.Price = book.Price;
            return currentBook;

            

        }
    }
}
