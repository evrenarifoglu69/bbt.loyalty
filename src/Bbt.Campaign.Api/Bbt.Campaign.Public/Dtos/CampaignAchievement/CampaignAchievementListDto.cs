namespace Bbt.Campaign.Public.Dtos.CampaignAchievement
{
    public class CampaignAchievementListDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string AchievementType { get; set; }
        public string Action { get; set; }
        public decimal? MaxUtilization { get; set; }

    }
}
