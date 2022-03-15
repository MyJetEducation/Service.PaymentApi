using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Service.Grpc;
using Service.PaymentDeposit.Grpc;
using Service.PaymentDeposit.Grpc.Models;
using Service.PaymentApi.Mappers;
using Service.PaymentApi.Models;
using Service.PaymentDepositRepository.Domain.Models;
using Service.Web;

namespace Service.PaymentApi.Controllers
{
	[OpenApiTag("PaymentDeposit", Description = "payment deposit")]
	[Route("/api/v1/payment/deposit")]
	public class PaymentDepositController : BaseController
	{
		private readonly IGrpcServiceProxy<IPaymentDepositService> _paymentDepositService;

		public PaymentDepositController(IGrpcServiceProxy<IPaymentDepositService> paymentDepositService) => _paymentDepositService = paymentDepositService;

		[Authorize]
		[HttpPost("register")]
		[SwaggerResponse(HttpStatusCode.OK, typeof (DataResponse<DepositResponse>))]
		[SwaggerResponse(HttpStatusCode.Redirect, null, Description = "Redirect to external payment validator")]
		public async ValueTask<IActionResult> RegisterDepositAsync([FromBody] DepositRequest request)
		{
			Guid? userId = GetUserId();
			if (userId == null)
				return StatusResponse.Error(ResponseCode.UserNotFound);

			DepositGrpcResponse response = await _paymentDepositService.TryCall(service => service.DepositAsync(request.ToGrpcModel(userId)));

			if (response.RedirectUrl != null)
				return DataResponse<DepositResponse>.Ok(new DepositResponse(response.RedirectUrl));

			switch (response.State)
			{
				case TransactionState.Accepted when response.RedirectUrl != null:
					return DataResponse<DepositResponse>.Ok(new DepositResponse(response.RedirectUrl));
				case TransactionState.Approved:
					return StatusResponse.Ok();
				default:
					return StatusResponse.Error();
			}
		}

		[AllowAnonymous]
		[HttpGet("callback-test")]
		[SwaggerResponse(HttpStatusCode.OK, typeof (StatusResponse), Description = "Status")]
		public async ValueTask<IActionResult> CallbackDepositTestAsync([FromQuery] CallbackTestRequest request)
		{
			await _paymentDepositService.Service.CallbackAsync(request.ToGrpcModel());

			return Ok();
		}
	}
}