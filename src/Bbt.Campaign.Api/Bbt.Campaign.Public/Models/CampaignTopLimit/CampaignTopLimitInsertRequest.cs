using Bbt.Campaign.Public.Enums;

namespace Bbt.Campaign.Public.Models.CampaignTopLimit
{
    public class CampaignTopLimitInsertRequest : CampaignTopLimitInsertBaseRequest
    {
        public List<int> CampaignIds { get; set; }
    }
}
