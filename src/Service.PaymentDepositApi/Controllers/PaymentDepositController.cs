using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Service.Grpc;
using Service.PaymentDeposit.Grpc;
using Service.PaymentDeposit.Grpc.Models;
using Service.PaymentDepositApi.Mappers;
using Service.PaymentDepositApi.Models;
using Service.Web;

namespace Service.PaymentDepositApi.Controllers
{
	[OpenApiTag("PaymentDeposit", Description = "payment deposit")]
	[Route("/api/v1/paymentdeposit")]
	public class PaymentDepositController : BaseController
	{
		private readonly IGrpcServiceProxy<IPaymentDepositService> _paymentDepositService;

		public PaymentDepositController(IGrpcServiceProxy<IPaymentDepositService> paymentDepositService) => _paymentDepositService = paymentDepositService;

		[Authorize]
		[HttpPost("deposit")]
		[SwaggerResponse(HttpStatusCode.OK, typeof (DataResponse<StatusResponse>))]
		[SwaggerResponse(HttpStatusCode.Redirect, null, Description = "Redirect to external payment validator")]
		public async ValueTask<IActionResult> DepositAsync([FromBody] DepositRequest request)
		{
			Guid? userId = GetUserId();
			if (userId == null)
				return StatusResponse.Error(ResponseCode.UserNotFound);

			DepositGrpcResponse response = await _paymentDepositService.TryCall(service => service.DepositAsync(request.ToGrpcModel(userId)));
			if (response.Approved)
				return StatusResponse.Ok();

			if (response.RedirectUrl != null)
				return Redirect(response.RedirectUrl);

			return StatusResponse.Error();
		}

		[AllowAnonymous]
		[HttpGet("callback-test")]
		[SwaggerResponse(HttpStatusCode.OK, typeof (StatusResponse), Description = "Status")]
		public async ValueTask<IActionResult> CallbackTestAsync([FromQuery] CallbackTestRequest request)
		{
			await _paymentDepositService.Service.CallbackAsync(request.ToGrpcModel());

			return Ok();
		}

		/// <summary>
		///     to-do: remove
		/// </summary>
		[HttpGet("payment")]
		public ViewResult PaymentTest()
		{
			return View("PaymentTest");
		}
	}
}