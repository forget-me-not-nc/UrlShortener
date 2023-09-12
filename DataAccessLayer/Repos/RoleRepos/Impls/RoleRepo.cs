using DataAccessLayer.DbSettings;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.RoleRepos.Impls
{
    public class RoleRepo : GenericRepository<Role>, IRoleRepo
    {
        public RoleRepo(UrlShortenerDbContext context) : base(context)
        {
        }

        public async Task<List<Role>> GetRolesByNames(List<string> names)
        {
            var allRoles = await _context.Roles.ToListAsync();

            var filteredRoles = allRoles.Where(role => names.Contains(role.Name.ToString())).ToList();

            return filteredRoles;
        }
    }
}
