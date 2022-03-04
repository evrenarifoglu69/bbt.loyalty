namespace Bbt.Campaign.Public.Dtos.CampaignTarget
{
    public class CampaignTargetDto
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int TargetOperationId { get; set; }
        public ParameterDto TargetOperation { get; set; }
        public int TargetDefinitionId { get; set; }
        public ParameterDto TargetDefinition { get; set; }
    }
}
