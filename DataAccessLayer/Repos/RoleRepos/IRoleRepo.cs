using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.RoleRepos
{
    public interface IRoleRepo: IGenericRepository<Role>
    {
        Task<List<Role>> GetRolesByNames(List<string> names);
    }
}
