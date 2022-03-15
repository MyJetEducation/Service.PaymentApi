using System;
using Service.PaymentDeposit.Grpc.Models;
using Service.PaymentApi.Models;

namespace Service.PaymentApi.Mappers
{
	public static class DepositMapper
	{
		public static DepositGrpcRequest ToGrpcModel(this DepositRequest request, Guid? userId) => new DepositGrpcRequest
		{
			UserId = userId,
			Amount = request.Amount,
			Currency = request.Currency,
			Country = request.Country,
			ServiceCode = request.ServiceCode,
			CardId = request.CardId,
			Number = request.Number,
			Holder = request.Holder,
			Month = request.Month,
			Year = request.Year,
			Cvv = request.Cvv
		};
	}
}