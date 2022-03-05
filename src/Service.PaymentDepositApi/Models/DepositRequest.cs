namespace Service.PaymentDepositApi.Models
{
	public class DepositRequest
	{
		public decimal Amount { get; set; }

		public string Currency { get; set; }

		public string Country { get; set; }

		public string Number { get; set; }

		public string Holder { get; set; }

		public string Month { get; set; }

		public string Year { get; set; }

		public string Cvv { get; set; }
	}
}