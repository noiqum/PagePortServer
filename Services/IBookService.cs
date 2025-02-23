using PagePortServer.Models;

namespace PagePortServer.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBook(int id);
        Book AddBook(Book book);
        Book UpdateBook(int id, Book book);
        bool DeleteBook(int id);


    }

    public class BookService : IBookService
    {
        private static List<Book> _books = new List<Book>();

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBook(int id)
        {
            return _books[id];
        }

        public Book AddBook(Book book)
        {
            _books.Add(book);
            return book;
        }

        public Book UpdateBook(int id, Book book)
        {
            var existingBook = _books[id];
            if (existingBook != null)
            {
                return null;
            }
            existingBook = book;
            return existingBook;
        }

        public bool DeleteBook(int id)
        {
            var existingBook = _books[id];
            if (existingBook != null)
            {
                return false;
            }
            if (existingBook != null)
            {
                _books.Remove(existingBook);
                return true;
            }
            return false;
        }
    }
}