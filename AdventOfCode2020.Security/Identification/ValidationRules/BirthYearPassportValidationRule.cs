namespace AdventOfCode2020.Security.Identification.ValidationRules
{
    public class BirthYearPassportValidationRule : IPassportValidationRule
    {
        public string PropertyName => "byr";
        public bool Validate(string value)
        {
            if (value.Length == 4 && int.TryParse(value, out var birthYear))
            {
                return 1920 <= birthYear && birthYear <= 2002;
            }
            else
            {
                return false;
            }
        }
    }
}
