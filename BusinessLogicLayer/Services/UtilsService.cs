using BusinessLogicLayer.Services.AliasServices;
using BusinessLogicLayer.Services.UrlServices;
using BusinessLogicLayer.Services.UrlShortenerServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UtilsService: IUtilsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UtilsService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserIdFromClaims()
        {
            var id = _httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(c => c.Properties.Any(p => p.Value == "sub"))
                .Value;

            return Convert.ToInt32(id);
        }
    }
}
