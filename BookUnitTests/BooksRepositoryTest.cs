using ClassLib_UnitTestOpg1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookUnitTests
{
    [TestClass]
    public class BooksRepositoryTest
    {
        private BooksRepository _booksRepository;


        [TestInitialize]

        public void Init()
        {
            _booksRepository = new BooksRepository();

            _booksRepository.Add(new Book { Id = 1, Title = "Book", Price = 200 });
            _booksRepository.Add(new Book { Id = 2, Title = "Hiii", Price = 300 });
            _booksRepository.Add(new Book { Id = 3, Title = "Zealot", Price = 649 });
            _booksRepository.Add(new Book { Id = 4, Title = "Vagabond", Price = 450 });
            _booksRepository.Add(new Book { Id = 5, Title = "FifthBookCauseTeacherToldMe5Objects", Price = 500 });

        }
        [TestMethod]
        public void GetTest()
        {
            IEnumerable<Book> books = _booksRepository.Get();
            Assert.AreEqual(5, books.Count());
            Assert.AreEqual("Book", books.First().Title);

            IEnumerable<Book> PriceUnderBooks = _booksRepository.Get(priceUnder: 400);
            Assert.AreEqual(2, PriceUnderBooks.Count());

            IEnumerable<Book> PriceOverBooks = _booksRepository.Get(priceOver: 400);
            Assert.AreEqual(3, PriceOverBooks.Count());

            IEnumerable<Book> sortedBooksTitleAsc = _booksRepository.Get(sortBy: "title_asc");
            Assert.AreEqual("Book", sortedBooksTitleAsc.First().Title);

            IEnumerable<Book> sortedBooksTitleDesc = _booksRepository.Get(sortBy: "title_desc");
            Assert.AreEqual("Zealot", sortedBooksTitleDesc.First().Title);

            IEnumerable<Book> sortedBooksPriceAsc = _booksRepository.Get(sortBy: "price_asc");
            Assert.AreEqual(200, sortedBooksPriceAsc.First().Price);

            IEnumerable<Book> sortedBooksPriceDesc = _booksRepository.Get(sortBy: "price_desc");
            Assert.AreEqual(649, sortedBooksPriceDesc.First().Price);
        }
        public void GetByIdTest()
        {
            Assert.IsNotNull(_booksRepository.GetById(1));
            Assert.IsNull(_booksRepository.GetById(33333333));
        }

        public void AddTest()
        {
            Book book = new Book {Title = "6thBookNowWTF", Price = 500 };
            Assert.AreEqual(6, _booksRepository.Add(book).Id);
            Assert.AreEqual(6, _booksRepository.Get().Count());
        }
    }
}
