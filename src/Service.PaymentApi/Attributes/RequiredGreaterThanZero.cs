using System.ComponentModel.DataAnnotations;

namespace Service.PaymentApi.Attributes
{
	public class RequiredGreaterThanZero: ValidationAttribute
    {
        public override bool IsValid(object value) => value != null && int.TryParse(value.ToString(), out int result) && result > 0;
    }
}