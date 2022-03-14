using AutoMapper;
using Bbt.Campaign.Core.DbEntities;
using Bbt.Campaign.Core.Helper;
using Bbt.Campaign.EntityFrameworkCore.UnitOfWork;
using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos;
using Bbt.Campaign.Public.Dtos.CampaignAchievement;
using Bbt.Campaign.Public.Enums;
using Bbt.Campaign.Public.Models.CampaignAchievement;
using Bbt.Campaign.Services.Services.Campaign;
using Bbt.Campaign.Services.Services.Parameter;
using Bbt.Campaign.Shared.ServiceDependencies;
using Microsoft.EntityFrameworkCore;

namespace Bbt.Campaign.Services.Services.CampaignAchievement
{
    public class CampaignAchievementService : ICampaignAchievementService, IScopedService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IParameterService _parameterService;
        private readonly ICampaignService _campaignService;

        public CampaignAchievementService(IUnitOfWork unitOfWork, IMapper mapper, IParameterService parameterService, ICampaignService campaignService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _parameterService = parameterService;
            _campaignService = campaignService;
        }

        public async Task<BaseResponse<CampaignAchievementDto>> AddAsync(CampaignAchievementInsertRequest campaignAchievement)
        {
            await CheckValidationAsync(campaignAchievement);
            var entity = _mapper.Map<CampaignAchievementEntity>(campaignAchievement);
            if (entity.Type == AchievementType.Amount)
            {
                entity.Rate = null;
            }
            else if (entity.Type == AchievementType.Rate)
            {
                entity.Amount = null;
                entity.CurrencyId = null;
                entity.MaxAmount = null;
            }
            //Bir kanala ait tutar/oran bazında birden fazla kayıt olmamalı
            var hasAnyAchievementTypeAndChannelDuplicate = await _unitOfWork.GetRepository<CampaignAchievementEntity>()
                                                                            .AnyAsync(x => !x.IsDeleted && x.CampaignChannelId == entity.CampaignChannelId && x.Type == entity.Type);
            if (hasAnyAchievementTypeAndChannelDuplicate)
                throw new Exception($"Aynı kanala ait Tutar/Oran bazında sadece bir kazanım eklenebilir.");

            entity = await _unitOfWork.GetRepository<CampaignAchievementEntity>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            CampaignAchievementDto mappedCampaignAchievement = _mapper.Map<CampaignAchievementDto>(entity);
            return await BaseResponse<CampaignAchievementDto>.SuccessAsync(mappedCampaignAchievement);
        }

        public async Task<BaseResponse<CampaignAchievementDto>> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<CampaignAchievementEntity>().GetByIdAsync(id);
            if (entity == null)
                return null;

