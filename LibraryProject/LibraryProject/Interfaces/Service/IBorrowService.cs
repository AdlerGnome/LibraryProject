using ClassLibrary.Request;
using ClassLibrary.Response;
using LibraryProject.Data.Models;

namespace LibraryProject.Interfaces.Service
{
    public interface IBorrowService
    {
        Task<bool> BorrowBook(BorrowRequest borrow);
        Task<bool> ReturnBook(BorrowRequest borrow);
        Task<List<BookResponse>> SelectAllForUser(string userId);
    }
}
