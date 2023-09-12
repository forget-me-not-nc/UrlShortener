using BusinessLogicLayer.Services.AliasServices;
using BusinessLogicLayer.Services.UrlServices;
using BusinessLogicLayer.Services.UrlShortenerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.RedirectServices.Impls
{
    public class RedirectService : IRedirectService
    {
        private readonly IUrlService _urlService;
        private readonly IUrlShortenerService _urlShortenerService;
        private readonly IAliasService _aliasService;

        public RedirectService(IUrlService urlService, IUrlShortenerService urlShortenerService, IAliasService aliasService)
        {
            _urlService = urlService;
            _urlShortenerService = urlShortenerService;
            _aliasService = aliasService;
        }

        public async Task<string> ProccessSlugUrl(string slug)
        {
            var aliasId = _urlShortenerService.DecodeAliasId(slug);

            if (await _aliasService.GetAsync(aliasId) == null)
                throw new Exception("Invalid url");

            var url = await _urlService.GetUrlBySlugAndAlias(slug, aliasId);

            return url.BaseUrl;
        }
    }
}
