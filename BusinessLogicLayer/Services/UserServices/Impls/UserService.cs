using AutoMapper;
using BusinessLogicLayer.DTOs.UserDTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Repos.RoleRepos;
using DataAccessLayer.Repos.UserRepos;

namespace BusinessLogicLayer.Services.UserServices.Impls
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IRoleRepo _roleRepo;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepo userRepo,
            IMapper mapper,
            IRoleRepo roleRepo)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _roleRepo = roleRepo;
        }

        public async Task<UserResponse> CreateAsync(UserCreateRequest entity)
        {
            if (await GetUserByUsernameAsync(entity.Username) != null)
                throw new Exception("Username already exists.");

            var newUser = _mapper.Map<User>(entity);
            var existingRoles = await _roleRepo.GetRolesByNames(entity.Roles);

            if (existingRoles == null || existingRoles.Count == 0)
                throw new Exception("No valid roles found for the user.");

            newUser.Roles = existingRoles;

            newUser = await _userRepo.CreateAsync(newUser);

            await _userRepo.SaveChangesAsync();

            return _mapper.Map<UserResponse>(newUser);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepo.DeleteAsync(id);

            await _userRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            return (await _userRepo.GetAllAsync())
               .Select(el => _mapper.Map<UserResponse>(el));
        }

        public async Task<UserResponse> GetAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);

            return _mapper.Map<UserResponse>(user);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _userRepo.GetByIdAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string id)
        {
            return await _userRepo.GetUserByUsername(id);
        }

        public async Task<User> GetUserWithRoleAsync(int id)
        {
            return await _userRepo.GetUserWithRoles(id);
        }

        public async Task<UserResponse> UpdateAsync(UserUpdateRequest entity)
        {
            var newUser = await _userRepo.GetUserWithRoles(entity.Id);

            var existingRoles = await _roleRepo.GetRolesByNames(entity.Roles);

            if (existingRoles == null || existingRoles.Count == 0)
                throw new Exception("No valid roles found for the user.");

            newUser.Roles.Clear();
            newUser.Roles = existingRoles;

            await _userRepo.UpdateAsync(newUser);

            await _userRepo.SaveChangesAsync();

            return _mapper.Map<UserResponse>(newUser);
        }
    }
}
