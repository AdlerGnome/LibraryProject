using Azure.Core;
using ClassLibrary.Request;
using ClassLibrary.Response;
using LibraryProject.Data;
using LibraryProject.Data.Models;
using LibraryProject.Interfaces.Service;
using LibraryProject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : Controller
    {
        private readonly IBorrowService _borrowService;

        public BorrowController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }
        
        [HttpPost]
        public async Task<ActionResult<bool>> PostBorrow(BorrowRequest borrow)
        {
            try
            {
                var response = await _borrowService.BorrowBook(borrow);

                if (response == false)
                    return BadRequest();

                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // Put: api/Book/5
        
        [HttpPut("{bid}")]//Technically shoudl be delete, but we need two Id's and this is easier
        public async Task<IActionResult> PutBorrow(BorrowRequest borrow)
        {
            try
            {
                var response = await _borrowService.ReturnBook(borrow);

                if (response == false)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("{Username}")]
        public async Task<ActionResult<IEnumerable<BookResponse>>> GetUserBorrows(string Username)
        {
            try
            {
                var response = await _borrowService.SelectAllForUser(Username);
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
