using ClassLibrary.Request;
using LibraryProject.Data.Models;

namespace LibraryProject.Interfaces.Service
{
    public interface IBorrowService
    {
        Task<bool> BorrowBook(BorrowRequest borrow);
        Task<bool> ReturnBook(BorrowRequest borrow);
        Task<List<BorrowedBook>> SelectAllForUser(string userId);
    }
}
