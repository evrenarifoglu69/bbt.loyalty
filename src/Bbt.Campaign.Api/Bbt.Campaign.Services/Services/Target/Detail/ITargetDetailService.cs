﻿using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos.Target.Detail;
using Bbt.Campaign.Public.Models.Target.Detail;

namespace Bbt.Campaign.Services.Services.Target.Detail
{
    public interface ITargetDetailService
    {
        public Task<BaseResponse<TargetDetailDto>> AddAsync(TargetDetailInsertRequest targetDetail);
        public Task<BaseResponse<TargetDetailDto>> UpdateAsync(TargetDetailUpdateRequest targetDetail);
        public Task<BaseResponse<TargetDetailListFilterResponse>> GetByFilterAsync(TargetDetailListFilterRequest request);
        public Task<BaseResponse<TargetDetailDto>> DeleteAsync(int id);
        public Task<BaseResponse<TargetDetailDto>> GetTargetDetailAsync(int id);
    }
}
