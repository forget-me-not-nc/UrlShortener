using DataAccessLayer.DbSettings;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.AliasRepos.Impls
{
    public class AliasRepo : GenericRepository<Alias>, IAliasRepo
    {
        public AliasRepo(UrlShortenerDbContext context) : base(context)
        {
        }

        public async Task<Alias> GetAliasByAliasSlug(string aliasSlug)
        {
            var c = await _context.Aliases.SingleOrDefaultAsync(x => x.AliasSlug == aliasSlug);

            return c;
        }
    }
}
