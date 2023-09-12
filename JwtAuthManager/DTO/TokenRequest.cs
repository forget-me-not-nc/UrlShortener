using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthManager.DTO
{
    public class TokenRequest
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string[] Roles { get; set; }
    }
}
