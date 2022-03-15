using Autofac;
using Microsoft.Extensions.Logging;
using Service.PaymentDeposit.Client;
using Service.UserPaymentCard.Client;

namespace Service.PaymentApi.Modules
{
	public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterPaymentDepositClient(Program.Settings.PaymentDepositServiceUrl, Program.LogFactory.CreateLogger(typeof(PaymentDepositClientFactory)));
			builder.RegisterUserPaymentCardClient(Program.Settings.UserPaymentCardServiceUrl, Program.LogFactory.CreateLogger(typeof(UserPaymentCardClientFactory)));
		}
	}
}
