using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.PaymentDepositApi.Settings
{
    public class SettingsModel
    {
        [YamlProperty("PaymentDepositApi.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("PaymentDepositApi.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("PaymentDepositApi.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }

        [YamlProperty("PaymentDepositApi.PaymentDepositServiceUrl")]
        public string PaymentDepositServiceUrl { get; set; }
    }
}
