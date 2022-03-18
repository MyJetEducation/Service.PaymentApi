using System;
using System.ComponentModel.DataAnnotations;
using Service.Core.Client.Extensions;
using static System.Double;

namespace Service.PaymentApi.Models
{
	public class DepositRequest
	{
		[Required, Range(Epsilon, MaxValue, ErrorMessage = "The field Amount must be greater than 0")]
		public decimal Amount { get; set; }

		[Required]
		public string Currency { get; set; }

		[Required]
		public string Country { get; set; }

		[Required]
		public string ServiceCode { get; set; }

		public Guid? CardId { get; set; }

		public string Number { get; set; }

		public string Holder { get; set; }

		public string Month { get; set; }

		public string Year { get; set; }

		public string Cvv { get; set; }

		public bool CheckCardNotFilled() => Number.IsNullOrWhiteSpace()
			|| Cvv.IsNullOrWhiteSpace()
			|| Holder.IsNullOrWhiteSpace()
			|| Month.IsNullOrWhiteSpace()
			|| Year.IsNullOrWhiteSpace();
	}
}