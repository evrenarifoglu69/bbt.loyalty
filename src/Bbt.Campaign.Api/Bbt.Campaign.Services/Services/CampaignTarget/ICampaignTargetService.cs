using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos.CampaignTarget;

namespace Bbt.Campaign.Services.Services.CampaignTarget
{
    public interface ICampaignTargetService
    {
        public Task<BaseResponse<CampaignTargetDto>> GetCampaignTargetAsync(int id);
        public Task<BaseResponse<CampaignTargetDto>> AddAsync(CampaignTargetDto campaignTarget);

        public Task<BaseResponse<CampaignTargetDto>> UpdateAsync(CampaignTargetDto campaignTarget);
        public Task<BaseResponse<List<CampaignTargetDto>>> GetListAsync();
        public Task<BaseResponse<CampaignTargetDto>> DeleteAsync(int id);
        public Task<BaseResponse<CampaignTargetInsertFormDto>> GetInsertForm();
        public Task<BaseResponse<CampaignTargetUpdateFormDto>> GetUpdateForm(int id);

    }
}
