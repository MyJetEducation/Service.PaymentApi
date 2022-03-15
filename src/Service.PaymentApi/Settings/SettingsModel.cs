using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.PaymentApi.Settings
{
    public class SettingsModel
    {
        [YamlProperty("PaymentApi.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("PaymentApi.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("PaymentApi.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }

        [YamlProperty("PaymentApi.PaymentDepositServiceUrl")]
        public string PaymentDepositServiceUrl { get; set; }

        [YamlProperty("PaymentApi.UserPaymentCardServiceUrl")]
        public string UserPaymentCardServiceUrl { get; set; }
    }
}
