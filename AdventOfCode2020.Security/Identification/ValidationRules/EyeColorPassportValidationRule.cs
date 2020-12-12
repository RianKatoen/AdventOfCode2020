
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Security.Identification.ValidationRules
{
    public class EyeColorPassportValidationRule : IPassportValidationRule
    {
        public string PropertyName => "ecl";
        public bool Validate(string value)
        {
            switch (value)
            {
                case "amb": return true;
                case "blu": return true;
                case "brn": return true;
                case "gry": return true;
                case "grn": return true;
                case "hzl": return true;
                case "oth": return true;
                default: return false;
            }
        }
    }
}
