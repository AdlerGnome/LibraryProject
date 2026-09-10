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
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly ApplicationDbContext _context;
    public AuthorsController(ApplicationDbContext context, IAuthorService authorService)
    {
        _context = context;
        _authorService = authorService;
    }

    // GET: api/Author
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Author>>> GetAuthor()
    {
        try
        {
            var response = await _authorService.SelectAll();
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

    // GET: api/Author/5
    [HttpGet("{Id}")]
    public async Task<ActionResult<AuthorResponse>> GetAuthor(int Id)
    {
        try
        {
            var response = await _authorService.SelectById(Id);

            if (response == null)
                return NotFound();
            return Ok(response);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    // PUT: api/Author/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{Id}")]
    public async Task<IActionResult> PutAuthor(int Id, AuthorRequest author)
    {
        try
        {
            var response = await _authorService.Update(Id, author);

            if (response == null)
                return NotFound();
            return Ok(response);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    // POST: api/Author
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<AuthorResponse>> PostAuthor(AuthorRequest author)
    {
        try
        {
            var response = await _authorService.Insert(author);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    // DELETE: api/Author/5
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAuthor(int Id)
    {
        try
        {
            var response = await _authorService.Delete(Id);

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
