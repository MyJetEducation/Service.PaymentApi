using System.ComponentModel.DataAnnotations;

namespace Service.PaymentApi.Models
{
	public class DepositRequest
	{
		[Required]
		public decimal Amount { get; set; }

		[Required]
		public string Currency { get; set; }

		[Required]
		public string Country { get; set; }

		[Required]
		public string ServiceCode { get; set; }

		[Required]
		public string Number { get; set; }

		[Required]
		public string Holder { get; set; }

		[Required]
		public string Month { get; set; }

		[Required]
		public string Year { get; set; }

		[Required]
		public string Cvv { get; set; }
	}
}