using Bbt.Campaign.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Bbt.Campaign.Core.DbEntities
{
    public class TargetEntity : AuditableEntity
    {
        [MaxLength(250), Required]
        public string Name { get; set; }
        [MaxLength(250), Required]
        public string Title { get; set; }
        public virtual TargetDetailEntity TargetDetail { get; set; }
    }
}
