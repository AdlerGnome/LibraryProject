using ClassLibrary.Request;
using ClassLibrary.Response;
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
        private readonly IUserRepository _userRepository;

        public BorrowService(IBorrowRepository borrowRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _borrowRepository = borrowRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
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

                var user=await _userRepository.SelectByUserName(borrow.Username);

                var response = await _borrowRepository.BorrowBook(new BorrowedBook()
                {
                    BId = borrow.BId,
                    UId = borrow.Username
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
                    UId = borrow.Username
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

        public async Task<List<BookResponse>> SelectAllForUser(string userName)
        {
            try
            {
                var borrows = await _borrowRepository.SelectAllForUser(userName);

                List<Book> books = [];

                foreach (var borrow in borrows)
                {
                    books.Add(await _bookRepository.SelectById(borrow.BId));
                }
                return books.Select(book => BookService.MapBookToResponse(book)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
