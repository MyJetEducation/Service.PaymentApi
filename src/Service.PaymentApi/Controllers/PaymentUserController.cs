using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Service.Grpc;
using Service.PaymentApi.Models;
using Service.UserPaymentCard.Grpc;
using Service.UserPaymentCard.Grpc.Models;
using Service.Web;

namespace Service.PaymentApi.Controllers
{
	[OpenApiTag("PaymentUser", Description = "user payment utils")]
	[Route("/api/v1/payment/user")]
	public class PaymentUserController : BaseController
	{
		private readonly IGrpcServiceProxy<IUserPaymentCardService> _userPaymentCardService;

		public PaymentUserController(IGrpcServiceProxy<IUserPaymentCardService> userPaymentCardService) => _userPaymentCardService = userPaymentCardService;

		[Authorize]
		[HttpGet("cards")]
		[SwaggerResponse(HttpStatusCode.OK, typeof (UserPaymentCardModel[]), Description = "Status")]
		public async ValueTask<IActionResult> CardsAsync()
		{
			Guid? userId = GetUserId();
			if (userId == null)
				return StatusResponse.Error(ResponseCode.UserNotFound);

			CardsInfoGrpcResponse cardsResponse = await _userPaymentCardService.Service.GetCardNamesAsync(new GetCardsInfoGrpcRequest {UserId = userId});

			CardsInfoGrpcModel[] cards = cardsResponse?.Items;
			if (cards == null)
				return StatusResponse.Error(ResponseCode.NoResponseData);

			UserPaymentCardModel[] userCards = cards.Select(model => new UserPaymentCardModel
			{
				CardId = model.CardId,
				CardName = model.CardName,
				IsDefault = model.IsDefault
			}).ToArray();

			return DataResponse<UserPaymentCardModel[]>.Ok(userCards);
		}
	}
}