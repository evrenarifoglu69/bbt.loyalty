using AutoMapper;
using Bbt.Campaign.Core.DbEntities;
using Bbt.Campaign.EntityFrameworkCore.UnitOfWork;
using Bbt.Campaign.Public.BaseResultModels;
using Bbt.Campaign.Public.Dtos;
using Bbt.Campaign.Public.Dtos.CampaignRule;
using Bbt.Campaign.Public.Enums;
using Bbt.Campaign.Public.Models.CampaignRule;
using Bbt.Campaign.Services.Services.Parameter;
using Bbt.Campaign.Shared.Extentions;
using Bbt.Campaign.Shared.ServiceDependencies;
using Microsoft.EntityFrameworkCore;

namespace Bbt.Campaign.Services.Services.CampaignRule
{
    public class CampaignRuleService : ICampaignRuleService, IScopedService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IParameterService _parameterService;

        public CampaignRuleService(IUnitOfWork unitOfWork, IMapper mapper, IParameterService parameterService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _parameterService = parameterService;
        }

        public async Task<BaseResponse<CampaignRuleDto>> AddAsync(AddCampaignRuleRequest campaignRule)
        {
            await CheckValidationsAsync(campaignRule);

            var entity = new CampaignRuleEntity()
            {
                CampaignId = campaignRule.CampaignId,
                CampaignStartTermId = campaignRule.StartTermId,
                JoinTypeId = campaignRule.JoinTypeId
            };

            if (campaignRule.Branches is { Count: > 0 })
            {
                entity.Branches = new List<CampaignRuleBranchEntity>();
                campaignRule.Branches.ForEach(x =>
                {

                    entity.Branches.Add(new CampaignRuleBranchEntity()
                    {
                        BranchCode = x.Code,
                        BranchName = x.Name
                    });
                });
            }

            if (campaignRule.CustomerTypes is { Count: > 0 })
            {
                entity.CustomerTypes = new List<CampaignRuleCustomerTypeEntity>();
                campaignRule.CustomerTypes.ForEach(x =>
                {

                    entity.CustomerTypes.Add(new CampaignRuleCustomerTypeEntity()
                    {
                        CustomerTypeId = x
                    });
                });
            }

            if (campaignRule.BusinessLines is { Count: > 0 })
            {
                entity.BusinessLines = new List<CampaignRuleBusinessLineEntity>();
                campaignRule.BusinessLines.ForEach(x =>
                {
                    entity.BusinessLines.Add(new CampaignRuleBusinessLineEntity()
                    {
                        BusinessLineId = x
                    });
                });
            }

            if (campaignRule.IsSingleIdentity) 
            { 
                if(!string.IsNullOrEmpty(campaignRule.Identity)) 
                {
                    entity.RuleIdentities = new CampaignRuleIdentityEntity()
                    {
                        Identities = campaignRule.Identity,
                    };
                }
            }
            else if(campaignRule.File != null)
            {
                long length = campaignRule.File.Length;
                using var fileStreamList = campaignRule.File?.OpenReadStream();
                byte[] bytesList = new byte[length];
                fileStreamList.Read(bytesList, 0, (int)length);

                await _unitOfWork.GetRepository<CampaignDocumentEntity>().AddAsync(new CampaignDocumentEntity()
                {
                    CampaignId = campaignRule.CampaignId,
                    DocumentType = Core.Enums.DocumentTypeDbEnum.CampaignRuleTCKN,
                    MimeType = MimeTypeExtensions.ToMimeType(".xlsx"),
                    Content = bytesList,
                    DocumentName = campaignRule.CampaignId.ToString() + "-" + "CampaignRuleTCKN"
                });
            }

            entity = await _unitOfWork.GetRepository<CampaignRuleEntity>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var mappedCampaignRuleDto = _mapper.Map<CampaignRuleDto>(entity);
            return await BaseResponse<CampaignRuleDto>.SuccessAsync(mappedCampaignRuleDto);
        }

        public async Task<BaseResponse<CampaignRuleDto>> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<CampaignRuleEntity>().GetByIdAsync(id);
            if (entity == null)
                return null;

