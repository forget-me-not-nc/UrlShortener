using BusinessLogicLayer.DTOs.UrlDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.UrlServices
{
    public interface IUrlService
    {
        Task<IEnumerable<UrlResponse>> GetAllAsync();
        Task<UrlResponse> GetAsync(int id);
        Task<UrlResponse> UpdateAsync(UrlUpdateRequest entity);
        Task<UrlResponse> CreateAsync(UrlCreateRequest entity);
        Task DeleteAsync(int id);
        Task<UrlResponse> GetFullUrlInfo(int id);
        Task<UrlResponse> GetUrlBySlugAndAlias(string slug, int aliasId);

        Task<UrlResponse> GetUrlByBaseUrl(string baseUrl);
    }
}
