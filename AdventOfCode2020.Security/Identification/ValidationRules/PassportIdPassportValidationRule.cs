using System.Text.RegularExpressions;

namespace AdventOfCode2020.Security.Identification.ValidationRules
{
    public class PassportIdPassportValidationRule : IPassportValidationRule
    {
        public string PropertyName => "pid";
        public bool Validate(string value)
        {
            if (value.Length == 9)
            {
                return Regex.IsMatch(value, "[0-9]{9}");
            }
            else
            {
                return false;
            }
        }
    }
}
