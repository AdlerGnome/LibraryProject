using LibraryProject.Data;
using LibraryProject.Data.Models;
using LibraryProject.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace LibraryProject.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> Delete(int id)
        {
            try
            {
                var deletedBook = await _context.Book.FirstOrDefaultAsync(book => book.BId == id);
                if (deletedBook == null)
                {
                    return null;
                }

                _context.Book.Remove(deletedBook);
                await _context.SaveChangesAsync();
                return deletedBook;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Book> Insert(Book newBook)
        {
            try
            {
                _context.Book.Add(newBook);
                await _context.SaveChangesAsync();
                return newBook;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Book>> SelectAll()
        {
            try
            {
                return await _context.Book
                    .Include(b => b.Author)
                    .ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Book> SelectById(int id)
        {
            try
            {
                return await _context.Book
                    .Include(b => b.Author)
                    .FirstOrDefaultAsync(book => book.BId == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Book> Update(int id, Book book)
        {
            try
            {
                var updatedBook = await _context.Book.FirstOrDefaultAsync(book => book.BId == id);
                if (updatedBook == null)
                    return null;

                updatedBook.Title = book.Title;
                updatedBook.Pagecount = book.Pagecount;
                updatedBook.Edition = book.Edition;
                updatedBook.Stock = book.Stock;
                updatedBook.PublishYear = book.PublishYear;
                updatedBook.PId = book.PId;
                updatedBook.AId = book.AId;
                //genre

                await _context.SaveChangesAsync();
                return updatedBook;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
