using Autofac;
using Microsoft.Extensions.Logging;
using Service.PaymentDeposit.Client;

namespace Service.PaymentDepositApi.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
	        builder.RegisterPaymentDepositClient(Program.Settings.PaymentDepositServiceUrl, Program.LogFactory.CreateLogger(typeof(PaymentDepositClientFactory)));
        }
    }
}
