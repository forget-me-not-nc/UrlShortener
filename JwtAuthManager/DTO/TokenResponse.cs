using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthManager.DTO
{
    public class TokenResponse
    {
        public string Username { get; set; }

        public string JwtToken { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
