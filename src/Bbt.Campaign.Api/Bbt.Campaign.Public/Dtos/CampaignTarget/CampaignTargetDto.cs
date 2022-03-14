namespace Bbt.Campaign.Public.Dtos.CampaignTarget
{
    public class CampaignTargetDto
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int TargetGroupId { get; set; }
        public ParameterDto TargetGroup { get; set; }
    }
}
