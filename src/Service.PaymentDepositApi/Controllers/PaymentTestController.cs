using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Service.PaymentDepositApi.Controllers
{
	/// <summary>
	///     to-do: remove
	/// </summary>
	[OpenApiTag("PaymentTest", Description = "payment test")]
	[Route("/api/v1/payment/test")]
	public class PaymentTestController : BaseController
	{
		[HttpGet("payment")]
		public ViewResult PaymentTest() => View("PaymentTest");
	}
}