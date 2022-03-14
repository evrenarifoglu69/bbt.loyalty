using AutoMapper;
using Bbt.Campaign.Core.DbEntities;
using Bbt.Campaign.Public.Dtos.CampaignTopLimit;
using Bbt.Campaign.Public.Models.CampaignTopLimit;

namespace Bbt.Campaign.Services.Mappings
{
    public class CampaignTopLimitProfile : Profile
    {
        public CampaignTopLimitProfile()
        {
            CreateMap<CampaignTopLimitDto, CampaignTopLimitEntity>().ReverseMap();
            CreateMap<CampaignTopLimitInsertRequest, CampaignTopLimitEntity>().ReverseMap();
            CreateMap<CampaignTopLimitUpdateRequest, CampaignTopLimitEntity>().ReverseMap();
            CreateMap<CampaignTopLimitListDto, CampaignTopLimitEntity>().ReverseMap();
            CreateMap<CampaignTopLimitInsertBaseRequest, CampaignTopLimitEntity>().ReverseMap();
        }
    }
}
