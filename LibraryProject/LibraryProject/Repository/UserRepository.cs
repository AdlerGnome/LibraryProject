using LibraryProject.Data;
using LibraryProject.Data.Models;
using LibraryProject.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> Delete(string id)
        {
            try
            {
                var deletedUser = await _context.Users
                    .FirstOrDefaultAsync(user => user.Id == id);
                if (deletedUser == null)
                    return null;

                await _userManager.DeleteAsync(deletedUser);
                //_context.Users.Remove(deletedUser);
                //await _context.SaveChangesAsync();
                return deletedUser;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ApplicationUser> Insert(ApplicationUser newUser, string password, string role)
        {
            try
            {
                
                await _userManager.CreateAsync(newUser, password);
                await _userManager.AddToRoleAsync(newUser, role);
                //_context.Users.Add(newUser);
                //await _context.SaveChangesAsync();
                return newUser;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<ApplicationUser>> SelectAll()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ApplicationUser> SelectById(string id)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ApplicationUser> SelectByUserName(string username)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(user => user.UserName == username);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ApplicationUser> Update(string id, ApplicationUser user)
        {
            try
            {
                var updatedUser = await _context.Users
                    .FirstOrDefaultAsync(user => user.Id == id);
                if (updatedUser == null)
                    return null;

                _context.Users.Update(updatedUser);

                await _context.SaveChangesAsync();
                return updatedUser;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
