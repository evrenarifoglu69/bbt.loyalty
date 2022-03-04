using Bbt.Campaign.Core.BaseEntities;
using Bbt.Campaign.Public.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bbt.Campaign.Core.DbEntities
{
    public class CampaignTopLimitEntity : AuditableEntity
    {
        [ForeignKey("Campaign")]
        public int CampaignId { get; set; }
        public CampaignEntity Campaign { get; set; }

        [ForeignKey("AchievementFrequency")]
        public int AchievementFrequencyId { get; set; }
        public AchievementFrequencyEntity AchievementFrequency { get; set; }

        [ForeignKey("Currency")]
        public int? CurrencyId { get; set; }
        public CurrencyEntity? Currency { get; set; }

        public decimal? MaxTopLimitAmount { get; set; } = 0;
        public decimal? MaxTopLimitRate { get; set; }
        public decimal? MaxTopLimitUtilization { get; set; }
        public TopLimitType Type { get; set; }

    }
}
