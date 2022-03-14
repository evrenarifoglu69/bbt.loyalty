using AutoMapper;
using Bbt.Campaign.Core.DbEntities;
using Bbt.Campaign.EntityFrameworkCore.UnitOfWork;
using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos;
using Bbt.Campaign.Public.Dtos.Campaign;
using Bbt.Campaign.Public.Models.Campaign;
using Bbt.Campaign.Services.Services.Parameter;
using Bbt.Campaign.Shared.ServiceDependencies;

namespace Bbt.Campaign.Services.Services.Campaign
{
    public class CampaignService : ICampaignService, IScopedService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IParameterService _parameterService;

        public CampaignService(IUnitOfWork unitOfWork, IMapper mapper, IParameterService parameterService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _parameterService = parameterService;
        }

        public async Task<BaseResponse<CampaignDto>> AddAsync(CampaignInsertRequest campaign)
        {
            CheckValidationAsync(campaign);

            var entity = _mapper.Map<CampaignEntity>(campaign);
            entity.Code = string.Empty;

            entity = await _unitOfWork.GetRepository<CampaignEntity>().AddAsync(entity);
            
            await _unitOfWork.SaveChangesAsync();
            var mappedCampaign = _mapper.Map<CampaignDto>(entity);
            return await BaseResponse<CampaignDto>.SuccessAsync(mappedCampaign);
        }

