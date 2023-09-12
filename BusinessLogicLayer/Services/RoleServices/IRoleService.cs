using BusinessLogicLayer.DTOs.RolesDTOs;
using BusinessLogicLayer.DTOs.UrlDTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.RoleServices
{
    public interface IRoleService
    {
        Task<List<Role>> GetRolesByNames(List<string> names);
    }
}
