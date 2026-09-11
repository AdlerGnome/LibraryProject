using ClassLibrary.Response;
using LibraryProject.Data.Models;

namespace LibraryProject.Interfaces.Repository
{
    public interface IBookRepository
    {
        Task<Book> Delete(int id);
        Task<Book> Insert(Book newBook);
        Task<Book> SelectById(int id);
        Task<List<Book>> SelectAll();
        Task<Book> Update(int id, Book book);
    }
}
