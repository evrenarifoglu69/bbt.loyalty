using AutoMapper;
using Bbt.Campaign.Core.DbEntities;
using Bbt.Campaign.EntityFrameworkCore.UnitOfWork;
using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos.Target;
using Bbt.Campaign.Public.Models.Target;
using Bbt.Campaign.Services.Services.Parameter;
using Bbt.Campaign.Shared.ServiceDependencies;

namespace Bbt.Target.Services.Services.Target
{
    public class TargetService : ITargetService, IScopedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IParameterService _parameterService;

        public TargetService(IUnitOfWork unitOfWork, IMapper mapper, IParameterService parameterService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _parameterService = parameterService;
        }

        public async Task<BaseResponse<TargetDto>> AddAsync(TargetInsertRequest Target)
        {
            CheckValidationAsync(Target);

            var entity = _mapper.Map<TargetEntity>(Target);
            entity = await _unitOfWork.GetRepository<TargetEntity>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            var mappedTarget = _mapper.Map<TargetDto>(entity);
            return await BaseResponse<TargetDto>.SuccessAsync(mappedTarget);
        }

        public async Task<BaseResponse<TargetDto>> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<TargetEntity>().GetByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.GetRepository<TargetEntity>().DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                return await GetTargetAsync(entity.Id);
            }
            return await BaseResponse<TargetDto>.FailAsync("Kampanya bulunamadı.");
        }

        public async Task<BaseResponse<TargetDto>> GetTargetAsync(int id)
        {
            var TargetEntity = await _unitOfWork.GetRepository<TargetEntity>().GetByIdAsync(id);
            if (TargetEntity != null)
            {
                var mappedTarget = _mapper.Map<TargetDto>(TargetEntity);
                return await BaseResponse<TargetDto>.SuccessAsync(mappedTarget);
            }
            return await BaseResponse<TargetDto>.FailAsync("Kampanya bulunamadı.");
        }


        public async Task<BaseResponse<List<TargetDto>>> GetListAsync()
        {
            var mappedTargets = _unitOfWork.GetRepository<TargetEntity>().GetAll(x => !x.IsDeleted).Select(x => _mapper.Map<TargetDto>(x)).ToList();
            return await BaseResponse<List<TargetDto>>.SuccessAsync(mappedTargets);
        }

        public async Task<BaseResponse<TargetDto>> UpdateAsync(TargetUpdateRequest Target)
        {
            await CheckValidationAsync(Target);
            var entity = _unitOfWork.GetRepository<TargetEntity>().GetAllIncluding(x => x.TargetDetail).Where(x => x.Id == Target.Id).FirstOrDefault();
            if (entity != null)
            {
                entity.Title= Target.Title;
                entity.Name= Target.Name;
                await _unitOfWork.GetRepository<TargetEntity>().UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                return await GetTargetAsync(Target.Id);
            }
            return await BaseResponse<TargetDto>.FailAsync("Kampanya bulunamadı.");
        }

        async Task CheckValidationAsync(TargetInsertRequest input)
        {
           

            //file eklenmeli
        }

        public async Task<BaseResponse<TargetListFilterResponse>> GetByFilterAsync(TargetListFilterRequest request)
        {

            TargetListFilterResponse response = new TargetListFilterResponse();

            return await BaseResponse<TargetListFilterResponse>.SuccessAsync(response);
        }
    }
}
