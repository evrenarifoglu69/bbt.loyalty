using AutoMapper;
using Bbt.Campaign.Core.DbEntities;
using Bbt.Campaign.EntityFrameworkCore.UnitOfWork;
using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos.CampaignTarget;
using Bbt.Campaign.Services.Services.Parameter;
using Bbt.Campaign.Shared.ServiceDependencies;

namespace Bbt.Campaign.Services.Services.CampaignTarget
{
    public class CampaignTargetService : ICampaignTargetService, IScopedService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IParameterService _parameterService;

        public CampaignTargetService(IUnitOfWork unitOfWork, IMapper mapper, IParameterService parameterService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _parameterService = parameterService;
        }

        public async Task<BaseResponse<CampaignTargetDto>> AddAsync(CampaignTargetDto campaignTarget)
        {
            var entity = _mapper.Map<CampaignTargetEntity>(campaignTarget);
            entity = await _unitOfWork.GetRepository<CampaignTargetEntity>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            CampaignTargetDto campaignTargetDto = _mapper.Map<CampaignTargetDto>(entity);
            return await BaseResponse<CampaignTargetDto>.SuccessAsync(campaignTargetDto);
        }

        public async Task<BaseResponse<CampaignTargetDto>> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<CampaignTargetEntity>().GetByIdAsync(id);
            if (entity == null)
                return null;

            entity.IsDeleted = true;
            await _unitOfWork.GetRepository<CampaignTargetEntity>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return await GetCampaignTargetAsync(entity.Id);
        }

        public async Task<BaseResponse<CampaignTargetDto>> GetCampaignTargetAsync(int id)
        {
            var campaignTargetEntity = await _unitOfWork.GetRepository<CampaignTargetEntity>().GetByIdAsync(id);
            if (campaignTargetEntity != null)
            {
                CampaignTargetDto campaignTargetDto = _mapper.Map<CampaignTargetDto>(campaignTargetEntity);
                return await BaseResponse<CampaignTargetDto>.SuccessAsync(campaignTargetDto);
            }
            return null;
        }

        public async Task<BaseResponse<CampaignTargetInsertFormDto>> GetInsertForm()
        {
            CampaignTargetInsertFormDto response = new CampaignTargetInsertFormDto();
            response.TargetOperationList = (await _parameterService.GetTargetOperationListAsync()).Data;
            response.TargetDefinitionList = (await _parameterService.GetTargetDefinitionListAsync()).Data;

            return await BaseResponse<CampaignTargetInsertFormDto>.SuccessAsync(response);
        }

        public async Task<BaseResponse<List<CampaignTargetDto>>> GetListAsync()
        {
            List<CampaignTargetDto> campaignTargetDtos = _unitOfWork.GetRepository<CampaignTargetEntity>().GetAll().Select(x => _mapper.Map<CampaignTargetDto>(x)).ToList();
            return await BaseResponse<List<CampaignTargetDto>>.SuccessAsync(campaignTargetDtos);
        }

        public async Task<BaseResponse<CampaignTargetUpdateFormDto>> GetUpdateForm(int id)
        {
            CampaignTargetUpdateFormDto response = new CampaignTargetUpdateFormDto();
            response.TargetOperationList = (await _parameterService.GetTargetOperationListAsync()).Data;
            response.TargetDefinitionList = (await _parameterService.GetTargetDefinitionListAsync()).Data;
            response.CampaignTarget = (await GetCampaignTargetAsync(id))?.Data;

            return await BaseResponse<CampaignTargetUpdateFormDto>.SuccessAsync(response);
        }

        public async Task<BaseResponse<CampaignTargetDto>> UpdateAsync(CampaignTargetDto campaignTarget)
        {
            if (campaignTarget == null) return null;

            var entity = _mapper.Map<CampaignTargetEntity>(campaignTarget);
            await _unitOfWork.GetRepository<CampaignTargetEntity>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            BaseResponse<CampaignTargetDto> mappedCampaignTarger = await GetCampaignTargetAsync(campaignTarget.Id);
            return mappedCampaignTarger;
        }

    }
}
