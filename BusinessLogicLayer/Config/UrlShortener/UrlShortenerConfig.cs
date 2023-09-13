using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Config.UrlShortener
{
    internal static class UrlShortenerConfig
    {
        internal static int NUM_CHARS_SHORT_LINK = 7;
        internal static string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        internal static string DOMAIN = "http://localhost:5185/";
    }
}
