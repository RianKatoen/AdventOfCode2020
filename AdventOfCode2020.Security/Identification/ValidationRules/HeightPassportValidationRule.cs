
namespace AdventOfCode2020.Security.Identification.ValidationRules
{
    public class HeightPassportValidationRule : IPassportValidationRule
    {
        public string PropertyName => "hgt";
        public bool Validate(string value)
        {
            if (value.Length < 2)
                return false;

            var unit = value.Substring(value.Length - 2, 2);
            var measurement = value.Substring(0, value.Length - 2);

            if (int.TryParse(measurement, out var height))
            {
                switch (unit)
                {
                    case "cm": return 150 <= height && height <= 193;
                    case "in": return 59 <= height && height <= 76;
                    default: return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
