namespace AdventOfCode2020.Security.Passwords
{
    public interface IPasswordPolicy
    {
        public bool Verify(string password);
    }
}
