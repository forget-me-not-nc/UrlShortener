using BusinessLogicLayer.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.AuthServices
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        
    }
}
