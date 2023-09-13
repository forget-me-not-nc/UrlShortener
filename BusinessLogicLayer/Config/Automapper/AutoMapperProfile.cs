using AutoMapper;
using BusinessLogicLayer.Config.UrlShortener;
using BusinessLogicLayer.DTOs.Auth;
using BusinessLogicLayer.DTOs.RolesDTOs;
using BusinessLogicLayer.DTOs.UrlDTOs;
using BusinessLogicLayer.DTOs.UserDTOs;
using DataAccessLayer.Entities;
using JwtAuthManager.DTO;
using System;

namespace BusinessLogicLayer.Config.Automapper
{
    public class AutoMapperProfile: Profile
    {
        private void UrlsMapper()
        {
            CreateMap<Url, UrlResponse>()
                .ForMember(m => m.UserName, opt => opt.MapFrom(x => x.User.Username))
                .ForMember(m => m.Domain, opt => opt.MapFrom(x => UrlShortenerConfig.DOMAIN));

            CreateMap<UrlUpdateRequest, Url>()
                .ForMember(m => m.ModifiedAt, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<UrlCreateRequest, Url>()
                .ForMember(m => m.CreatedAt, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(m => m.ModifiedAt, opt => opt.MapFrom(x => DateTime.Now));
        }

        private void UsersMapper()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserUpdateRequest, User>()
                .ForMember(m => m.Roles,
                opt => opt.Ignore()); ;

            CreateMap<UserCreateRequest, User>()
                .ForMember(m => m.Roles, 
                opt => opt.Ignore());
        }

        private void RolesMapper()
        {
            CreateMap<Role, RolesResponse>()
                .ForMember(m => m.RoleName,
                opt => opt.MapFrom(x => x.Name.ToString()));

        }
        private void CustomDTOMapper()
        {
            CreateMap<TokenResponse, LoginResponse>();
        }

        public AutoMapperProfile()
        {
            UrlsMapper();
            UsersMapper();
            RolesMapper();
            CustomDTOMapper();
        }
    }
}
