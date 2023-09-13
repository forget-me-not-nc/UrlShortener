using DataAccessLayer.DbSettings;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.UrlsRepos.Impl
{
    public class UrlRepo : GenericRepository<Url>, IUrlRepo
    {
        public UrlRepo(UrlShortenerDbContext context) : base(context) {}

        public async Task<Url> GetFullUrlInfo(int id)
        {
            var res = await _context.Urls
                .Include(o => o.User)
                .FirstOrDefaultAsync(alias => alias.Id == id)
                ?? throw new Exception($"There is no url with id {id}");

            return res;
        }

        public async Task<Url> GetUrlByBaseUrl(string baseUrl)
        {
            var res = await _context.Urls
                .Include(o => o.User)
                .FirstOrDefaultAsync(alias => alias.BaseUrl == baseUrl);

            return res;
        }

        public async Task<Url> GetUrlBySlug(string slug)
        {
            var url = await _context.Urls
                    .Where(u => u.Slug == slug )
                    .Include(o => o.User)
                    .FirstOrDefaultAsync();

            return url;
        }

        public async Task<List<Url>> GetUrslByUserId(int userId)
        {
            var urls = await _context.Urls
                .Where(u => u.UserId == userId)
                .Include(o => o.User)
                .ToListAsync();

            return urls;
        }
    }
}
