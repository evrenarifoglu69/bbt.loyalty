using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos;
using Bbt.Campaign.Public.Dtos.Campaign;
using Bbt.Campaign.Public.Models.Campaign;

namespace Bbt.Campaign.Services.Services.Campaign
{
    public interface ICampaignService
    {
        public Task<BaseResponse<CampaignDto>> GetCampaignAsync(int id);
        public Task<BaseResponse<CampaignDto>> AddAsync(CampaignInsertRequest campaign);
        public Task<BaseResponse<CampaignDto>> UpdateAsync(CampaignUpdateRequest campaign);
        public Task<BaseResponse<List<CampaignDto>>> GetListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetParameterListAsync();
        public Task<BaseResponse<CampaignDto>> DeleteAsync(int id);
        public Task<BaseResponse<CampaignInsertFormDto>> GetInsertFormAsync();
        public Task<BaseResponse<CampaignUpdateFormDto>> GetUpdateFormAsync(int id);
        public Task<BaseResponse<CampaignListFilterResponse>> GetByFilterAsync(CampaignListFilterRequest request);

    }
}
