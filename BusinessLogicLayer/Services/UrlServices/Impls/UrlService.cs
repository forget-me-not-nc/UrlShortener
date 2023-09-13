using AutoMapper;
using BusinessLogicLayer.DTOs.UrlDTOs;
using DataAccessLayer.Repos.UrlsRepos;
using BusinessLogicLayer.Services.UrlServices;
using BusinessLogicLayer.Services.UserServices;
using DataAccessLayer.Entities;
using System.ComponentModel.Design;
using BusinessLogicLayer.Services.UrlShortenerServices;

namespace BusinessLogicLayer.Services.UserServices.Impls
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepo _urlRepo;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUtilsService _utils;
        private readonly IUrlShortenerService _urlShortenerService;

        public UrlService(
            IUrlRepo urlRepo,
            IMapper mapper,
            IUserService userService,
            IUtilsService utils,
            IUrlShortenerService urlShortenerService
            )
        {
            _urlRepo = urlRepo;
            _mapper = mapper;
            _userService = userService;
            _utils = utils;
            _urlShortenerService = urlShortenerService;
        }

        public async Task<UrlResponse> CreateAsync(UrlCreateRequest entity)
        {
            if (await GetUrlByBaseUrl(entity.BaseUrl) != null)
                throw new Exception("Url already exist.");

            var newUrl = _mapper.Map<Url>(entity);

            newUrl.UserId = _utils.GetUserIdFromClaims();

            string slug;
            do
            {
                slug = _urlShortenerService.CreateShortUrl();

            } while (await GetUrlBySlug(slug) != null);

            newUrl.Slug = slug;

            newUrl = await _urlRepo.CreateAsync(newUrl);

            await _urlRepo.SaveChangesAsync();

            var urlInfo = await GetFullUrlInfo(newUrl.Id);

            return _mapper.Map<UrlResponse>(urlInfo);
        }

        public async Task DeleteAsync(int id)
        {
            await _urlRepo.DeleteAsync(id);

            await _urlRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<UrlResponse>> GetAllAsync()
        {
            var urlEntities = await _urlRepo.GetAllAsync();

            var infos = new List<UrlResponse>();

            foreach (var el in urlEntities)
            {
                var info = await GetFullUrlInfo(el.Id);
                infos.Add(info);
            }

            return infos;
        }

        public async Task<UrlResponse> GetAsync(int id)
        {
            var url = await _urlRepo.GetByIdAsync(id);

            url.User = await _userService.GetUserAsync(url.UserId);

            return _mapper.Map<UrlResponse>(url);
        }

        public async Task<UrlResponse> GetFullUrlInfo(int id)
        {
            var url = await _urlRepo.GetFullUrlInfo(id);

            return _mapper.Map<UrlResponse>(url);
        }

        public async Task<UrlResponse> GetUrlByBaseUrl(string baseUrl)
        {
            var url = await _urlRepo.GetUrlByBaseUrl(baseUrl);

            return _mapper.Map<UrlResponse>(url);
        }

        public async Task<UrlResponse> GetUrlBySlug(string slug)
        {
            var url = await _urlRepo.GetUrlBySlug(slug);

            return _mapper.Map<UrlResponse>(url);
        }

        public async Task<List<UrlResponse>> GetUrlsByUserId(int userId)
        {
            var urls = await _urlRepo.GetUrslByUserId(userId);

            var infos = new List<UrlResponse>();

            foreach (var el in urls)
            {
                var info = await GetFullUrlInfo(el.Id);
                infos.Add(info);
            }

            return infos;
        }

        public async Task<UrlResponse> UpdateAsync(UrlUpdateRequest entity)
        {
            var oldUrl = await _urlRepo.GetByIdAsync(entity.Id);

            if (await GetUrlByBaseUrl(entity.BaseUrl) != null && oldUrl.BaseUrl != entity.BaseUrl)
                throw new Exception("Url already exist.");

            oldUrl.BaseUrl = entity.BaseUrl;
            oldUrl.Description = entity.Description;
            oldUrl.ModifiedAt = DateTime.Now;

            await _urlRepo.UpdateAsync(oldUrl);

            await _urlRepo.SaveChangesAsync();

            var urlInfo = await GetFullUrlInfo(entity.Id);

            return _mapper.Map<UrlResponse>(urlInfo);
        }
    }
}
