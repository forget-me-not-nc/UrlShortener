using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.UrlShortenerServices
{
    public interface IUrlShortenerService
    {
        public string Reduce(int aliasId);
        public string EncodeAliasId(int aliasId);
        public int DecodeAliasId(string reducedUrl);

    }
}
