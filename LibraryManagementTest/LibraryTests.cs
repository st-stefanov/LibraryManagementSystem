using LibraryManagementSystem;

namespace LibraryManagementTest
{
    [TestFixture]
    public class LibraryTests
    {

        [Test]
        public void AddBook_ShouldAddNewBookToTheLibrary()
        {
            Library library = new Library();

            var newBook = new Book
            {
                Author = "Ivan",
                Id = 1,
                IsCheckedOut = false,
                Title = "Title"
            };

            library.AddBook(newBook);

            var allBooks = library.GetAllBooks();

            Assert.That(allBooks.Count, Is.EqualTo(1));

            var singleBook = allBooks.First();
            Assert.That(singleBook.Id, Is.EqualTo(newBook.Id));
            Assert.That(singleBook.Title, Is.EqualTo(newBook.Title));
        }

        [Test]
        public void CheckOutBook_ShouldReturnFalse_IfBookDoesNotExist()
        {
            Library library1 = new Library();

            var newBook = new Book
            {
                Author = "Ivan Ivan",
                Id = 1,
                IsCheckedOut = false,
                Title = "Title"
            };
            library1.AddBook(newBook);

            var result = library1.CheckOutBook(999);

            Assert.That(result, Is.False);
        }


        [Test]
        public void CheckOutBook_ShouldReturnFalse_IfBookIsAlreadyCheckedOut()
        {
            Library library1 = new Library();
            var newBook = new Book
            {
                Author = "John Doe",
                Id = 1,
                IsCheckedOut = true,
                Title = "Title"
            };

            var result = library1.CheckOutBook(newBook.Id);

            Assert.That(result, Is.False);
        }

        [Test]
        public void CheckOutBook_ShouldReturnTrue_IfWeCanCheckOutBook()
        {
            Library library1 = new Library();
            var newBook = new Book
            {
                Author = "John Doe",
                Id = 1,
                IsCheckedOut = false,
                Title = "Title"
            };

            library1.AddBook(newBook);

            var result = library1.CheckOutBook(newBook.Id);

            Assert.IsTrue(result);
            var allBooks = library1.GetAllBooks();
            var singleBook = allBooks.First();
            Assert.IsTrue(singleBook.IsCheckedOut);
        }


        [Test]
        public void ReturnBook_ShouldReturnFalse_IfBookDoesNotExist()
        {
            Library library = new Library();

            var result = library.ReturnBook(999);

            Assert.IsFalse(result); 
        }

        [Test]
        public void ReturnBook_ShouldReturnFalse_IfBookIsNotCheckedOut()
        {
            var library = new Library();
            var newBook = new Book
            {
                Author = "Ivan Ivan",
                Id = 1,
                IsCheckedOut = false,
                Title = "Title"
            };
            library.AddBook(newBook);

            var result = library.ReturnBook(newBook.Id);

            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnBook_ShouldReturnTrue_IfBookCanBeCheckedOut()
        {
            var library = new Library();
            var newBook = new Book
            {
                Author = "Ivan Ivan",
                Id = 1,
                IsCheckedOut = true,
                Title = "Title"
            };

            library.AddBook(newBook);

            var result = library.ReturnBook(newBook.Id);

            Assert.IsTrue(result);
        }

    }

}
