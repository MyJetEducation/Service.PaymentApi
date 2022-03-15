using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Service.PaymentApi.Controllers
{
	/// <summary>
	///     to-do: remove
	/// </summary>
	[OpenApiTag("PaymentTest", Description = "payment test")]
	[Route("/api/v1/payment/deposit")]
	public class PaymentTestController : BaseController
	{
		[HttpGet("test")]
		public ViewResult PaymentTest() => View("PaymentTest");
	}
}