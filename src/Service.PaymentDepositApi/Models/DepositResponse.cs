namespace Service.PaymentDepositApi.Models
{
    public class DepositResponse
    {
	    public DepositResponse(string redirectUrl) => RedirectUrl = redirectUrl;

	    public string RedirectUrl { get; set; }
    }
}
