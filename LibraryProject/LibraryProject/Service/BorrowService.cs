using ClassLibrary.Request;
using LibraryProject.Data.Models;
using LibraryProject.Interfaces.Repository;
using LibraryProject.Interfaces.Service;
using LibraryProject.Repository;

namespace LibraryProject.Service
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IBookRepository _bookRepository;

        public BorrowService(IBorrowRepository borrowRepository, IBookRepository bookRepository)
        {
            _borrowRepository = borrowRepository;
            _bookRepository = bookRepository;
        }


        public async Task<bool> BorrowBook(BorrowRequest borrow)
        {
            try
            {
                var book = await _bookRepository.SelectById(borrow.BId);

                if (book == null)
                {
                    return false;
                }

                book.Stock -= 1;

                await _bookRepository.Update(book.BId, book);

                var response = await _borrowRepository.BorrowBook(new BorrowedBook()
                {
                    BId = borrow.BId,
                    UId = borrow.UId
                });

                if (response)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ReturnBook(BorrowRequest borrow)
        {
            try
            {
                var book = await _bookRepository.SelectById(borrow.BId);

                if (book == null)
                {
                    return false;
                }

                book.Stock += 1;

                await _bookRepository.Update(book.BId, book);

                var response = await _borrowRepository.ReturnBook(new BorrowedBook()
                {
                    BId = borrow.BId,
                    UId = borrow.UId
                });

                if (response)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<List<BorrowedBook>> SelectAllForUser(string userId)
        {
            try
            {
                return _borrowRepository.SelectAllForUser(userId);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
