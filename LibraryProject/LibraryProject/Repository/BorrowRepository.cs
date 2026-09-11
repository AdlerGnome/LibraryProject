using ClassLibrary.Request;
using LibraryProject.Data;
using LibraryProject.Data.Models;
using LibraryProject.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Repository
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly ApplicationDbContext _context;

        public BorrowRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> BorrowBook(BorrowedBook borrow)
        {
            try
            {
                _context.BorrowedBook.Add(borrow);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ReturnBook(BorrowedBook borrow)
        {
            try
            {
                var book = await _context.BorrowedBook.FirstOrDefaultAsync(b => b.UId == borrow.UId && b.BId == borrow.BId);
                _context.BorrowedBook.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<BorrowedBook>> SelectAllForUser(string userName)
        {
            try
            {
                return await _context.BorrowedBook
                    .Where(b => b.UId == userName)
                    .ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
