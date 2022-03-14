using Bbt.Campaign.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Bbt.Campaign.Core.DbEntities
{
    public class TargetGroupEntity : AuditableEntity
    {
        [MaxLength(250), Required]
        public string Name { get; set; }

        public virtual ICollection<TargetGroupLineEntity> TargetGroupLines { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
