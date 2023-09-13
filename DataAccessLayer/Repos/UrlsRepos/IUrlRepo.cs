using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.UrlsRepos
{
    public interface IUrlRepo: IGenericRepository<Url>
    {
        Task<Url> GetFullUrlInfo(int id);
        Task<Url> GetUrlByBaseUrl(string baseUrl);

        Task<List<Url>> GetUrslByUserId(int userId);
        Task<Url> GetUrlBySlug(string slug);
    }
}
