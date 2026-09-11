using ClassLibrary.Response;

namespace LibraryProject.Interfaces.Service
{
    public interface IHomeService
    {
        Task<List<BookResponse>> GetBooks();
    }
}
