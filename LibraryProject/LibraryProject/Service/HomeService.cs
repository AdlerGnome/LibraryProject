using ClassLibrary.Response;
using LibraryProject.Interfaces.Repository;
using LibraryProject.Interfaces.Service;

namespace LibraryProject.Service
{
    public class HomeService : IHomeService
    {
        private readonly IBookRepository _bookRepository;
        public HomeService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<List<BookResponse>> GetBooks()
        {
            List<BookResponse> books = [];

            var allBooks = await _bookRepository.SelectAll();

            Random rand = new();

            for (int i = 0; i < 3; i++)
            {
                {
                    int random = rand.Next(allBooks.Count);

                    var book = await _bookRepository.SelectById(allBooks[i].BId);

                    books.Add(BookService.MapBookToResponse(book));
                }
            }

            return books;
        }
    }
}
