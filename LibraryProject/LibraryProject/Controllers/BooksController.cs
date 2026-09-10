using Azure;
using ClassLibrary.Request;
using ClassLibrary.Response;
using LibraryProject.Data;
using LibraryProject.Data.Models;
using LibraryProject.Interfaces.Service;
using LibraryProject.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly ApplicationDbContext _context;
    public BooksController(ApplicationDbContext context, IBookService bookService)
    {
        _context = context;
        _bookService = bookService;
    }

    // GET: api/Book
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookResponse>>> GetBook()
    {
        try
        {
            var response = await _bookService.SelectAll();
            if (response == null)
            {
                return Problem("Got no list");
            }
            if (response.Count == 0)
            {
                return NoContent();
            }
            return Ok(response);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    // GET: api/Book/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BookResponse>> GetBook(int id)
    {
        try
        {
            var response = await _bookService.SelectById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    // PUT: api/Book/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int id, BookRequest book)
    {
        try
        {
            var response = await _bookService.Update(id, book);

            if (response == null)
                return NotFound();

            return Ok(response);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    // POST: api/Book
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<BookResponse>> PostBook(BookRequest book)
    {
        try
        {
            var response = await _bookService.Insert(book);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    // DELETE: api/Book/5
    [HttpDelete("{bid}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        try
        {
            var response = await _bookService.Delete(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
}
