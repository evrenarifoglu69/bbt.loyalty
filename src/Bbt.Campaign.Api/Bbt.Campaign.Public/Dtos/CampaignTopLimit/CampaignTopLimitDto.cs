namespace Bbt.Campaign.Public.Dtos.CampaignTopLimit
{
    public class CampaignTopLimitDto
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int TopLimitOperationId { get; set; }
        public ParameterDto TopLimitOperation { get; set; }
        public int TopLimitDefinitionId { get; set; }
        public ParameterDto TopLimitDefinition { get; set; }
    }
}
