namespace AdventOfCode2020.Security.Identification.ValidationRules
{
    public class IssueYearPassportValidationRule : IPassportValidationRule
    {
        public string PropertyName => "iyr";
        public bool Validate(string value)
        {
            if (value.Length == 4 && int.TryParse(value, out var issueYear))
            {
                return 2010 <= issueYear && issueYear <= 2020;
            }
            else
            {
                return false;
            }
        }
    }
}