            entity.IsDeleted = true;
            await _unitOfWork.GetRepository<CampaignAchievementEntity>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return await GetCampaignAchievementAsync(entity.Id);
        }

        public async Task<BaseResponse<CampaignAchievementDto>> GetCampaignAchievementAsync(int id)
        {
            var campaignAchievementEntity = await _unitOfWork.GetRepository<CampaignAchievementEntity>().GetByIdAsync(id);
            if (campaignAchievementEntity != null)
            {
                CampaignAchievementDto mappedCampaignAchievement = _mapper.Map<CampaignAchievementDto>(campaignAchievementEntity);
                return await BaseResponse<CampaignAchievementDto>.SuccessAsync(mappedCampaignAchievement);
            }
            throw new Exception("Kampanya kazanımı bulunamadı.");
        }

        public async Task<BaseResponse<CampaignAchievementInsertFormDto>> GetInsertFormAsync()
        {
            CampaignAchievementInsertFormDto response = new CampaignAchievementInsertFormDto();
            await FillForm(response);

            return await BaseResponse<CampaignAchievementInsertFormDto>.SuccessAsync(response);
        }

        private async Task FillForm(CampaignAchievementInsertFormDto response)
        {
            response.CurrencyList = (await _parameterService.GetCurrencyListAsync())?.Data;
            response.AchievementTypes = (await _parameterService.GetAchievementTypeListAsync())?.Data;
            response.ActionOptions = (await _parameterService.GetActionOptionListAsync())?.Data;
        }

        public async Task<BaseResponse<List<CampaignAchievementDto>>> GetListAsync()
        {
            List<CampaignAchievementDto> campaignAchievementList = _unitOfWork.GetRepository<CampaignAchievementEntity>().GetAll().Select(x => _mapper.Map<CampaignAchievementDto>(x)).ToList();
            return await BaseResponse<List<CampaignAchievementDto>>.SuccessAsync(campaignAchievementList);
        }

        public async Task<BaseResponse<CampaignAchievementUpdateFormDto>> GetUpdateFormAsync(int id)
        {
            CampaignAchievementUpdateFormDto response = new CampaignAchievementUpdateFormDto();
            await FillForm(response);
            response.CampaignAchievement = (await GetCampaignAchievementAsync(id))?.Data;

            return await BaseResponse<CampaignAchievementUpdateFormDto>.SuccessAsync(response);
        }

        public async Task<BaseResponse<CampaignAchievementDto>> UpdateAsync(CampaignAchievementUpdateRequest campaignAchievement)
        {
            if (campaignAchievement.Id <= 0)
                throw new Exception("Kampanya Kazanım bulunamadı.");
            if ((await GetCampaignAchievementAsync(campaignAchievement.Id))?.Data is null)
                throw new Exception("Kampanya Kazanım bulunamadı.");

            var entity = _mapper.Map<CampaignAchievementEntity>(campaignAchievement);
            if (entity.Type == AchievementType.Amount)
            {
                entity.Rate = null;
            }
            else if (entity.Type == AchievementType.Rate)
            {
                entity.Amount = null;
                entity.CurrencyId = null;
                entity.MaxAmount = null;
            }
            //Bir kanala ait tutar/oran bazında birden fazla kayıt olmamalı
            var hasAnyAchievementTypeAndChannelDuplicate = await _unitOfWork.GetRepository<CampaignAchievementEntity>()
                                                                            .AnyAsync(x => !x.IsDeleted && x.Id != entity.Id && x.CampaignChannelId == entity.CampaignChannelId && x.Type == entity.Type);
            if (hasAnyAchievementTypeAndChannelDuplicate)
                throw new Exception($"Aynı kanala ait Tutar/Oran bazında sadece bir kazanım eklenebilir.");

            await _unitOfWork.GetRepository<CampaignAchievementEntity>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return await GetCampaignAchievementAsync(campaignAchievement.Id);
        }

        async Task CheckValidationAsync(CampaignAchievementInsertRequest input)
        {
            if (string.IsNullOrWhiteSpace(input.DescriptionTr))
                throw new Exception("Açıklama Detayı girilmelidir.");
            if (string.IsNullOrWhiteSpace(input.DescriptionEn))
                throw new Exception("Açıklama Detayı (İngilizce) girilmelidir.");
            if (string.IsNullOrWhiteSpace(input.TitleTr))
                throw new Exception("Başlık girilmelidir.");
            if (string.IsNullOrWhiteSpace(input.TitleEn))
                throw new Exception("Başlık (İngilizce) girilmelidir.");

            if (input.CampaignId <= 0)
                throw new Exception("Kampanya seçilmelidir.");
            else
            {
                var campaign = (await _campaignService.GetCampaignAsync(input.CampaignId))?.Data;
                if (campaign is null)
                    throw new Exception("Kampanya bulunamadı.");
            }
            if (input.CampaignChannelId <= 0)
                throw new Exception("Kazanım Kanalı seçilmelidir.");
            else
            {
                var channel = (await _parameterService.GetCampaignChannelListAsync())?.Data?.Any(x => x.Id == input.CampaignChannelId);
                if (!channel.GetValueOrDefault(false))
                    throw new Exception("Kazanım Kanalı seçilmelidir.");
            }

            if (input.ActionOptionId <= 0)
                throw new Exception("Aksiyon seçilmelidir.");
            else
            {
                var actionOption = (await _parameterService.GetActionOptionListAsync())?.Data?.Any(x => x.Id == input.ActionOptionId);
                if (!actionOption.GetValueOrDefault(false))
                    throw new Exception("Aksiyon seçilmelidir.");
            }
            if (input.AchievementTypeId <= 0)
                throw new Exception("Kazanım tipi seçilmelidir.");
            else
            {
                var achievementFrequency = (await _parameterService.GetAchievementTypeListAsync())?.Data?.Any(x => x.Id == input.AchievementTypeId);
                if (!achievementFrequency.GetValueOrDefault(false))
                    throw new Exception("Kazanım tipi seçilmelidir.");
            }
            if (input.Type == AchievementType.Amount)
            {
                if (!input.CurrencyId.HasValue || input.CurrencyId <= 0)
                    throw new Exception("Para Birimi seçilmelidir.");
                else
                {
                    var currency = (await _parameterService.GetCurrencyListAsync())?.Data?.Any(x => x.Id == input.CurrencyId);
                    if (!currency.GetValueOrDefault(false))
                        throw new Exception("Para Birimi seçilmelidir.");
                }
                if (!input.Amount.HasValue || input.Amount.Value <= 0)
                    throw new Exception("Kazanım Tutarı girilmelidir.");
                if (!input.MaxAmount.HasValue || input.MaxAmount.Value <= 0)
                    throw new Exception("Max Tutar girilmelidir.");
            }
            else if (input.Type == AchievementType.Rate)
            {
                if (!input.Rate.HasValue)
                    throw new Exception("Kazanım Oranı girilmelidir.");
                if (input.Rate > 100)
                    throw new Exception("Oran %100’den büyük bir değer girilemez.");
                if (input.Rate < 0)
                    throw new Exception("Oran %0’dan küçük bir değer girilemez");
            }
            else
                throw new Exception("Kazanım türü (Tutar/Oran) seçilmelidir.");
        }

        public async Task<BaseResponse<ChannelsAndAchievementsByCampaignResponse>> GetListByCampaignAsync(int campaignId)
        {
            ChannelsAndAchievementsByCampaignResponse response = new ChannelsAndAchievementsByCampaignResponse();

            var achievements = _unitOfWork.GetRepository<CampaignAchievementEntity>()
                                      .GetAll(x => !x.IsDeleted && x.CampaignId == campaignId)
                                      .Include(x=> x.ActionOption)
                                      .Include(x=> x.AchievementType)
                                      .OrderBy(x => x.CampaignChannelId)
                                      .ThenBy(x => x.Type).ToList();

            var channels = (await _parameterService.GetCampaignChannelListAsync()).Data;

            foreach (var channel in channels)
            {
                var _achievements = achievements.Where(x => x.CampaignChannelId == x.Id).Select(x => new CampaignAchievementListDto
                {
                    Id = x.Id,
                    AchievementType = x.AchievementType?.Name,
                    Action = x.ActionOption?.Name,
                    Type = Helpers.GetEnumDescription(x.Type),
                    MaxUtilization = x.MaxUtilization
                }).ToList();

                response.ChannelsAndAchievements.Add(new ChannelsAndAchievementsByCampaignDto
                {
                    CampaignChannelId = channel.Id,
                    CampaignChannelName = channel.Name,
                    HasAchievement = _achievements.Any(),
                    AchievementList = _achievements
                });

            }

            return await BaseResponse<ChannelsAndAchievementsByCampaignResponse>.SuccessAsync(response);

        }
    }
}
