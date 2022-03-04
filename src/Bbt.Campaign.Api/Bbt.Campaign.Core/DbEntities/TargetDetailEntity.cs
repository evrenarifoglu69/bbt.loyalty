using Bbt.Campaign.Core.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bbt.Campaign.Core.DbEntities
{
    public class TargetDetailEntity : AuditableEntity
    {
        [ForeignKey("Target")]
        public int TargetId { get; set; }
        public TargetEntity  Target { get; set; }

        [ForeignKey("TargetSource")]
        public int TargetSourceId { get; set; }
        public TargetSourceEntity  TargetSource { get; set; }

        [ForeignKey("TriggerTime")]
        public int? TriggerTimeId { get; set; }
        public TriggerTimeEntity? TriggerTime { get; set; }

        [ForeignKey("TargetViewType")]
        public int TargetViewTypeId { get; set; }
        public TargetViewTypeEntity TargetViewType { get; set; }

        [ForeignKey("VerificationTime")]
        public int? VerificationTimeId { get; set; }
        public VerificationTimeEntity? VerificationTime { get; set; }

        public string FlowName { get; set; }
        public string TargetDetailEn { get; set; }
        public string TargetDetailTr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionTr { get; set; }
        public decimal TotalAmount { get; set; }
        public int NumberOfTransaction { get; set; }
        public int FlowFrequency { get; set; }
        public int AdditionalFlowTime { get; set; }
        public string Query { get; set; }
        public string Condition { get; set; }

    }
}
