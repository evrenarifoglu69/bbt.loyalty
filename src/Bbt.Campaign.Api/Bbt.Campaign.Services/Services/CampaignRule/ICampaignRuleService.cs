﻿using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos.CampaignRule;
using Bbt.Campaign.Public.Models.CampaignRule;

namespace Bbt.Campaign.Services.Services.CampaignRule
{
    public interface ICampaignRuleService
    {
        public Task<BaseResponse<CampaignRuleDto>> GetCampaignRuleAsync(int id);
        public Task<BaseResponse<CampaignRuleDto>> AddAsync(AddCampaignRuleRequest campaignRule);
        public Task<BaseResponse<CampaignRuleDto>> UpdateAsync(UpdateCampaignRuleRequest campaignRule);
        public Task<BaseResponse<List<CampaignRuleDto>>> GetListAsync();
        public Task<BaseResponse<CampaignRuleDto>> DeleteAsync(int id);
        public Task<BaseResponse<CampaignRuleInsertFormDto>> GetInsertForm();
        public Task<BaseResponse<CampaignRuleUpdateFormDto>> GetUpdateForm(int id);

    }
}
