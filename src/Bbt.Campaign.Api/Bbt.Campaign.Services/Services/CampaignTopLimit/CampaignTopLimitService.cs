using AutoMapper;
using Bbt.Campaign.Core.DbEntities;
using Bbt.Campaign.EntityFrameworkCore.UnitOfWork;
using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos.CampaignTopLimit;
using Bbt.Campaign.Public.Enums;
using Bbt.Campaign.Public.Models.CampaignTopLimit;
using Bbt.Campaign.Services.Services.Campaign;
using Bbt.Campaign.Services.Services.Parameter;
using Bbt.Campaign.Shared.ServiceDependencies;

namespace Bbt.Campaign.Services.Services.CampaignTopLimit
{
    public class CampaignTopLimitService : ICampaignTopLimitService, IScopedService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IParameterService _parameterService;
        private readonly ICampaignService _campaignService;

        public CampaignTopLimitService(IUnitOfWork unitOfWork, IMapper mapper, IParameterService parameterService, ICampaignService campaignService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _parameterService = parameterService;
            _campaignService = campaignService;
        }

        public async Task<BaseResponse<CampaignTopLimitDto>> AddAsync(CampaignTopLimitInsertRequest campaignTopLimit)
        {
            await CheckValidationAsync(campaignTopLimit);
            ChackCampaignIds(campaignTopLimit);

            var campaignIds = campaignTopLimit.CampaignIds.Distinct().ToList();
            var baseEntity = SetTopLimitChanges(campaignTopLimit);

            List<CampaignTopLimitEntity> campaignTopLimitList = new List<CampaignTopLimitEntity>();
            campaignIds.ForEach(x =>
            {
                var newEntity = baseEntity;
                newEntity.CampaignId = x;
                campaignTopLimitList.Add(newEntity);
            });

            await _unitOfWork.GetRepository<CampaignTopLimitEntity>().AddRangeAsync(campaignTopLimitList);
            await _unitOfWork.SaveChangesAsync();
            return await BaseResponse<CampaignTopLimitDto>.SuccessAsync();
        }

        private static void ChackCampaignIds(CampaignTopLimitInsertRequest campaignTopLimit)
        {
            if (campaignTopLimit.CampaignIds == null || !campaignTopLimit.CampaignIds.Any())
                throw new Exception("Kampanya bulunamadı.");
            else if (campaignTopLimit.CampaignIds.Any(x => x <= 0))
                throw new Exception($"Hatalı Kampanya bilgisi (Kampanya Id: {campaignTopLimit.CampaignIds.FirstOrDefault(x => x <= 0)}).");
        }

        private CampaignTopLimitEntity SetTopLimitChanges(CampaignTopLimitInsertBaseRequest campaignTopLimit)
        {
            CampaignTopLimitEntity entity = _mapper.Map<CampaignTopLimitEntity>(campaignTopLimit);
            if (entity.Type == TopLimitType.Amount)
            {
                entity.MaxTopLimitRate = null;
            }
            else if (entity.Type == TopLimitType.Rate)
            {
                entity.MaxTopLimitAmount = null;
                entity.CurrencyId = null;
            }
            entity.IsDeleted = false;

            return entity;
        }

        public async Task<BaseResponse<CampaignTopLimitDto>> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<CampaignTopLimitEntity>().GetByIdAsync(id);
            if (entity == null)
                return null;

