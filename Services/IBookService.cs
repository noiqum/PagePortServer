using PagePortServer.Models;

namespace PagePortServer.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBook(int id);
        Book AddBook(Book book);
        Book UpdateBook(int id,Book book);
        bool DeleteBook(int id);


    }
}
