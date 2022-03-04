using Bbt.Campaign.Public.Dtos.Campaign;

namespace Bbt.Campaign.Public.Dtos.CampaignRule
{
    public class CampaignRuleDto
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public CampaignDto Campaign { get; set; }

        public string IdentityNumber { get; set; }

        public int BusinessLineId { get; set; }
        public ParameterDto BusinessLine { get; set; }

        public int JoinTypeId { get; set; }
        public ParameterDto JoinType { get; set; }

        public int BranchId { get; set; }
        public ParameterDto Branch { get; set; }

        public int CustomerTypeId { get; set; }
        public ParameterDto CustomerType { get; set; }

        public int CampaignStartTermId { get; set; }
        public ParameterDto CampaignStartTerm { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
