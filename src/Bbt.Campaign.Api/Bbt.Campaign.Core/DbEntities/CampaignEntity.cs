using Bbt.Campaign.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bbt.Campaign.Core.DbEntities
{
    public class CampaignEntity : AuditableEntity
    {
        [MaxLength(500), Required]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Code { get; set; }
        public string DescriptionTr { get; set; }
        public string DescriptionEn { get; set; }
        public string TitleTr { get; set; }
        public string TitleEn { get; set; }        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Order { get; set; }
        public int MaxNumberOfUser { get; set; }

        [ForeignKey("Sector")]
        public int SectorId { get; set; }
        public SectorEntity Sector { get; set; }

        [ForeignKey("ViewOption")]
        public int ViewOptionId { get; set; }
        public ViewOptionEntity ViewOption { get; set; }

        [ForeignKey("ActionOption")]
        public int ActionOptionId { get; set; }
        public ActionOptionEntity ActionOption { get; set; }

        public bool IsActive { get; set; }
        public bool IsBundle { get; set; }
        public bool IsContract { get; set; }
        public virtual CampaignRuleEntity CampaignRule { get; set; }
        public int? ContractId { get; set; }

        [ForeignKey("ProgramType")]
        public int ProgramTypeId { get; set; }
        public ProgramTypeEntity ProgramType { get; set; }

        public virtual CampaignDetailEntity CampaignDetail { get; set; }
    }
}
