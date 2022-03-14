using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos;
using Bbt.Campaign.Public.Dtos.CampaignAchievement;
using Bbt.Campaign.Public.Models.CampaignAchievement;

namespace Bbt.Campaign.Services.Services.CampaignAchievement
{
    public interface ICampaignAchievementService
    {
        public Task<BaseResponse<CampaignAchievementDto>> GetCampaignAchievementAsync(int id);
        public Task<BaseResponse<CampaignAchievementDto>> AddAsync(CampaignAchievementInsertRequest CampaignAchievement);
        public Task<BaseResponse<CampaignAchievementDto>> UpdateAsync(CampaignAchievementUpdateRequest CampaignAchievement);
        public Task<BaseResponse<List<CampaignAchievementDto>>> GetListAsync();
        public Task<BaseResponse<CampaignAchievementDto>> DeleteAsync(int id);
        public Task<BaseResponse<CampaignAchievementInsertFormDto>> GetInsertFormAsync();
        public Task<BaseResponse<CampaignAchievementUpdateFormDto>> GetUpdateFormAsync(int id);
        public Task<BaseResponse<ChannelsAndAchievementsByCampaignResponse>> GetListByCampaignAsync(int campaignId);

    }
}
