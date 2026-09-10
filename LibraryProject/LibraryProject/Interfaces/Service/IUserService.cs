using ClassLibrary.Request;
using ClassLibrary.Response;
using LibraryProject.Data;

namespace LibraryProject.Interfaces.Service
{
    public interface IUserService
    {
        Task<ApplicationUser> Delete(string id);
        Task<ApplicationUser> Insert(ApplicationUserRequest newUser);
        Task<ApplicationUser> SelectById(string id);
        Task<List<ApplicationUser>> SelectAll();
        Task<ApplicationUser> Update(string id, ApplicationUserRequest user);
    }
}
