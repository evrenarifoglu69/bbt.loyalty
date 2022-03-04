using Bbt.Campaign.Core.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bbt.Campaign.Core.DbEntities
{
    public class CampaignAchievementEntity : AuditableEntity
    {
        [ForeignKey("CampaignChannel")]
        public int CampaignChannelId { get; set; }
        public CampaignChannelEntity CampaignChannel { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public CurrencyEntity Currency { get; set; }

        public decimal Amount { get; set; } = 0;
        public decimal Rate { get; set; }
        public decimal MaxAmount { get; set; } = 0;
        public decimal MaxUtilization { get; set; }
    }
}
