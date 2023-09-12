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

        public string Reduce(int aliasId)
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

        public string EncodeAliasId(int aliasId)
        {
            if (aliasId < 0 || aliasId >= UrlShortenerConfig.ALPHABET.Length * UrlShortenerConfig.ALPHABET.Length)
                throw new ArgumentOutOfRangeException(nameof(aliasId), "AliasId is out of range.");

            int index1 = aliasId / UrlShortenerConfig.ALPHABET.Length;
            int index2 = aliasId % UrlShortenerConfig.ALPHABET.Length;

            char char1 = UrlShortenerConfig.ALPHABET[index1];
            char char2 = UrlShortenerConfig.ALPHABET[index2];

            return $"{char1}{char2}";
        }

        public int DecodeAliasId(string reducedUrl)
        {
            if (reducedUrl.Length < 2)
                throw new ArgumentException("Invalid reduced URL length.", nameof(reducedUrl));

            char char1 = reducedUrl[0];
            char char2 = reducedUrl[1];

            int index1 = UrlShortenerConfig.ALPHABET.IndexOf(char1);
            int index2 = UrlShortenerConfig.ALPHABET.IndexOf(char2);

            if (index1 == -1 || index2 == -1)
                throw new ArgumentException("Invalid characters in reduced URL.", nameof(reducedUrl));

            int aliasId = index1 * UrlShortenerConfig.ALPHABET.Length + index2;

            return aliasId;
        }
    }
}
