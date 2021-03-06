using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos;

namespace Bbt.Campaign.Services.Services.Parameter
{
    public interface IParameterService
    {
        public Task<BaseResponse<List<ParameterDto>>> GetActionOptionListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetBranchListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetBusinessLineListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetCampaignStartTermListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetCustomerTypeListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetJoinTypeListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetLanguageListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetSectorListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetViewOptionListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetProgramTypeListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetAchievementFrequencyListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetCampaignChannelListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetCurrencyListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetTargetDefinitionListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetTargetOperationListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetTargetSourceListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetTargetViewTypeListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetTriggerTimeListAsync();
        public Task<BaseResponse<List<ParameterDto>>> GetVerificationTimeListAsync();



    }
}
