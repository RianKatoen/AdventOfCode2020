namespace AdventOfCode2020.Security.Passwords
{
    public interface IPasswordPolicyFactory
    {
        IPasswordPolicy Create(string policy);
    }
}
