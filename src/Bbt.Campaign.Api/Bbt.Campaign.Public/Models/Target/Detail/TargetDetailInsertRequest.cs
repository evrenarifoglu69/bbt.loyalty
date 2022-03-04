using Bbt.Campaign.Public.Dtos.Target.TriggerTime;
using Bbt.Campaign.Public.Dtos.Target.VerificationTime;
using Bbt.Campaign.Public.Dtos.Target.ViewType;

namespace Bbt.Campaign.Public.Models.Target.Detail
{
    public class TargetDetailInsertRequest
    {
        public int TargetSourceId { get; set; }
        public int TargetViewTypeId { get; set; }
        public int TriggerTimeId { get; set; }
        public int VerificationTimeId { get; set; }
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
