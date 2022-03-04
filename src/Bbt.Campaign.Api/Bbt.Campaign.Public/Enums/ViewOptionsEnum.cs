using System.ComponentModel;

namespace Bbt.Campaign.Public.Enums
{
    public enum ViewOptionsEnum
    {
        [Description("Sürekli Kampanyalar")]
        ConstantCampaign = 1,
        [Description("Geçici Kampanyalar")]
        TemporaryCampaign = 2,
        [Description("Anlık Kampanyalar")]
        InstantCampaign = 3,
    }
}
