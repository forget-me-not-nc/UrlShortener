using BusinessLogicLayer.DTOs.UserDTOs;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.UserServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllAsync();
        Task<UserResponse> GetAsync(int id);
        Task<User> GetUserAsync(int id);
        Task<User> GetUserWithRoleAsync(int id);
        Task<User> GetUserByUsernameAsync(string id);
        Task<UserResponse> UpdateAsync(UserUpdateRequest entity);
        Task<UserResponse> CreateAsync(UserCreateRequest entity);
        Task DeleteAsync(int id);
    }
}
