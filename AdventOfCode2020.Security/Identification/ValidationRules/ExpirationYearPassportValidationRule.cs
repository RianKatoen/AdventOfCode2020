
namespace AdventOfCode2020.Security.Identification.ValidationRules
{
    public class ExpirationYearPassportValidationRule : IPassportValidationRule
    {
        public string PropertyName => "eyr";
        public bool Validate(string value)
        {
            if (value.Length == 4 && int.TryParse(value, out var expirationYear))
            {
                return 2020 <= expirationYear && expirationYear <= 2030;
            }
            else
            {
                return false;
            }
        }
    }
}
