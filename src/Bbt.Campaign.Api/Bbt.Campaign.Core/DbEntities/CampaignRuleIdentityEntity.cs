using Bbt.Campaign.Core.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bbt.Campaign.Core.DbEntities
{
    public class CampaignRuleIdentityEntity : AuditableEntity
    {
        [ForeignKey("CampaignRule")]
        public int CampaignRuleId { get; set; }
        public CampaignRuleEntity CampaignRule { get; set; }

        [Column(TypeName = "ntext")]
        public string Identities { get; set; }
    }
}
