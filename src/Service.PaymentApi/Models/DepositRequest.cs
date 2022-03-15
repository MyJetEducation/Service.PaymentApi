using System;
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

		public Guid? CardId { get; set; }

		public string Number { get; set; }

		public string Holder { get; set; }

		public string Month { get; set; }

		public string Year { get; set; }

		public string Cvv { get; set; }
	}
}