using LibraryProject.Data.Models;

namespace LibraryProject.Interfaces.Repository
{
    public interface IAuthorRepository
    {
        Task<Author> Delete(int id);
        Task<Author> Insert(Author newAuthor);
        Task<Author> SelectById(int id);
        Task<List<Author>> SelectAll();
        Task<Author> Update(int id, Author author);
    }
}
