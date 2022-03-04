using Bbt.Campaign.Core.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bbt.Campaign.Core.DbEntities
{
    public class CampaignTargetEntity : AuditableEntity
    {
        [ForeignKey("Campaign")]
        public int CampaignId { get; set; }
        public CampaignEntity Campaign { get; set; }

        [ForeignKey("TargetOperation")]
        public int TargetOperationId { get; set; }
        public TargetOperationEntity TargetOperation { get; set; }

        [ForeignKey("TargetDefinition")]
        public int TargetDefinitionId { get; set; }
        public TargetDefinitionEntity TargetDefinition { get; set; }
        
    }
}
