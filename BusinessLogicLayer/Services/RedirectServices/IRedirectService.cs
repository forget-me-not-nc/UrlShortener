using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.RedirectServices
{
    public interface IRedirectService
    {
        Task<string> ProccessSlugUrl(string slug);
    }
}
