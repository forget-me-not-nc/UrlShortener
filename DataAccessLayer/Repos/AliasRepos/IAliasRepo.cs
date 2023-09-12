using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.AliasRepos
{
    public interface IAliasRepo: IGenericRepository<Alias>
    {
        Task<Alias> GetAliasByAliasSlug(string aliasSlug);
    }
}
