using Bbt.Campaign.Public.Enums;

namespace Bbt.Campaign.Public.Dtos.CampaignAchievement
{
    public class CampaignAchievementDto
    {
        public int Id { get; set; }
        public int CampaignChannelId { get; set; }
        public int CampaignId { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Rate { get; set; }
        public decimal? MaxAmount { get; set; }
        public decimal MaxUtilization { get; set; }
        public AchievementType Rule { get; set; }
        public int AchievementTypeId { get; set; }
        public int ActionOptionId { get; set; }
        public string DescriptionTr { get; set; }
        public string DescriptionEn { get; set; }
        public string TitleTr { get; set; }
        public string TitleEn { get; set; }

    }
}
