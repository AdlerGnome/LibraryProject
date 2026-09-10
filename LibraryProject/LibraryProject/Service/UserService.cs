using ClassLibrary.Request;
using LibraryProject.Data;
using LibraryProject.Interfaces.Repository;
using LibraryProject.Interfaces.Service;

namespace LibraryProject.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> Delete(string id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<ApplicationUser> Insert(ApplicationUserRequest newUser)
        {
            ApplicationUser user=MapRequestToApplicationUser(newUser);
            return await _userRepository.Insert(user,newUser.Password,newUser.SelectRole);
        }

        public async Task<List<ApplicationUser>> SelectAll()
        {
            return await _userRepository.SelectAll();
        }

        public async Task<ApplicationUser> SelectById(string id)
        {
            return await _userRepository.SelectById(id);
        }

        public async Task<ApplicationUser> Update(string id, ApplicationUserRequest updatedUser)
        {
            ApplicationUser user = MapRequestToApplicationUser(updatedUser);
            return await _userRepository.Update(id, user);
        }

        private ApplicationUser MapRequestToApplicationUser(ApplicationUserRequest user)
        {
            var response = new ApplicationUser()
            {
                UserName=user.Email,
                Email = user.Email,
                EmailConfirmed=true
            };
            return response;
        }
    }
}
