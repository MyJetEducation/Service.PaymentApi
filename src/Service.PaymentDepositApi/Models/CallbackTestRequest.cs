using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Service.PaymentDepositApi.Models
{
	public class CallbackTestRequest
	{
		[Required, FromQuery(Name = "transaction-id")]
		public Guid? TransactionId { get; set; }
		
		[FromQuery(Name = "external-id")]
		public string ExternalId { get; set; }

		[Required, FromQuery(Name = "state")]
		public string State { get; set; }
	}
}