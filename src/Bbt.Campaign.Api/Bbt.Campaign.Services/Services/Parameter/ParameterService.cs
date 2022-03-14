using AutoMapper;
using Bbt.Campaign.Core.DbEntities;
using Bbt.Campaign.EntityFrameworkCore.Redis;
using Bbt.Campaign.EntityFrameworkCore.UnitOfWork;
using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos;
using Bbt.Campaign.Shared.CacheKey;
using Bbt.Campaign.Shared.ServiceDependencies;
using Newtonsoft.Json;

namespace Bbt.Campaign.Services.Services.Parameter
{
    public class ParameterService : IParameterService, IScopedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRedisDatabaseProvider _redisDatabaseProvider;

        public ParameterService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IRedisDatabaseProvider redisDatabaseProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _redisDatabaseProvider = redisDatabaseProvider;
        }

        public async Task<BaseResponse<List<ParameterDto>>> GetListAsync<T>(string cacheKey) where T : class
        {
            List<ParameterDto> result = null;
            var cache = await _redisDatabaseProvider.GetAsync(cacheKey);
            if (!string.IsNullOrEmpty(cache))
                result = JsonConvert.DeserializeObject<List<ParameterDto>>(cache);
            else
            {
                result = _unitOfWork.GetRepository<T>().GetAll()
                                                    .Select(x => _mapper.Map<ParameterDto>(x))
                                                    .ToList();
                var value = JsonConvert.SerializeObject(result);
                await _redisDatabaseProvider.SetAsync(cacheKey, value);
            }                
            return await BaseResponse<List<ParameterDto>>.SuccessAsync(result);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetAchievementFrequencyListAsync()
        {
            return GetListAsync<AchievementFrequencyEntity>(CacheKeys.AchievementFrequencyList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetActionOptionListAsync()
        {
            return GetListAsync<ActionOptionEntity>(CacheKeys.ActionOptionList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetBranchListAsync()
        {
            return GetListAsync<BranchEntity>(CacheKeys.BranchList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetBusinessLineListAsync()
        {
            return GetListAsync<BusinessLineEntity>(CacheKeys.BusinessLineList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetCampaignChannelListAsync()
        {
            return GetListAsync<CampaignChannelEntity>(CacheKeys.CampaignChannelList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetCampaignStartTermListAsync()
        {
            return GetListAsync<CampaignStartTermEntity>(CacheKeys.CampaignStartTermList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetCurrencyListAsync()
        {
            return GetListAsync<CurrencyEntity>(CacheKeys.CurrencyList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetCustomerTypeListAsync()
        {
            return GetListAsync<CustomerTypeEntity>(CacheKeys.CustomerTypeList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetJoinTypeListAsync()
        {
            return GetListAsync<JoinTypeEntity>(CacheKeys.JoinTypeList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetLanguageListAsync()
        {
            return GetListAsync<LanguageEntity>(CacheKeys.LanguageList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetSectorListAsync()
        {
            return GetListAsync<SectorEntity>(CacheKeys.SectorList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetTargetDefinitionListAsync()
        {
            return GetListAsync<TargetDefinitionEntity>(CacheKeys.TargetDefinitionList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetTargetOperationListAsync()
        {
            return GetListAsync<TargetOperationEntity>(CacheKeys.TargetOperationList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetViewOptionListAsync()
        {
            return GetListAsync<ViewOptionEntity>(CacheKeys.ViewOptionList);
        }        
        public Task<BaseResponse<List<ParameterDto>>> GetProgramTypeListAsync()
        {
            return GetListAsync<ProgramTypeEntity>(CacheKeys.ProgramTypeList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetTargetSourceListAsync()
        {
            return GetListAsync<TargetSourceEntity>(CacheKeys.TargetSourceList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetTargetViewTypeListAsync()
        {
            return GetListAsync<TargetViewTypeEntity>(CacheKeys.TargetViewTypeList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetTriggerTimeListAsync()
        {
            return GetListAsync<TriggerTimeEntity>(CacheKeys.TriggerTimeList);
        }

        public Task<BaseResponse<List<ParameterDto>>> GetVerificationTimeListAsync()
        {
            return GetListAsync<VerificationTimeEntity>(CacheKeys.VerificationTime);
        }
        public Task<BaseResponse<List<ParameterDto>>> GetAchievementTypeListAsync()
        {
            return GetListAsync<AchievementTypeEntity>(CacheKeys.AchievementType);
        }
    }
}
