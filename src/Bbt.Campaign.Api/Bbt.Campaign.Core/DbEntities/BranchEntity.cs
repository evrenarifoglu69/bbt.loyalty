using Bbt.Campaign.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bbt.Campaign.Core.DbEntities
{
    public class BranchEntity : AuditableEntity
    {
        [MaxLength(250), Required]
        public string Name { get; set; }

        [MaxLength(6), Required]
        public string Code { get; set; }
    }
}
