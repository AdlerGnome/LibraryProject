using Azure;
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
    public class UsersController : Controller
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {     
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            try
            {
                var response = await _userService.SelectAll();
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

        [HttpGet("{Id}")]
        public async Task<ActionResult<ApplicationUser>> GetAuthor(string Id)
        {
            try
            {
                var response = await _userService.SelectById(Id);

                if (response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutUser(string Id, ApplicationUserRequest user)
        {
            try
            {
                var response = await _userService.Update(Id, user);

                if (response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult>CreateUser(ApplicationUserRequest newUser)
        {
            try
            {
                var response = await _userService.Insert(newUser);
                if (response == null)
                {
                    return BadRequest();
                }
                
                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            try
            {
                var response = await _userService.Delete(Id);

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
}
