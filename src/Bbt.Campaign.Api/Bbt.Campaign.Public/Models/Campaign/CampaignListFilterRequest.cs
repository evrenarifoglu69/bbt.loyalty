using Bbt.Campaign.Public.Models.Paging;

namespace Bbt.Campaign.Public.Models.Campaign
{
    public class CampaignListFilterRequest: PagingRequest
    {
        public string CampaignName { get; set; }
        public string CampaignCode { get; set; }
        public int? ContractId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBundle { get; set; }
        public int? ProgramTypeId { get; set; }

    }
}
