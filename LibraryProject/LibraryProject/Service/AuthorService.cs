using ClassLibrary.Request;
using ClassLibrary.Response;
using LibraryProject.Data.Models;
using LibraryProject.Interfaces.Repository;
using LibraryProject.Interfaces.Service;
using LibraryProject.Repository;

namespace LibraryProject.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

        }

        public async Task<AuthorResponse> Delete(int id)
        {
            var deletedAuthor = await _authorRepository.Delete(id);

            if (deletedAuthor != null)
                return MapAuthorToResponse(deletedAuthor);

            return null;
        }

        public async Task<AuthorResponse> Insert(AuthorRequest newAuthor)
        {
            var author = MapRequestToAuthor(newAuthor);

            if (author == null)
                return null;

            var insertedAuthor = await _authorRepository.Insert(author);

            if (insertedAuthor == null)
                return null;

            return MapAuthorToResponse(insertedAuthor);
        }

        public async Task<List<AuthorResponse>> SelectAll()
        {
            List<Author> authors = await _authorRepository.SelectAll();
            return authors.Select(author => MapAuthorToResponse(author)).ToList();
        }

        public async Task<AuthorResponse> SelectById(int id)
        {
            var author = await _authorRepository.SelectById(id);

            return MapAuthorToResponse(author);
        }

        public async Task<AuthorResponse> Update(int id, AuthorRequest authorRequest)
        {
            var author = MapRequestToAuthor(authorRequest);

            var updatedAuthor = await _authorRepository.Update(id, author);

            if (updatedAuthor == null)
                return null;

            return MapAuthorToResponse(updatedAuthor);
        }

        private Author MapRequestToAuthor(AuthorRequest authorRequest)
        {
            try
            {
                return new Author()
                {
                    FirstName = authorRequest.FirstName,
                    LastName = authorRequest.LastName,
                    Birthyear = authorRequest.Birthyear,
                    Deathyear = authorRequest.Deathyear,
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        private AuthorResponse? MapAuthorToResponse(Author author)
        {
            try
            {
                var response = new AuthorResponse()
                {
                    Id = author.AId,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Birthyear = author.Birthyear,
                    Deathyear = author.Deathyear
                };

                foreach (var book in author.Books)
                {
                    response.Books.Add(
                        new AuthorBookResponse()
                        {
                            Id = book.BId,
                            Title = book.Title,
                            Stock = book.Stock,
                            Pagecount = book.Pagecount,
                            Edition = book.Edition,
                            PublishYear = book.PublishYear
                        }
                    );
                }
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
