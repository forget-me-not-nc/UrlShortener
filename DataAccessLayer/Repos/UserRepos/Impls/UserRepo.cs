using DataAccessLayer.DbSettings;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.UserRepos.Impls
{
    public class UserRepo : GenericRepository<User>, IUserRepo
    {
        public UserRepo(UrlShortenerDbContext context) : base(context) {}

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> GetUserWithRoles(int id)
        {
            return await _context.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
