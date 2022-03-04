using Bbt.Campaign.Public.Enums;
using Bbt.Campaign.Public.Models.Paging;

namespace Bbt.Campaign.Public.Models.CampaignTopLimit
{
    public class CampaignTopLimitListFilterRequest: PagingRequest
    {
        public string CampaignName { get; set; }
        public int? AchievementFrequencyId { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? MaxTopLimitAmount { get; set; } = 0;
        public decimal? MaxTopLimitRate { get; set; }
        public decimal? MaxTopLimitUtilization { get; set; }
        public TopLimitType? Type { get; set; }

    }
}
