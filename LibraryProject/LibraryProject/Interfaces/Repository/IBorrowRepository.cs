using ClassLibrary.Request;
using LibraryProject.Data.Models;

namespace LibraryProject.Interfaces.Repository
{
    public interface IBorrowRepository
    {
        Task<bool> BorrowBook(BorrowedBook borrow);
        Task<bool> ReturnBook(BorrowedBook borrow);
        Task<List<BorrowedBook>> SelectAllForUser(string userId);
    }
}