        public async Task<BaseResponse<CampaignDto>> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<CampaignEntity>().GetByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.GetRepository<CampaignEntity>().DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                return await GetCampaignAsync(entity.Id);
            }
            return await BaseResponse<CampaignDto>.FailAsync("Kampanya bulunamadı.");
        }

        public async Task<BaseResponse<CampaignDto>> GetCampaignAsync(int id)
        {
            var campaignEntity = await _unitOfWork.GetRepository<CampaignEntity>().GetByIdAsync(id);
            if (campaignEntity != null)
            {
                var mappedCampaign = _mapper.Map<CampaignDto>(campaignEntity);
                mappedCampaign.Code = mappedCampaign.Id.ToString();
                return await BaseResponse<CampaignDto>.SuccessAsync(mappedCampaign);
            }
            return await BaseResponse<CampaignDto>.FailAsync("Kampanya bulunamadı.");
        }

        public async Task<BaseResponse<CampaignInsertFormDto>> GetInsertFormAsync()
        {
            CampaignInsertFormDto response = new CampaignInsertFormDto();
            await FillFormAsync(response);
            return await BaseResponse<CampaignInsertFormDto>.SuccessAsync(response);
        }

        public async Task<BaseResponse<List<CampaignDto>>> GetListAsync()
        {
            var mappedCampaigns = _unitOfWork.GetRepository<CampaignEntity>().GetAll(x => !x.IsDeleted).Select(x => _mapper.Map<CampaignDto>(x)).ToList();
            return await BaseResponse<List<CampaignDto>>.SuccessAsync(mappedCampaigns);
        }

        public async Task<BaseResponse<List<ParameterDto>>> GetParameterListAsync()
        {
            var existCampaings = _unitOfWork.GetRepository<CampaignEntity>().GetAll(x => !x.IsDeleted).Select(x => _mapper.Map<ParameterDto>(x)).ToList();
            return await BaseResponse<List<ParameterDto>>.SuccessAsync(existCampaings);
        }

        public async Task<BaseResponse<CampaignUpdateFormDto>> GetUpdateFormAsync(int id)
        {
            CampaignUpdateFormDto response = new CampaignUpdateFormDto();
            await FillFormAsync(response);
            response.Campaign = (await GetCampaignAsync(id))?.Data;

            return await BaseResponse<CampaignUpdateFormDto>.SuccessAsync(response);
        }

        private async Task FillFormAsync(CampaignInsertFormDto response)
        {
            response.ActionOptionList = (await _parameterService.GetActionOptionListAsync())?.Data;
            response.ViewOptionList = (await _parameterService.GetViewOptionListAsync())?.Data;
            response.SectorList = (await _parameterService.GetSectorListAsync())?.Data;
            response.ProgramTypeList = (await _parameterService.GetProgramTypeListAsync())?.Data;
        }

        public async Task<BaseResponse<CampaignDto>> UpdateAsync(CampaignUpdateRequest campaign)
        {
            await CheckValidationAsync(campaign);
            var entity = _unitOfWork.GetRepository<CampaignEntity>().GetAllIncluding(x => x.CampaignDetail).Where(x => x.Id == campaign.Id).FirstOrDefault();
            if (entity != null)
            {
                if (entity.CampaignDetail == null)
                {
                    entity.CampaignDetail = await _unitOfWork.GetRepository<CampaignDetailEntity>().AddAsync(new CampaignDetailEntity()
                    {
                        CampaignId = campaign.Id,
                        DetailEn = campaign.CampaignDetail.DetailEn,
                        DetailTr = campaign.CampaignDetail.DetailTr,
                        SummaryEn = campaign.CampaignDetail.SummaryEn,
                        SummaryTr = campaign.CampaignDetail.SummaryTr,
                        CampaignDetailImageUrl = campaign.CampaignDetail.CampaignDetailImageUrl,
                        CampaignListImageUrl = campaign.CampaignDetail.CampaignListImageUrl,
                        ContentTr = campaign.CampaignDetail.ContentTr,
                        ContentEn = campaign.CampaignDetail.ContentEn
                    });
                    await _unitOfWork.SaveChangesAsync();
                }
                else
                {
                    entity.CampaignDetail.DetailEn = campaign.CampaignDetail.DetailEn;
                    entity.CampaignDetail.DetailTr = campaign.CampaignDetail.DetailTr;
                    entity.CampaignDetail.SummaryEn = campaign.CampaignDetail.SummaryEn;
                    entity.CampaignDetail.SummaryTr = campaign.CampaignDetail.SummaryTr;
                    entity.CampaignDetail.CampaignDetailImageUrl = campaign.CampaignDetail.CampaignDetailImageUrl;
                    entity.CampaignDetail.CampaignListImageUrl = campaign.CampaignDetail.CampaignListImageUrl;
                    entity.CampaignDetail.ContentTr = campaign.CampaignDetail.ContentTr;
                    entity.CampaignDetail.ContentEn = campaign.CampaignDetail.ContentEn;
                }

                entity.ContractId = campaign.ContractId;
                entity.ProgramTypeId = campaign.ProgramTypeId;
                entity.SectorId = campaign.SectorId;
                entity.ViewOptionId = campaign.ViewOptionId;
                entity.IsBundle = campaign.IsBundle;
                entity.IsContract = campaign.IsContract;
                entity.DescriptionTr = campaign.DescriptionTr;
                entity.DescriptionEn = campaign.DescriptionEn;
                entity.EndDate = campaign.EndDate;
                entity.StartDate = campaign.StartDate;
                entity.Name = campaign.Name;
                entity.Order = campaign.Order;
                entity.TitleTr = campaign.TitleTr;
                entity.TitleEn = campaign.TitleEn;
                entity.MaxNumberOfUser = campaign.MaxNumberOfUser;

                await _unitOfWork.GetRepository<CampaignEntity>().UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                return await GetCampaignAsync(campaign.Id);
            }
            return await BaseResponse<CampaignDto>.FailAsync("Kampanya bulunamadı.");
        }

        async Task CheckValidationAsync(CampaignInsertRequest input)
        {
            if (string.IsNullOrWhiteSpace(input.Name))
                throw new Exception("Kampanya Adı girilmelidir.");
            if (string.IsNullOrWhiteSpace(input.DescriptionTr))
                throw new Exception("Açıklama Detayı girilmelidir.");
            if (string.IsNullOrWhiteSpace(input.DescriptionEn))
                throw new Exception("Açıklama Detayı (İngilizce) girilmelidir.");
            if (string.IsNullOrWhiteSpace(input.TitleTr))
                throw new Exception("Başlık girilmelidir.");
            if (string.IsNullOrWhiteSpace(input.TitleEn))
                throw new Exception("Başlık (İngilizce) girilmelidir.");
            if (input.StartDate < DateTime.Now)
                throw new Exception("Başlama Tarihi seçilmelidir");
            if (input.EndDate < DateTime.Now)
                throw new Exception("Bitiş Tarihi seçilmelidir");
            if (input.Order <= 0)
                throw new Exception("Sıralama girilmelidir.");
            if (input.SectorId <= 0)
                throw new Exception("Sektör seçilmelidir.");
            else
            {
                var sector = (await _parameterService.GetSectorListAsync())?.Data?.Any(x => x.Id == input.SectorId);
                if (!sector.GetValueOrDefault(false))
                    throw new Exception("Sektör seçilmelidir.");
            }

            if (input.ViewOptionId <= 0)
                throw new Exception("Görüntüleme seçilmelidir.");
            else
            {
                var viewOption = (await _parameterService.GetViewOptionListAsync())?.Data?.Any(x => x.Id == input.ViewOptionId);
                if (!viewOption.GetValueOrDefault(false))
                    throw new Exception("Görüntüleme seçilmelidir.");
            }

            //campaign detail validasyonları

            if (string.IsNullOrWhiteSpace(input.CampaignDetail?.SummaryTr))
                throw new Exception("Özet girilmelidir.");            
            if (string.IsNullOrWhiteSpace(input.CampaignDetail?.SummaryEn))
                throw new Exception("Özet girilmelidir (İngilizce).");            
            if (!string.IsNullOrWhiteSpace(input.CampaignDetail?.DetailTr) && string.IsNullOrWhiteSpace(input.CampaignDetail?.DetailEn))
                throw new Exception("Detay girilmelidir (İngilizce).");
            if (!string.IsNullOrWhiteSpace(input.CampaignDetail?.ContentTr) && string.IsNullOrWhiteSpace(input.CampaignDetail?.ContentEn))
                throw new Exception("İçerik girilmelidir (İngilizce).");
        }

        public async Task<BaseResponse<CampaignListFilterResponse>> GetByFilterAsync(CampaignListFilterRequest request)
        {
            Core.Helper.Helpers.ListByFilterCheckValidation(request);

            var campaignQuery = _unitOfWork.GetRepository<CampaignEntity>().GetAll(x => !x.IsDeleted);

            if (request.IsBundle.HasValue)
                campaignQuery = campaignQuery.Where(x => x.IsBundle == request.IsBundle.Value);
            if (!string.IsNullOrWhiteSpace(request.CampaignCode))
                campaignQuery = campaignQuery.Where(x => x.Code == request.CampaignCode);
            if (!string.IsNullOrWhiteSpace(request.CampaignName))
                campaignQuery = campaignQuery.Where(x => x.Name == request.CampaignName);
            if (request.ContractId.HasValue)
                campaignQuery = campaignQuery.Where(x => x.ContractId == request.ContractId.Value);
            if (request.IsActive.HasValue)
                campaignQuery = campaignQuery.Where(x => x.IsActive == request.IsActive.Value);
            if (request.ProgramTypeId.HasValue)
                campaignQuery = campaignQuery.Where(x => x.ProgramTypeId == request.ProgramTypeId.Value);

            var pageNumber = request.PageNumber.GetValueOrDefault(1) < 1 ? 1 : request.PageNumber.GetValueOrDefault(1);
            var pageSize = request.PageSize.GetValueOrDefault(0) == 0 ? 25 : request.PageSize.Value;
            var totalItems = campaignQuery.Count();

            campaignQuery = campaignQuery.OrderByDescending(x => x.CreatedOn).Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var campaignList = campaignQuery.Select(x => new CampaignListDto
            {
                Id = x.Id,
                Code = x.Id.ToString(),
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                ContractId = x.ContractId,
                IsActive = x.IsActive,
                IsBundle = x.IsBundle,
                ProgramType = x.ProgramType.Name,
                Name = x.Name
            }).ToList();

            CampaignListFilterResponse response = new CampaignListFilterResponse();
            response.ResponseList = campaignList;
            response.Paging = Core.Helper.Helpers.Paging(totalItems, pageNumber, pageSize);

            return await BaseResponse<CampaignListFilterResponse>.SuccessAsync(response);
        }


    }
}
