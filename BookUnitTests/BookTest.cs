using ClassLib_UnitTestOpg1;

namespace BookUnitTests
{
    [TestClass]
    public class BookTest
    {
        private Book _book = new Book() { Id = 1, Title = "Book of Shadows", Price = 59.99 };
        private Book _nullTitleBook = new Book() { Id = 2, Title = null, Price = 25 };
        private Book _tooShortTitleBook = new Book() { Id = 3, Title = "hi", Price = 40 };
        private Book _0priceBook = new Book() { Id = 4, Title = "Free Book", Price = 0 };
        private Book _priceTooHigh = new Book() { Id = 5, Title = "Death Note", Price= 2000 };
        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("1 Book of Shadows 59,99", _book.ToString());
        }

        [TestMethod]
        public void ValidateTitleTest()
        {
            _book.ValidateTitle();
            Assert.ThrowsException<ArgumentNullException> (() => _nullTitleBook.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => _tooShortTitleBook.ValidateTitle());
        }
        [TestMethod]
        public void ValidatePriceTest()
        {
            _book.ValidatePrice();
            Assert.ThrowsException<ArgumentOutOfRangeException> (() => _0priceBook.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException> (() => _priceTooHigh.ValidatePrice());
        }
        [TestMethod]
        public void ValidateTests()
        {
            _book.Validate();
        }

    }
}