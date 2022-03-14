using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos.CampaignTopLimit;
using Bbt.Campaign.Public.Models.CampaignTopLimit;

namespace Bbt.Campaign.Services.Services.CampaignTopLimit
{
    public interface ICampaignTopLimitService
    {
        public Task<BaseResponse<CampaignTopLimitDto>> GetCampaignTopLimitAsync(int id);
        public Task<BaseResponse<CampaignTopLimitDto>> AddAsync(CampaignTopLimitInsertRequest campaignTopLimit);
        public Task<BaseResponse<CampaignTopLimitDto>> UpdateAsync(CampaignTopLimitUpdateRequest campaignTopLimit);
        public Task<BaseResponse<List<CampaignTopLimitDto>>> GetListAsync();
        public Task<BaseResponse<CampaignTopLimitDto>> DeleteAsync(int id);
        public Task<BaseResponse<CampaignTopLimitInsertFormDto>> GetInsertForm();
        public Task<BaseResponse<CampaignTopLimitFilterParameterResponse>> GetFilterParameterList();
        public Task<BaseResponse<CampaignTopLimitUpdateFormDto>> GetUpdateForm(int id);
        public Task<BaseResponse<CampaignTopLimitListFilterResponse>> GetByFilterAsync(CampaignTopLimitListFilterRequest request);


    }
}
