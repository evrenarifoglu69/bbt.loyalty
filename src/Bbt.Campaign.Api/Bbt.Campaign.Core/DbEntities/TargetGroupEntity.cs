﻿using Bbt.Campaign.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Bbt.Campaign.Core.DbEntities
{
    public class TargetGroupEntity : AuditableEntity
    {
        [MaxLength(250), Required]
        public string Name { get; set; }
        public virtual ICollection<TargetGroupLineEntity> TargetGroupLines { get; set; }
    }
}