            entity.IsDeleted = true;
            await _unitOfWork.GetRepository<CampaignRuleEntity>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return await GetCampaignRuleAsync(entity.Id);
        }

        public async Task<BaseResponse<CampaignRuleDto>> GetCampaignRuleAsync(int id)
        {
            var campaignRuleEntity = await _unitOfWork.GetRepository<CampaignRuleEntity>().GetByIdAsync(id);
            if (campaignRuleEntity != null)
            {
                CampaignRuleDto campaignRuleDto = _mapper.Map<CampaignRuleDto>(campaignRuleEntity);
                return await BaseResponse<CampaignRuleDto>.SuccessAsync(campaignRuleDto);

            }
            return null;
        }

        public async Task<BaseResponse<CampaignRuleInsertFormDto>> GetInsertForm()
        {
            CampaignRuleInsertFormDto response = new CampaignRuleInsertFormDto();
            await FillForm(response);

            return await BaseResponse<CampaignRuleInsertFormDto>.SuccessAsync(response);
        }

        private async Task FillForm(CampaignRuleInsertFormDto response)
        {
            response.CampaignStartTermList = (await _parameterService.GetCampaignStartTermListAsync())?.Data;
            response.BusinessLineList = (await _parameterService.GetBusinessLineListAsync())?.Data;
            response.BranchList = (await _parameterService.GetBranchListAsync())?.Data;
            response.CustomerTypeList = (await _parameterService.GetCustomerTypeListAsync())?.Data;
            response.JoinTypeList = (await _parameterService.GetJoinTypeListAsync())?.Data;
        }

        public async Task<BaseResponse<List<CampaignRuleDto>>> GetListAsync()
        {
            List<CampaignRuleDto> campaignRules = _unitOfWork.GetRepository<CampaignRuleEntity>().GetAll().Select(x => _mapper.Map<CampaignRuleDto>(x)).ToList();
            return await BaseResponse<List<CampaignRuleDto>>.SuccessAsync(campaignRules);
        }

        public async Task<BaseResponse<CampaignRuleUpdateFormDto>> GetUpdateForm(int id)
        {
            CampaignRuleUpdateFormDto response = new CampaignRuleUpdateFormDto();
            await FillForm(response);
            response.CampaignRule = (await GetCampaignRuleAsync(id))?.Data;

            return await BaseResponse<CampaignRuleUpdateFormDto>.SuccessAsync(response);
        }

        public async Task<BaseResponse<CampaignRuleDto>> UpdateAsync(UpdateCampaignRuleRequest campaignRule)
        {
            await CheckValidationsAsync(campaignRule);

            var entity = await _unitOfWork.GetRepository<CampaignRuleEntity>()
                .GetAll(x => x.Id == campaignRule.Id && x.IsDeleted != true)
                .Include(x => x.Branches.Where(t => t.IsDeleted != true)) 
                .Include(x => x.BusinessLines.Where(t => t.IsDeleted != true)) 
                .Include(x => x.CustomerTypes.Where(t => t.IsDeleted != true))
                .Include(x => x.RuleIdentities)
                .FirstOrDefaultAsync();

            if (entity == null) throw new Exception("Kampanya Kuralı bulunamadı.");

            entity.CampaignStartTermId = campaignRule.StartTermId;

            //Branches
            foreach (var campaignRuleBranchEntity in entity.Branches) 
            {
                await _unitOfWork.GetRepository<CampaignRuleBranchEntity>().DeleteAsync(campaignRuleBranchEntity);
            }
            if (campaignRule.Branches is { Count: > 0 })
            {
                campaignRule.Branches.ForEach(x =>
                {
                    var campaignRuleBranchEntity = new CampaignRuleBranchEntity()
                    {
                        CampaignRuleId = campaignRule.Id,
                        BranchCode = x.Code,
                        BranchName = x.Name
                    };
                    _unitOfWork.GetRepository<CampaignRuleBranchEntity>().AddAsync(campaignRuleBranchEntity);
                });
            }

            //CustomerTypes
            foreach (var customerTypeEntity in entity.CustomerTypes)
            {
                await _unitOfWork.GetRepository<CampaignRuleCustomerTypeEntity>().DeleteAsync(customerTypeEntity);
            }
            if (campaignRule.CustomerTypes is { Count: > 0 })
            {
                campaignRule.CustomerTypes.ForEach(x =>
                {
                    var campaignRuleCustomerTypeEntity = new CampaignRuleCustomerTypeEntity()
                    {
                        CampaignRuleId = campaignRule.Id,
                        CustomerTypeId = x,
                    };
                    _unitOfWork.GetRepository<CampaignRuleCustomerTypeEntity>().AddAsync(campaignRuleCustomerTypeEntity);
                });
            }

            //BusinessLines
            foreach (var campaignRuleBusinessLineEntity in entity.BusinessLines)
            {
                await _unitOfWork.GetRepository<CampaignRuleBusinessLineEntity>().DeleteAsync(campaignRuleBusinessLineEntity);
            }
            if (campaignRule.BusinessLines is { Count: > 0 })
            {
                campaignRule.BusinessLines.ForEach(x =>
                {
                    var campaignRuleBusinessLineEntity = new CampaignRuleBusinessLineEntity()
                    {
                        CampaignRuleId = campaignRule.Id,
                        BusinessLineId = x,
                    };
                    _unitOfWork.GetRepository<CampaignRuleBusinessLineEntity>().AddAsync(campaignRuleBusinessLineEntity);
                });
            }

            //RuleIdentities
            var campaignRuleIdentityEntity = entity.RuleIdentities;
            if (campaignRule.IsSingleIdentity)
            {
                if (!string.IsNullOrEmpty(campaignRule.Identity))
                {
                    if(campaignRuleIdentityEntity != null) 
                    {
                        campaignRuleIdentityEntity.Identities = campaignRule.Identity;
                    }
                    else 
                    {
                        var campaignRuleIdentityEntityNew = new CampaignRuleIdentityEntity()
                        {
                            CampaignRuleId = campaignRule.Id,
                            Identities = campaignRule.Identity,
                        };
                        await _unitOfWork.GetRepository<CampaignRuleIdentityEntity>().AddAsync(campaignRuleIdentityEntityNew);
                    }
                }
            }
            else if(campaignRule.File != null)
            {
                var campaignDocumentEntity = await _unitOfWork.GetRepository<CampaignDocumentEntity>()
                    .GetAll(x => x.CampaignId == campaignRule.CampaignId && x.IsDeleted != true)
                    .FirstOrDefaultAsync();
                if(campaignDocumentEntity != null) 
                {
                    await _unitOfWork.GetRepository<CampaignDocumentEntity>().DeleteAsync(campaignDocumentEntity);
                }

                long length = campaignRule.File.Length;
                using var fileStreamList = campaignRule.File?.OpenReadStream();
                byte[] bytesList = new byte[length];
                fileStreamList.Read(bytesList, 0, (int)length);

                await _unitOfWork.GetRepository<CampaignDocumentEntity>().AddAsync(new CampaignDocumentEntity()
                {
                    CampaignId = campaignRule.CampaignId,
                    DocumentType = Core.Enums.DocumentTypeDbEnum.CampaignRuleTCKN,
                    MimeType = MimeTypeExtensions.ToMimeType(".xlsx"),
                    Content = bytesList,
                    DocumentName = campaignRule.CampaignId.ToString() + "-" + "CampaignRuleTCKN"
                });
            }

            await _unitOfWork.GetRepository<CampaignRuleEntity>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return await GetCampaignRuleAsync(campaignRule.Id);
        }

        async Task CheckValidationsAsync(AddCampaignRuleRequest input)
        {
            ParameterDto joinType = await CheckJoinType(input.JoinTypeId);

            await CheckStartTerm(input.StartTermId);

            switch ((JoinTypeEnum)joinType.Id)
            {
                case JoinTypeEnum.AllCustomers:
                    break;
                case JoinTypeEnum.Customer:
                    {
                        if (input.IsSingleIdentity)
                        {
                            CheckSingleIdentiy(input.Identity);
                        }
                        else if (input.File is null)
                            throw new Exception("TCKN girilmelidir.");

                    }
                    break;
                case JoinTypeEnum.BusinessLine:
                    {
                        if (input.BusinessLines is { Count: < 1 })
                            throw new Exception("İş Kolu seçilmelidir.");
                    }
                    break;
                case JoinTypeEnum.Branch:
                    {
                        if (input.Branches is { Count: < 1 })
                            throw new Exception("Şube seçilmelidir.");
                    }
                    break;
                case JoinTypeEnum.CustomerType:
                    {
                        if (input.CustomerTypes is { Count: < 1 })
                            throw new Exception("Müşteri Tipi seçilmelidir.");
                    }
                    break;
                default:
                    break;
            }

        }
        
        private async Task<ParameterDto> CheckJoinType(int joinTypeId)
        {
            if (joinTypeId <= 0)
                throw new Exception("Dahil Olma Şekli seçilmelidir.");

            Public.Dtos.ParameterDto joinType = (await _parameterService.GetJoinTypeListAsync())?.Data?.FirstOrDefault(x => x.Id == joinTypeId);
            if (joinType == null)
                throw new Exception("Dahil Olma Şekli seçilmelidir.");
            return joinType;
        }
        
        async Task CheckStartTerm(int startTermId)
        {
            if (startTermId <= 0)
                throw new Exception("Kampanya Başlama Dönemi seçilmelidir.");
            else
            {
                var startTerm = (await _parameterService.GetCampaignStartTermListAsync())?.Data?.Any(x => x.Id == startTermId);
                if (!startTerm.GetValueOrDefault(false))
                    throw new Exception("Kampanya Başlama Dönemi seçilmelidir.");
            }
        }
        
        static void CheckSingleIdentiy(string identiy)
        {
            if (string.IsNullOrWhiteSpace(identiy))
                throw new Exception("TCKN girilmelidir.");
            if (identiy?.Trim().Length != 11)
                throw new Exception("TCKN 11 haneli olmalıdır.");
            if (Core.Helper.Helpers.TcAuthentication(identiy))
                throw new Exception("TCKN bilgisi hatalıdır.");
        }
    }
}
