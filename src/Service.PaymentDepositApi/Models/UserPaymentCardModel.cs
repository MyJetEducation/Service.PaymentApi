using System;

namespace Service.PaymentDepositApi.Models
{
	public class UserPaymentCardModel
	{
		public Guid? CardId { get; set; }

		public string CardName { get; set; }

		public bool IsDefault { get; set; }
	}
}