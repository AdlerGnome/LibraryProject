using LibraryProject.Data;
using LibraryProject.Data.Models;
using LibraryProject.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Author> Delete(int id)
        {
            try
            {
                Author? deletedAuthor = await _context.Author
                    .Include(a => a.Books)
                    .FirstOrDefaultAsync(author => author.AId == id);
                if (deletedAuthor == null)
                {
                    return null;
                }

                _context.Author.Remove(deletedAuthor);
                await _context.SaveChangesAsync();
                return deletedAuthor;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Author> Insert(Author newAuthor)
        {
            try
            {
                _context.Author.Add(newAuthor);
                await _context.SaveChangesAsync();
                return newAuthor;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Author>> SelectAll()
        {
            try
            {
                return await _context.Author
                    .Include(a => a.Books)
                    .ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Author> SelectById(int id)
        {
            try
            {
                return await _context.Author
                    .Include(a => a.Books)
                    .FirstOrDefaultAsync(author => author.AId == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Author> Update(int id, Author author)
        {
            try
            {
                Author? updatedAuthor = await _context.Author
                    .Include(a => a.Books)
                    .FirstOrDefaultAsync(author => author.AId == id);
                if (updatedAuthor == null)
                    return null;

                updatedAuthor.FirstName = author.FirstName;
                updatedAuthor.LastName = author.LastName;
                updatedAuthor.Birthyear = author.Birthyear;
                updatedAuthor.Deathyear = author.Deathyear;
                await _context.SaveChangesAsync();
                return updatedAuthor;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
