using AutoMapper;
using BusinessLogicLayer.DTOs.AliasDTOs;
using BusinessLogicLayer.DTOs.UrlDTOs;
using BusinessLogicLayer.DTOs.UserDTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Repos.AliasRepos;
using DataAccessLayer.Repos.RoleRepos;
using DataAccessLayer.Repos.UserRepos;

namespace BusinessLogicLayer.Services.AliasServices.Impls
{
    public class AliasService : IAliasService
    {
        private readonly IAliasRepo _aliasRepo;
        private readonly IMapper _mapper;

        public AliasService(IAliasRepo aliasRepo, IMapper mapper)
        {
            _aliasRepo = aliasRepo;
            _mapper = mapper;
        }

        public async Task<AliasResponse> CreateAsync(AliasCreateRequest entity)
        {
            if (await GetAliasByAliasSlug(entity.AliasSlug) != null)
                throw new Exception("Alias already exist.");

            var newAlias = _mapper.Map<Alias>(entity);

            newAlias = await _aliasRepo.CreateAsync(newAlias);

            await _aliasRepo.SaveChangesAsync();

            return _mapper.Map<AliasResponse>(newAlias);
        }

        public async Task DeleteAsync(int id)
        {
            await _aliasRepo.DeleteAsync(id);

            await _aliasRepo.SaveChangesAsync();
        }

        public async Task<AliasResponse> GetAliasByAliasSlug(string slug)
        {
            var alias = await _aliasRepo.GetAliasByAliasSlug(slug);

            return _mapper.Map<AliasResponse>(alias);
        }

        public async Task<IEnumerable<AliasResponse>> GetAllAsync()
        {
            var entities = await _aliasRepo.GetAllAsync();

            return entities.Select(el => _mapper.Map<AliasResponse>(el));
        }

        public async Task<AliasResponse> GetAsync(int id)
        {
            var alias = await _aliasRepo.GetByIdAsync(id);

            return _mapper.Map<AliasResponse>(alias);
        }

        public async Task<AliasResponse> UpdateAsync(AliasUpdateRequest entity)
        {
            if (await GetAliasByAliasSlug(entity.AliasSlug) != null)
                throw new Exception("Alias already exist.");

            var old = await _aliasRepo.GetByIdAsync(entity.Id);

            old.AliasSlug = entity.AliasSlug;

            await _aliasRepo.UpdateAsync(old);

            await _aliasRepo.SaveChangesAsync();

            return _mapper.Map<AliasResponse>(old);
        }
    }
}
