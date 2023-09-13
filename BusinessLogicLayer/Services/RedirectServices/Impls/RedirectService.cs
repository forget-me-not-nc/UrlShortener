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

        public RedirectService(IUrlService urlService)
        {
            _urlService = urlService;
        }

        public async Task<string> ProccessSlugUrl(string slug)
        {
            var url = await _urlService.GetUrlBySlug(slug);

            return url.BaseUrl;
        }
    }
}
