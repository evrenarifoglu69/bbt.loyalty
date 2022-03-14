using Bbt.Campaign.Public.Enums;

namespace Bbt.Campaign.Public.Models.CampaignTopLimit
{
    public class CampaignTopLimitInsertBaseRequest
    {
        public int AchievementFrequencyId { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? MaxTopLimitAmount { get; set; } = 0;
        public decimal? MaxTopLimitRate { get; set; }
        public decimal? MaxTopLimitUtilization { get; set; }
        public TopLimitType Type { get; set; }
    }
}
