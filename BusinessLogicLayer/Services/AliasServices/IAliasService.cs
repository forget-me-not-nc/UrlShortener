using BusinessLogicLayer.DTOs.AliasDTOs;
using BusinessLogicLayer.DTOs.UserDTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.AliasServices
{
    public interface IAliasService
    {
        Task<IEnumerable<AliasResponse>> GetAllAsync();
        Task<AliasResponse> GetAsync(int id);
        Task<AliasResponse> UpdateAsync(AliasUpdateRequest entity);
        Task<AliasResponse> CreateAsync(AliasCreateRequest entity);
        Task<AliasResponse> GetAliasByAliasSlug(string slug);
        Task DeleteAsync(int id);
    }
}
