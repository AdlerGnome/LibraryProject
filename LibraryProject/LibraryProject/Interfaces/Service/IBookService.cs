using ClassLibrary.Request;
using ClassLibrary.Response;
using LibraryProject.Data.Models;

namespace LibraryProject.Interfaces.Service
{
    public interface IBookService
    {        
        Task<BookResponse> Delete(int id);
        Task<BookResponse> Insert(BookRequest newBook);
        Task<BookResponse> SelectById(int id);
        Task<List<BookResponse>> SelectAll();
        Task<BookResponse> Update(int id, BookRequest book);
    }
}
