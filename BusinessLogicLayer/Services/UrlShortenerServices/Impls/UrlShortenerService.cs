using BusinessLogicLayer.Config.UrlShortener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.UrlShortenerServices.Impls
{
    public class UrlShortenerService : IUrlShortenerService
    {

        public string CreateShortUrl()
        {
            Random random = new();
            StringBuilder shortUrlBuilder = new();

            for (int i = 0; i < UrlShortenerConfig.NUM_CHARS_SHORT_LINK; i++)
            {
                char randomChar = UrlShortenerConfig.ALPHABET[random.Next(UrlShortenerConfig.ALPHABET.Length)];
                shortUrlBuilder.Append(randomChar);
            }

            return shortUrlBuilder.ToString();
        }
    }
}
