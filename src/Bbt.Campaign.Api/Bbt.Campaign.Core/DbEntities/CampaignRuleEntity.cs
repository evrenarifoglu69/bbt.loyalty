using Bbt.Campaign.Core.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bbt.Campaign.Core.DbEntities
{
    public  class CampaignRuleEntity : AuditableEntity
    {
        [ForeignKey("Campaign")]
        public int CampaignId { get; set; }
        public CampaignEntity Campaign { get; set; }

        //public string IdentityNumber { get; set; }

        //[ForeignKey("BusinessLine")]
        //public int BusinessLineId { get; set; }
        //public BusinessLineEntity  BusinessLine { get; set; }

        [ForeignKey("JoinType")]
        public int JoinTypeId { get; set; }
        public JoinTypeEntity JoinType { get; set; }

        //[ForeignKey("Branch")]
        //public int BranchId { get; set; }
        //public BranchEntity  Branch { get; set; }

        //[ForeignKey("CustomerType")]
        //public int CustomerTypeId { get; set; }
        //public CustomerTypeEntity  CustomerType { get; set; }

        [ForeignKey("CampaignStartTerm")]
        public int CampaignStartTermId { get; set; }
        public CampaignStartTermEntity  CampaignStartTerm { get; set; }

        public virtual ICollection<CampaignRuleBranchEntity> Branches { get; set; }
        public virtual ICollection<CampaignRuleBusinessLineEntity>  BusinessLines { get; set; }
        public virtual ICollection<CampaignRuleCustomerTypeEntity>  CustomerTypes { get; set; }

        public virtual CampaignRuleIdentityEntity RuleIdentities { get; set; }
    }
}
