
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Security.Identification.ValidationRules
{
    public class HairColorPassportValidationRule : IPassportValidationRule
    {
        public string PropertyName => "hcl";
        public bool Validate(string value)
        {
            if (value.Length != 7)
                return false;

            return Regex.IsMatch(value, "#[a-f,0-9]{6}");
        }
    }
}
