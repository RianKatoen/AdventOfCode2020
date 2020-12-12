namespace AdventOfCode2020.Security.Identification.ValidationRules
{
    public interface IPassportValidationRule
    {
        string PropertyName { get; }
        bool Validate(string value);
    }
}
