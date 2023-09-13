using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.RedirectServices;
using BusinessLogicLayer.Services.UrlServices;
using BusinessLogicLayer.Services.UrlShortenerServices;
using BusinessLogicLayer.Services.UserServices.Impls;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("")]
    public class RedirectController: ControllerBase
    {
        private readonly IRedirectService _redirectService;

        public RedirectController(IRedirectService redirectService)
        {
            _redirectService = redirectService;
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> RedirectBySlug(string slug)
        {
            var url = await _redirectService.ProccessSlugUrl(slug);

            if (url != null)
            {
                return Redirect(url);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
