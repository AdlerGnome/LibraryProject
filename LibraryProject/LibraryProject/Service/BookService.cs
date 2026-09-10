using ClassLibrary.Request;
using ClassLibrary.Response;
using LibraryProject.Data.Models;
using LibraryProject.Interfaces.Repository;
using LibraryProject.Interfaces.Service;

namespace LibraryProject.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookResponse> Delete(int id)
        {
            var deletedBook = await _bookRepository.Delete(id);

            if (deletedBook != null)
                return MapBookToResponse(deletedBook);

            return null;
        }

        public async Task<BookResponse> Insert(BookRequest newBook)
        {
            var book = MapRequestToBook(newBook);

            if (book == null)
                return null;

            var insertedBook = await _bookRepository.Insert(book);

            if (insertedBook == null)
                return null;

            return MapBookToResponse(insertedBook);
        }

        public async Task<List<BookResponse>> SelectAll()
        {
            var books = await _bookRepository.SelectAll();
            return books.Select(book => MapBookToResponse(book)).ToList();
        }

        public async Task<BookResponse> SelectById(int id)
        {
            var book = await _bookRepository.SelectById(id);

            return MapBookToResponse(book);
        }

        public async Task<BookResponse> Update(int id, BookRequest bookRequest)
        {
            var book = MapRequestToBook(bookRequest);

            var updatedBook = await _bookRepository.Update(id, book);

            if (updatedBook == null)
                return null;

            return MapBookToResponse(updatedBook);
        }

        private Book MapRequestToBook(BookRequest bookRequest)
        {
            try
            {
                return new Book()
                {
                    Title = bookRequest.Title,
                    Pagecount = bookRequest.Pagecount,
                    PublishYear = bookRequest.PublishYear,
                    Stock = bookRequest.Stock,
                    AId = bookRequest.AId,
                    PId = bookRequest.PId,
                    Edition = bookRequest.Edition,
                    Description = bookRequest.Description,
                };

            }
            catch (Exception)
            {
                return null;
            }
        }

        private BookResponse MapBookToResponse(Book book)
        {
            try
            {
                var response = new BookResponse()
                {
                    Id = book.BId,
                    Title = book.Title,
                    PublishYear = book.PublishYear,
                    Pagecount = book.Pagecount,
                    Edition = book.Edition,
                    Stock = book.Stock,
                    Description = book.Description,
                    //publisher
                    Author = new BookAuthorResponse()
                    {
                        Id = book.Author.AId,
                        FirstName = book.Author.FirstName,
                        LastName = book.Author.LastName,
                        Birthyear = book.Author.Birthyear,
                        Deathyear = book.Author.Deathyear
                    }

                };

                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
