using AutoMapper;
using BusinessLogicLayer.DTOs.Auth;
using BusinessLogicLayer.Services.UserServices;
using JwtAuthManager;
using JwtAuthManager.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.AuthServices.Impls
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly IMapper _mapper;

        public AuthService(
            IUserService userService,
            JwtTokenHandler jwtTokenHandler,
            IMapper mapper)
        {
            _userService = userService;
            _jwtTokenHandler = jwtTokenHandler;
            _mapper = mapper;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var user = await _userService.GetUserByUsernameAsync(loginRequest.Username)
                ?? throw new Exception("User doesn`t exist.");

            if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
                throw new Exception("Invalid password.");

            var tokenRequest = new TokenRequest
            {
                Username = loginRequest.Username,
                Roles = user.Roles.Select(el => el.Name.ToString()).ToArray(),
                UserId = user.Id
            };

            var tokenResponse = _jwtTokenHandler.GenerateJwtToken(tokenRequest);

            var response = _mapper.Map<LoginResponse>(tokenResponse);
            response.UserId = user.Id;

            return response;
        }
    }
}
