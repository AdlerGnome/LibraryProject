using ClassLibrary.Response;
using LibraryProject.Data;
using LibraryProject.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResponse>>> GetBooks()
        {
            try
            {
                var response = await _homeService.GetBooks();
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
    }
}