            entity.IsDeleted = true;
            await _unitOfWork.GetRepository<CampaignTopLimitEntity>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return await GetCampaignTopLimitAsync(entity.Id);
        }

        public async Task<BaseResponse<CampaignTopLimitDto>> GetCampaignTopLimitAsync(int id)
        {
            var campaignTopLimitEntity = await _unitOfWork.GetRepository<CampaignTopLimitEntity>().GetByIdAsync(id);
            if (campaignTopLimitEntity != null)
            {
                CampaignTopLimitDto mappedCampaignTopLimit = _mapper.Map<CampaignTopLimitDto>(campaignTopLimitEntity);
                return await BaseResponse<CampaignTopLimitDto>.SuccessAsync(mappedCampaignTopLimit);
            }
            throw new Exception("Kampanya Çatı Limiti bulunamadı.");
        }

        public async Task<BaseResponse<CampaignTopLimitInsertFormDto>> GetInsertForm()
        {
            CampaignTopLimitInsertFormDto response = new CampaignTopLimitInsertFormDto();
            await FillForm(response);

            return await BaseResponse<CampaignTopLimitInsertFormDto>.SuccessAsync(response);
        }

        private async Task FillForm(CampaignTopLimitInsertFormDto response)
        {
            response.CurrencyList = (await _parameterService.GetCurrencyListAsync())?.Data;
            response.AchievementFrequencyList = (await _parameterService.GetAchievementFrequencyListAsync())?.Data;
            response.CampaignList = (await _campaignService.GetParameterListAsync())?.Data;
        }

        public async Task<BaseResponse<List<CampaignTopLimitDto>>> GetListAsync()
        {
            List<CampaignTopLimitDto> campaignTopLimitList = _unitOfWork.GetRepository<CampaignTopLimitEntity>().GetAll().Select(x => _mapper.Map<CampaignTopLimitDto>(x)).ToList();
            return await BaseResponse<List<CampaignTopLimitDto>>.SuccessAsync(campaignTopLimitList);
        }

        public async Task<BaseResponse<CampaignTopLimitUpdateFormDto>> GetUpdateForm(int id)
        {
            CampaignTopLimitUpdateFormDto response = new CampaignTopLimitUpdateFormDto();
            await FillForm(response);
            response.CampaignTopLimit = (await GetCampaignTopLimitAsync(id))?.Data;

            return await BaseResponse<CampaignTopLimitUpdateFormDto>.SuccessAsync(response);
        }

        public async Task<BaseResponse<CampaignTopLimitDto>> UpdateAsync(CampaignTopLimitUpdateRequest campaignTopLimit)
        {
            if (campaignTopLimit.Id <= 0)
                throw new Exception("Kampanya Çatı Limiti bulunamadı.");
            if ((await GetCampaignTopLimitAsync(campaignTopLimit.Id))?.Data is null)
                throw new Exception("Kampanya Çatı Limiti bulunamadı.");

            var entity = SetTopLimitChanges(campaignTopLimit);

            await _unitOfWork.GetRepository<CampaignTopLimitEntity>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return await GetCampaignTopLimitAsync(campaignTopLimit.Id);
        }

        public async Task<BaseResponse<CampaignTopLimitListFilterResponse>> GetByFilterAsync(CampaignTopLimitListFilterRequest request)
        {
            Core.Helper.Helpers.ListByFilterCheckValidation(request);

            var campaignTopLimitQuery = _unitOfWork.GetRepository<CampaignTopLimitEntity>().GetAll(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(request.CampaignName))
                campaignTopLimitQuery = campaignTopLimitQuery.Where(x => x.Campaign.Name == request.CampaignName);
            if (request.AchievementFrequencyId.HasValue)
                campaignTopLimitQuery = campaignTopLimitQuery.Where(x => x.AchievementFrequencyId == request.AchievementFrequencyId.Value);
            if (request.CurrencyId.HasValue)
                campaignTopLimitQuery = campaignTopLimitQuery.Where(x => x.CurrencyId == request.CurrencyId);
            if (request.MaxTopLimitAmount.HasValue)
                campaignTopLimitQuery = campaignTopLimitQuery.Where(x => x.MaxTopLimitAmount == request.MaxTopLimitAmount.Value);
            if (request.MaxTopLimitRate.HasValue)
                campaignTopLimitQuery = campaignTopLimitQuery.Where(x => x.MaxTopLimitRate == request.MaxTopLimitRate.Value);
            if (request.MaxTopLimitUtilization.HasValue)
                campaignTopLimitQuery = campaignTopLimitQuery.Where(x => x.MaxTopLimitUtilization == request.MaxTopLimitUtilization.Value);
            if (request.Type.HasValue)
                campaignTopLimitQuery = campaignTopLimitQuery.Where(x => x.Type == request.Type.Value);

            var pageNumber = request.PageNumber.GetValueOrDefault(1) < 1 ? 1 : request.PageNumber.GetValueOrDefault(1);
            var pageSize = request.PageSize.GetValueOrDefault(0) == 0 ? 25 : request.PageSize.Value;
            var totalItems = campaignTopLimitQuery.Count();

            campaignTopLimitQuery = campaignTopLimitQuery.OrderByDescending(x => x.CreatedOn).Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var campaignList = campaignTopLimitQuery.Select(x => new CampaignTopLimitListDto
            {
                Id = x.Id,
                AchievementFrequency = x.AchievementFrequency.Name,
                Amount = x.Type == Public.Enums.TopLimitType.Amount,
                Rate = x.Type == Public.Enums.TopLimitType.Rate,
                CampaignName = x.Campaign.Name,
                Currency = x.Currency.Name,
                MaxTopLimitAmount = x.MaxTopLimitAmount,
                MaxTopLimitRate = x.MaxTopLimitRate,
                MaxTopLimitUtilization = x.MaxTopLimitUtilization
            }).ToList();

            CampaignTopLimitListFilterResponse response = new CampaignTopLimitListFilterResponse();
            response.ResponseList = campaignList;
            response.Paging = Core.Helper.Helpers.Paging(totalItems, pageNumber, pageSize);

            return await BaseResponse<CampaignTopLimitListFilterResponse>.SuccessAsync(response);
        }

        public async Task<BaseResponse<CampaignTopLimitFilterParameterResponse>> GetFilterParameterList()
        {
            CampaignTopLimitFilterParameterResponse response = new CampaignTopLimitFilterParameterResponse();
            await FillForm(response);
            response.TypeList = Core.Helper.Helpers.EnumToList<TopLimitType>().Select(x => new Public.Dtos.ParameterDto
            {
                Id = x.Key,
                Name = x.Value
            }).ToList();

            return await BaseResponse<CampaignTopLimitFilterParameterResponse>.SuccessAsync(response);
        }

        async Task CheckValidationAsync(CampaignTopLimitInsertBaseRequest input)
        {
            if (input.AchievementFrequencyId <= 0)
                throw new Exception("Aksiyon seçilmelidir.");
            else
            {
                var achievementFrequency = (await _parameterService.GetAchievementFrequencyListAsync())?.Data?.Any(x => x.Id == input.AchievementFrequencyId);
                if (!achievementFrequency.GetValueOrDefault(false))
                    throw new Exception("Aksiyon seçilmelidir.");
            }
            if (input.Type == TopLimitType.Amount)
            {
                if (!input.CurrencyId.HasValue || input.CurrencyId <= 0)
                    throw new Exception("Para Birimi seçilmelidir.");
                else
                {
                    var currency = (await _parameterService.GetCurrencyListAsync())?.Data?.Any(x => x.Id == input.CurrencyId);
                    if (!currency.GetValueOrDefault(false))
                        throw new Exception("Para Birimi seçilmelidir.");
                }
                if (!input.MaxTopLimitAmount.HasValue || input.MaxTopLimitAmount.Value <= 0)
                    throw new Exception("Çatı Max Tutar girilmelidir.");
            }
            else if (input.Type == TopLimitType.Rate)
            {
                if (!input.MaxTopLimitRate.HasValue)
                    throw new Exception("Çatı Oranı girilmelidir.");
                if (input.MaxTopLimitRate > 100)
                    throw new Exception("Oran %100’den büyük bir değer girilemez.");
                if (input.MaxTopLimitRate < 0)
                    throw new Exception("Oran %0’dan küçük bir değer girilemez");
            }
            else
                throw new Exception("Çatı limit tipi seçilmelidir.");
        }
    }
}
