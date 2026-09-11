using LibraryProject.Data;
using LibraryProject.Data.Models;

namespace LibraryProject.Interfaces.Repository
{
    public interface IUserRepository
    {        
        Task<ApplicationUser> Delete(string id);
        Task<ApplicationUser> Insert(ApplicationUser newUser,string password,string role);
        Task<ApplicationUser> SelectById(string id);
        Task<ApplicationUser> SelectByUserName(string username);
        Task<List<ApplicationUser>> SelectAll();
        Task<ApplicationUser> Update(string id, ApplicationUser user);
        
    }
}
