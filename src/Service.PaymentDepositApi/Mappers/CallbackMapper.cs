using Service.PaymentDeposit.Grpc.Models;
using Service.PaymentDepositApi.Models;
using Service.PaymentDepositRepository.Domain.Models;

namespace Service.PaymentDepositApi.Mappers
{
	public static class CallbackMapper
	{
		public static CallbackGrpcRequest ToGrpcModel(this CallbackTestRequest request) => new CallbackGrpcRequest
		{
			TransactionId = request.TransactionId,
			ExternalId = request.ExternalId,
			State = GetState(request.State)
		};

		private static TransactionState GetState(string state)
		{
			switch (state)
			{
				case "approved":
					return TransactionState.Approved;
				case "accepted":
					return TransactionState.Accepted;
				case "rejected":
					return TransactionState.Rejected;
			}
			return TransactionState.Error;
		}
	}
}