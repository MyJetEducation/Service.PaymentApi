using System;

namespace Service.PaymentDepositApi.Models
{
	public class CallbackTestRequest
	{
		public Guid? TransactionId { get; set; }
		
		public string ExternalId { get; set; }
		
		public string State { get; set; }
	}
}