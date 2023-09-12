using BusinessLogicLayer.DTOs.RolesDTOs;
using BusinessLogicLayer.DTOs.UrlDTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Repos.RoleRepos;
using DataAccessLayer.Repos.UrlsRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.RoleServices.Impls
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _roleRepo;

        public RoleService(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public async Task<List<Role>> GetRolesByNames(List<string> names)
        {
            return await _roleRepo.GetRolesByNames(names);
        }
    }
}
