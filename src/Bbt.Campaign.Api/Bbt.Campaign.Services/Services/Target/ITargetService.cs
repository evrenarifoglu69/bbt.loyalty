﻿using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos.Target;
using Bbt.Campaign.Public.Models.Target;

namespace Bbt.Target.Services.Services.Target
{
    public interface ITargetService
    {
        public Task<BaseResponse<TargetDto>> AddAsync(TargetInsertRequest target);
        public Task<BaseResponse<TargetDto>> UpdateAsync(TargetUpdateRequest Target);
        public Task<BaseResponse<TargetListFilterResponse>> GetByFilterAsync(TargetListFilterRequest request);
        public Task<BaseResponse<TargetDto>> DeleteAsync(int id);
        public Task<BaseResponse<TargetDto>> GetTargetAsync(int id);
    }
}