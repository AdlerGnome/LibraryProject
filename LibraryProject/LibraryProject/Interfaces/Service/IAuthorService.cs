using ClassLibrary.Request;
using ClassLibrary.Response;
using LibraryProject.Data.Models;


namespace LibraryProject.Interfaces.Service
{
    public interface IAuthorService
    {
        Task<AuthorResponse> Delete(int id);
        Task<AuthorResponse> Insert(AuthorRequest newAuthor);
        Task<AuthorResponse> SelectById(int id);
        Task<List<AuthorResponse>> SelectAll();
        Task<AuthorResponse> Update(int id, AuthorRequest author);
    }
}
