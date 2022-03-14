using AutoMapper;
using Bbt.Campaign.Core.DbEntities;
using Bbt.Campaign.EntityFrameworkCore.UnitOfWork;
using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos.Target.Detail;
using Bbt.Campaign.Public.Models.Target.Detail;
using Bbt.Campaign.Services.Services.Parameter;
using Bbt.Campaign.Shared.ServiceDependencies;

namespace Bbt.Campaign.Services.Services.Target.Detail
{
    public class TargetDetailService : ITargetDetailService, IScopedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IParameterService _parameterService;

        public TargetDetailService(IUnitOfWork unitOfWork, IMapper mapper, IParameterService parameterService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _parameterService = parameterService;
        }
        public async Task<BaseResponse<TargetDetailDto>> AddAsync(TargetDetailInsertRequest targetDetail)
        {
            var entity = _mapper.Map<TargetDetailEntity>(targetDetail);
            entity = await _unitOfWork.GetRepository<TargetDetailEntity>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            var mappedTarget = _mapper.Map<TargetDetailDto>(entity);
            return await BaseResponse<TargetDetailDto>.SuccessAsync(mappedTarget);
        }

        public async Task<BaseResponse<TargetDetailDto>> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<TargetDetailEntity>().GetByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.GetRepository<TargetDetailEntity>().DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                return await GetTargetDetailAsync(entity.Id);
            }
            return await BaseResponse<TargetDetailDto>.FailAsync("Kampanya bulunamadı.");
        }

        public Task<BaseResponse<TargetDetailListFilterResponse>> GetByFilterAsync(TargetDetailListFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<TargetDetailDto>> GetTargetDetailAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<TargetEntity>().GetByIdAsync(id);
            if (entity != null)
            {
                var mappedTarget = _mapper.Map<TargetDetailDto>(entity);
                return await BaseResponse<TargetDetailDto>.SuccessAsync(mappedTarget);
            }
            return await BaseResponse<TargetDetailDto>.FailAsync("Kampanya bulunamadı.");
        }

        public async Task<BaseResponse<TargetDetailDto>> UpdateAsync(TargetDetailUpdateRequest targetDetail)
        {
            //await CheckValidationAsync(Target);
            var entity = await _unitOfWork.GetRepository<TargetDetailEntity>().GetByIdAsync(targetDetail.Id);
            if (entity != null)
            {
                entity.AdditionalFlowTime = targetDetail.AdditionalFlowTime;
                entity.FlowFrequency = targetDetail.FlowFrequency;
                entity.TotalAmount = targetDetail.TotalAmount;
                entity.Condition = targetDetail.Condition;
                entity.DescriptionEn = targetDetail.DescriptionEn;
                entity.DescriptionTr = targetDetail.DescriptionTr;
                entity.FlowName = targetDetail.FlowName;
                entity.NumberOfTransaction = targetDetail.NumberOfTransaction;
                entity.Query = targetDetail.Query;
                entity.TargetDetailEn = targetDetail.TargetDetailEn;
                entity.TargetDetailTr = targetDetail.TargetDetailTr;
                entity.TargetSourceId = targetDetail.TargetSourceId;
                entity.TargetViewTypeId = targetDetail.TargetViewTypeId;
                entity.TriggerTimeId = targetDetail.TriggerTimeId;
                entity.VerificationTimeId = targetDetail.VerificationTimeId;

                await _unitOfWork.GetRepository<TargetDetailEntity>().UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                return await GetTargetDetailAsync(targetDetail.Id);
            }
            return await BaseResponse<TargetDetailDto>.FailAsync("Kampanya bulunamadı.");
        }
    }
}
